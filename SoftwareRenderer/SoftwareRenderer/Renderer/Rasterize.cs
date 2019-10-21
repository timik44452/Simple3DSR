using System;
using System.Drawing;
using SoftwareRenderer.Math;

namespace SoftwareRenderer.Renderer
{
    public class Rasterize
    {
        public static int WIDTH = 0, HEIGHT = 0;

        public static float light, delta, alpha, beta, segmentStartY, triangleYHeight, firstSegmentHeight, secondSegmentHeight;
        public static bool isFirstSegment;

        public static Vector3 A, B, C;
        public static Vector2 uvA, uvB, uvC;


        static void swapV3(ref Vector3 a, ref Vector3 b)
        {
            Vector3 buffer = a;
            a = b;
            b = buffer;
        }
        static void swapV2(ref Vector2 a, ref Vector2 b)
        {
            Vector2 buffer = a;
            a = b;
            b = buffer;
        }
     
        public static void CalculateLight(Vector3 v_normal,Vector3 camera_pos,Vector3 main_light_direction,Material material,Vector3 point)
        {
           // light = (Light.get_light_direction(v_normal,main_light_direction) + Light.get_specular(material.specular,material.reflection,camera_pos,/ 2F;
        }
        public static bool Triangle_Main(Material material,
                                         Vector3 a, Vector3 b, Vector3 c,
                                         Vector2 uv1, Vector2 uv2, Vector2 uv3,
                                         float light,
                                         Vector2 mousePosition,
                                         ref byte[] frame, float[] zBuffer, byte R, byte G, byte B
            )
        {
            if (material.texture != null)
                return Triangle(ref frame, ref zBuffer, mousePosition, a, b, c, uv1, uv2, uv3, light, material.texture);
            else
                return Triangle(ref frame, ref zBuffer, mousePosition, a, b, c, light, material.main_Color.R, material.main_Color.G, material.main_Color.B);
        }

        public static bool Triangle(ref byte[] frame,ref float[] zBuffer,
            Vector2 old,
            Vector3 v1, Vector3 v2, Vector3 v3,
            Vector2 uv1, Vector2 uv2, Vector2 uv3,
            float light, Texture texture)

        {
            //CalculateLight();//Vector3.Angle(normal, lightDirection) / 180f;
            bool ex = false;
            if (v1.Y > v2.Y) { swapV3(ref v1, ref v2); swapV2(ref uv1, ref uv2); }
            if (v1.Y > v3.Y) { swapV3(ref v1, ref v3); swapV2(ref uv1, ref uv3); }
            if (v2.Y > v3.Y) { swapV3(ref v2, ref v3); swapV2(ref uv2, ref uv3); }

            triangleYHeight = (float)(v3.Y - v1.Y + 1);
            firstSegmentHeight = (float)(v2.Y - v1.Y + 1);
            secondSegmentHeight = (float)(v3.Y - v2.Y + 1);

            for (int y = (int)(v1.Y); y <= v3.Y; y++)
            {
                if (y < 0 | y >= HEIGHT) continue;
                isFirstSegment = y < v2.Y;
                segmentStartY = isFirstSegment ? v1.Y : v2.Y;

                alpha = (y - v1.Y) / triangleYHeight;
                beta = (float)(y - segmentStartY) / (isFirstSegment ? firstSegmentHeight : secondSegmentHeight);
                if (beta < 0) beta = 0f;
                if (alpha < 0) alpha = 0f;
                A = Vector3.Lerp(v1, v3, alpha);
                B = Vector3.Lerp(isFirstSegment ? v1 : v2, isFirstSegment ? v2 : v3, beta);
                uvA = Vector2.Lerp(uv1, uv3, alpha);
                uvB = Vector2.Lerp(isFirstSegment ? uv1 : uv2, isFirstSegment ? uv2 : uv3, beta);

                if (A.X > B.X) swapV3(ref A, ref B);

                for (int x = (int)(A.X); x <= B.X; x++)
                {
                    if (x < 0 | x >= WIDTH) continue;
                    // check extremes
                    delta = (x - A.X) / (B.X - A.X); if (A.X == B.X) delta = 1f;
                    if (delta < 0) delta = 0f;
                    C = Vector3.Lerp(A, B, delta);
                    uvC = Vector2.Lerp(uvA, uvB, delta);
                    int z_id = x + y * WIDTH;
                    if (zBuffer[z_id] <= C.Z)
                    {
                        zBuffer[z_id] = C.Z;
                        if (!ex)
                            ex = (int)(C.X - old.X) == 0 & (int)(C.Y - old.Y) == 0;

                        SetPixel(ref frame, x, y, texture.GetUVCOLOR(uvC.X, 1f - uvC.Y) * light);// );

                    }
                }
            }
            return ex;
        }

        static int z_id = 0;
        static bool ex = false;
        public static bool Triangle(ref byte[] frame, ref float[] zBuffer,
            Vector2 old,
            Vector3 v1, Vector3 v2, Vector3 v3,
            float light, byte CR,byte CG,byte CB)
        {
            ex = false;
            if (v1.Y > v2.Y) swapV3(ref v1, ref v2);
            if (v1.Y > v3.Y) swapV3(ref v1, ref v3);
            if (v2.Y > v3.Y) swapV3(ref v2, ref v3);

            triangleYHeight = (float)(v3.Y - v1.Y + 1);
            firstSegmentHeight = (float)(v2.Y - v1.Y + 1);
            secondSegmentHeight = (float)(v3.Y - v2.Y + 1);

            for (int y = (int)(v1.Y); y <= v3.Y; y++)
            {
                if (y < 0 | y >= HEIGHT) continue;// return ex;
                isFirstSegment = y < v2.Y;
                segmentStartY = isFirstSegment ? v1.Y : v2.Y;

                alpha = (y - v1.Y) / triangleYHeight;
                beta = (float)(y - segmentStartY) / (isFirstSegment ? firstSegmentHeight : secondSegmentHeight);
                if (beta < 0) beta = 0f;
                if (alpha < 0) alpha = 0f;
                A = Vector3.Lerp(v1, v3, alpha);
                B = Vector3.Lerp(isFirstSegment ? v1 : v2, isFirstSegment ? v2 : v3, beta);

                if (A.X > B.X) swapV3(ref A, ref B);

                for (int x = (int)(A.X); x <= B.X; x++)
                {
                    if (x < 0 | x >= WIDTH) continue;
                    // check extremes
                    delta = (x - A.X) / (B.X - A.X); if (A.X == B.X) delta = 1f;
                    if (delta < 0) delta = 0f;
                    C = Vector3.Lerp(A, B, delta);

                    z_id = x + y * WIDTH;
                    if (zBuffer[z_id] <= C.Z)
                    {
                        zBuffer[z_id] = C.Z;
                        if (!ex)
                            ex = (int)(C.X - old.X) == 0 & (int)(C.Y - old.Y) == 0;
                        SetPixel(ref frame, x, y, (byte)(CR * light), (byte)(CG * light), (byte)(CB * light));// );

                    }
                }
            }
            return ex;
        }
        
        public static void SetPixel(ref byte[] frame, int x, int y, byte R, byte G, byte B)
        {
            SetBYTES(R, G, B, 255, ref frame, x * 4 + y * 4 * WIDTH,1);
        }
        public static void SetPixel(ref byte[] frame, int x, int y, byte R, byte G, byte B,int size)
        {
            SetBYTES(R, G, B, 255, ref frame, x * 4 + y * 4 * WIDTH,size);
        }
        public static void SetPixel(ref byte[] frame, int x, int y, Pixel pixel)
        {
            int i = x * 4 + y * 4 * WIDTH;

         // 1 *  SetBYTES(pixel.R, pixel.G, pixel.B, pixel.A, ref fra me-mas, i) =( 1 *  SetBYTES(pixel.R, pixel.G, pixel.B, pixel.A, ref frame, i) ) / 1

            SetBYTES(pixel.R, pixel.G, pixel.B, pixel.A, ref frame, i,1);
        }

        public static byte Recalculate(byte value)
        {
            double steep = 256.0 / 2.0;
            return (byte)(System.Math.Round(value / steep) * steep);
        }
        public static int pixel_size = 1;
        public static void SetBYTES(byte R, byte G, byte B, byte A, ref byte[] frame, int i,int pixel_size)
        {
            if (i < 0 | i > frame.Length - 4) return;

            frame[i] = R;
            frame[i + 1] = G;
            frame[i + 2] = B;
            frame[i + 3] = A;
        }
        

        public static void Line(ref byte[] frame,int size,Vector3 a, Vector3 b, byte R, byte G, byte B)
        {
            float steep = 1f / Vector3.Distance(a, b);
            for (float alpha = 0f; alpha <= 1f; alpha += steep)
            {
                Vector3 c = Vector3.Lerp(a, b, alpha);
                if (c.X > WIDTH | c.Y > HEIGHT | c.X < 0 | c.Y < 0) continue;
                //if (zBuffer[idx] > c.z)
                  SetPixel(ref frame, (int)c.X, (int)c.Y, R, G, B);
            }
        }
        public static bool Line(ref byte[] frame,int size, Vector2 mousePosition, Vector3 a, Vector3 b, byte R, byte G, byte B)
        {
            bool ex = false;
            float steep = 1F / Vector3.Distance(a, b);
            for (float alpha = 0f; alpha <= 1f; alpha += steep)
            {
                Vector3 c = Vector3.Lerp(a, b, alpha);

                if (c.X > WIDTH | c.Y > HEIGHT | c.X < 0 | c.Y < 0) continue;

                if (c.X - size < mousePosition.X & c.X + size > mousePosition.X &
                    c.Y - size < mousePosition.Y & c.Y + size > mousePosition.Y) ex = true;
 
                SetPixel(ref frame, (int)c.X, (int)c.Y, R, G, B,size);

            }
            return ex;
        }
    }
}
