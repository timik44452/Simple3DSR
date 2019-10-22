using SoftwareRenderer.Math;

namespace SoftwareRenderer
{
    [System.Serializable]
    public class Mesh
    {
        public Triangle[] Triangles;

        public void SetTriangles(params Triangle[] triangles)
        {
            Triangles = triangles;
        }
    }
}
