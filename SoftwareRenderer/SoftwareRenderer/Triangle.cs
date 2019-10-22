using SoftwareRenderer.Math;

namespace SoftwareRenderer
{
    [System.Serializable]
    public struct Triangle
    {
        public Vector3 V0 { get => v0; }
        public Vector3 V1 { get => v1; }
        public Vector3 V2 { get => v2; }

        public Vector2 UV0 { get => uv0; }
        public Vector2 UV1 { get => uv1; }
        public Vector2 UV2 { get => uv2; }

        public Vector3 Normal;

        private Vector3 v0, v1, v2;
        private Vector2 uv0, uv1, uv2;

        public Triangle(
            Vector3 V0, Vector3 V1, Vector3 V2)
        {
            Normal = Vector3.Cross(V0 - V1, V2 - V0);

            v0 = V0;
            v1 = V1;
            v2 = V2;

            uv0 = Vector2.Zero;
            uv1 = Vector2.Zero;
            uv2 = Vector2.Zero;
        }

        public Triangle(
            Vector3 V0, Vector3 V1, Vector3 V2,
            Vector2 UV0, Vector2 UV1, Vector2 UV2)
        {
            Normal = Vector3.Cross(V0 - V1, V2 - V0);

            v0 = V0;
            v1 = V1;
            v2 = V2;

            uv0 = UV0;
            uv1 = UV1;
            uv2 = UV2;
        }
    }
}
