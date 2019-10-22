using SoftwareRenderer.Math;

namespace SoftwareRenderer.Renderer
{
    public static class Graphic
    {
        public static void Draw(Object3D object3D, RendererContext context)
        {
            if (object3D == null || context == null)
            {
                return;
            }

            context.ResetBuffers();

            for (int i = 0; i < object3D.Triangles.Length; i++)
            {
                float light = Vector3.Angle(Vector3.Forward, object3D.Triangles[i].Normal) / 180F;
                Rasterize.Triangle(object3D.Triangles[i], context, light, object3D.material);
            }
        }
    }
}
