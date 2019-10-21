using SoftwareRenderer.Renderer;

namespace SoftwareRenderer.Renderer
{
    public static class Graphic
    {
        public static void Draw(Mesh mesh, RendererContext context)
        {
            throw new System.NotImplementedException();

            if (mesh == null)
            {
                return;
            }
        
            for(int i = 0; i < mesh.Triangles.Length; i++)
            {
                Triangle triangle = mesh.Triangles[i];

            }
        }
    }
}
