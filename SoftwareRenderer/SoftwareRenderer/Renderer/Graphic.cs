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
                Rasterize.Triangle(object3D.Triangles[i], context, 1, null);
            }
        }
    }
}
