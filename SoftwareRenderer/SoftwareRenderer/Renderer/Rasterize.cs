using System;
using System.Drawing;
using SoftwareRenderer.Math;

namespace SoftwareRenderer.Renderer
{
    public class Rasterize
    {

        public static void WireTriangle(
            TransformedTriangle triangle,
            RendererContext context)
        {
            Line(triangle.V0, triangle.V1, context);
            Line(triangle.V0, triangle.V2, context);
            Line(triangle.V1, triangle.V2, context);
        }

        public static void Triangle(
            TransformedTriangle triangle,
            RendererContext context,
            float light, Material material)

        {
            int IL = (int)(255 * light);
            IL = IL << 16 | IL << 8 | IL;

            float triangleYHeight = triangle.V2.Y - triangle.V0.Y + 1;
            float firstSegmentHeight = triangle.V1.Y - triangle.V0.Y + 1;
            float secondSegmentHeight = triangle.V2.Y - triangle.V1.Y + 1;

            for (int y = (int)triangle.V0.Y; y <= triangle.V2.Y; y++)
            {
                if (y < 0 | y >= context.Height) continue;

                bool isFirstSegment = y < triangle.V1.Y;
                float segmentStartY = isFirstSegment ? triangle.V0.Y : triangle.V1.Y;

                float alpha = (y - triangle.V0.Y) / triangleYHeight;
                float beta = (y - segmentStartY) / (isFirstSegment ? firstSegmentHeight : secondSegmentHeight);

                if (beta < 0) beta = 0f;
                if (alpha < 0) alpha = 0f;

                Vector3 A = Vector3.Lerp(triangle.V0, triangle.V2, alpha);
                Vector3 B = Vector3.Lerp(isFirstSegment ? triangle.V0 : triangle.V1, isFirstSegment ? triangle.V1 : triangle.V2, beta);
                
                Vector2 uvA = Vector2.Lerp(triangle.UV0, triangle.UV2, alpha);
                Vector2 uvB = Vector2.Lerp(isFirstSegment ? triangle.UV0 : triangle.UV1, isFirstSegment ? triangle.UV1 : triangle.UV2, beta);

                if (A.X > B.X) Vector3.Swap(ref A, ref B);

                for (int x = (int)(A.X); x <= B.X; x++)
                {
                    if (x < 0 | x >= context.Width) continue;
                    
                    float delta = (x - A.X) / (B.X - A.X); 
                    if (A.X == B.X) delta = 1f;
                    if (delta < 0) delta = 0f;

                    Vector3 C = Vector3.Lerp(A, B, delta);
                    Vector2 uvC = Vector2.Lerp(uvA, uvB, delta);

                    int bufferIndex = x + y * context.Width;

                    if (context.depthBuffer[bufferIndex] <= C.Z)
                    {
                        context.depthBuffer[bufferIndex] = C.Z;
                        context.Buffer[bufferIndex] = IL;
                    }
                }
            }
        }
        public static void Line(Vector3 a, Vector3 b, RendererContext context)
        {
            int IL = 255;
            float steep = 1F / (a - b).Length;

            IL = IL << 16 | IL << 8 | IL;


            for (float alpha = 0; alpha <= 1F; alpha += steep)
            {
                Vector3 C = Vector3.Lerp(a, b, alpha);

                int bufferIndex = (int)(C.X + C.Y * context.Width);

                if (context.depthBuffer[bufferIndex] <= C.Z)
                {
                    context.depthBuffer[bufferIndex] = C.Z;
                    context.Buffer[bufferIndex] = IL;
                }
            }
        }
    }
}
