using SoftwareRenderer.Math;

namespace SoftwareRenderer
{
    [System.Serializable]
    public class MeshSerializationContainer
    {
        public Vector3[] Normals;
        public Vector3[] Vertices;
        public Vector2[] UVs;

        public MeshSerializationContainer()
        {

        }

        public MeshSerializationContainer(Mesh mesh)
        {
            Normals = new Vector3[mesh.Triangles.Length];
            Vertices = new Vector3[mesh.Triangles.Length * 3];
            UVs = new Vector2[mesh.Triangles.Length * 3];

            for(int i = 0; i < mesh.Triangles.Length; i++)
            {
                Normals[i] = mesh.Triangles[i].Normal;

                Vertices[i * 3] = mesh.Triangles[i].V0;
                Vertices[i * 3 + 1] = mesh.Triangles[i].V1;
                Vertices[i * 3 + 2] = mesh.Triangles[i].V2;

                UVs[i * 3] = mesh.Triangles[i].UV0;
                UVs[i * 3 + 1] = mesh.Triangles[i].UV1;
                UVs[i * 3 + 2] = mesh.Triangles[i].UV2;
            }
        }

        public Mesh ToMesh()
        {
            int trisCount = Vertices.Length / 3;

            Triangle[] triangles = new Triangle[trisCount];

            for(int i = 0; i < Vertices.Length; i+=3)
            {
                Vector3 V0 = Vertices[i];
                Vector3 V1 = Vertices[i + 1];
                Vector3 V2 = Vertices[i + 2];

                Vector2 UV0 = UVs[i];
                Vector2 UV1 = UVs[i + 1];
                Vector2 UV2 = UVs[i + 2];

                Triangle triangle = new Triangle(V0, V1, V2, UV0, UV1, UV2);
                triangle.Normal = Normals[i / 3];

                triangles[i / 3] = triangle;
            }

            Mesh mesh = new Mesh();

            mesh.SetTriangles(triangles);

            return mesh;
        }
    }
}
