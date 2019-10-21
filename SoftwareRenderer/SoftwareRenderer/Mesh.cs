using SoftwareRenderer.Math;

namespace SoftwareRenderer
{
    public class Mesh
    {
        public Triangle[] Triangles { get => triangles; }
        public Vector3[] Vertices { get => vertices; }
        public Vector3[] Normals { get => normals; }
        public Vector2[] UVs { get => uvs; }

        private Triangle[] triangles;
        private Vector3[] vertices;
        private Vector3[] normals;
        private Vector2[] uvs;

    }
}
