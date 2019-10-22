using SoftwareRenderer.Math;

namespace SoftwareRenderer
{
    public class TransformedTriangle
    {
        public Vector3 Rotation
        {
            get => eulerRotation;
            set
            {
                if (!eulerRotation.Equals(value))
                {
                    eulerRotation = value;
                    rotation = eulerRotation / 180F * (float)System.Math.PI;
                    RecalculateView();
                }
            }
        }

        public Vector3 V0 { get => tv0; }
        public Vector3 V1 { get => tv1; }
        public Vector3 V2 { get => tv2; }

        public Vector2 UV0 { get => tuv0; }
        public Vector2 UV1 { get => tuv1; }
        public Vector2 UV2 { get => tuv2; }


        private Vector3 rotation;
        private Vector3 eulerRotation;

        private Vector3 tv0, tv1, tv2;
        private Vector2 tuv0, tuv1, tuv2;

        private Vector3 v0, v1, v2;
        private Vector2 uv0, uv1, uv2;
        private Vector3 normal;

        public TransformedTriangle(Triangle triangle)
        {
            v0 = triangle.V0;
            v1 = triangle.V1;
            v2 = triangle.V2;

            uv0 = triangle.UV0;
            uv1 = triangle.UV1;
            uv2 = triangle.UV2;

            normal = triangle.Normal;

            RecalculateView();
        }


        private void RecalculateView()
        {
            Matrix4x4 viewMatrix = Matrix4x4.ModelMatrix(RendererContext.CurrentContext.Size, rotation);

            tv0 = viewMatrix.Multiply(v0);
            tv1 = viewMatrix.Multiply(v1);
            tv2 = viewMatrix.Multiply(v2);

            if (tv0.Y > tv1.Y) { Vector3.Swap(ref tv0, ref tv1); Vector2.Swap(ref tuv0, ref tuv1); }
            if (tv0.Y > tv2.Y) { Vector3.Swap(ref tv0, ref tv2); Vector2.Swap(ref tuv0, ref tuv2); }
            if (tv1.Y > tv2.Y) { Vector3.Swap(ref tv1, ref tv2); Vector2.Swap(ref tuv1, ref tuv2); }
        }
    }
}
