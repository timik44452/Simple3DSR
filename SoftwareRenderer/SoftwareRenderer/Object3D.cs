using SoftwareRenderer.Math;
using SoftwareRenderer.Renderer;

namespace SoftwareRenderer
{
    public class Object3D
    {
        public TransformedTriangle[] Triangles;
        public Material material;

        public Object3D(Mesh mesh)
        {
            Triangles = new TransformedTriangle[mesh.Triangles.Length];

            for(int i = 0; i < mesh.Triangles.Length; i++)
            {
                Triangles[i] = new TransformedTriangle(mesh.Triangles[i]);
            }
        }

        public void Rotate(Vector3 angle)
        {
            if (angle.X == 0 && angle.Y == 0 && angle.Z == 0)
            {
                return;
            }

            for (int i = 0; i < Triangles.Length; i++)
            {
                Triangles[i].Rotation = Triangles[i].Rotation + angle;
            }

        }
    }
}
