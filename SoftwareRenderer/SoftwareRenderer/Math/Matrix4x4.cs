namespace SoftwareRenderer.Math
{
    public struct Matrix4x4
    {
        public Vector4 line1 { get; set; }
        public Vector4 line2 { get; set; }
        public Vector4 line3 { get; set; }
        public Vector4 line4 { get; set; }

        public Vector4 column1 { get { return new Vector4(line1.X, line2.X, line3.X, line4.X); } }
        public Vector4 column2 { get { return new Vector4(line1.Y, line2.Y, line3.Y, line4.Y); } }
        public Vector4 column3 { get { return new Vector4(line1.Z, line2.Z, line3.Z, line4.Z); } }
        public Vector4 column4 { get { return new Vector4(line1.W, line2.W, line3.W, line4.W); } }

        public Vector4 getVertices { get { return new Vector4(line1.Summ,line2.Summ,line3.Summ,line4.Summ); } }
        public Vector3 getProj { get { return new Vector3(line1.Summ, line2.Summ, line3.Summ) * line4.Summ; } }
        public Vector3 getIso { get { return new Vector3(line1.Summ, line2.Summ, line3.Summ); } }

        public Vector3 getColumns { get { return new Vector3(column1.Summ, column2.Summ, column3.Summ); } }
        public Matrix4x4(float a11, float a21, float a31, float a41,
                                float a12, float a22, float a32, float a42,
                                float a13, float a23, float a33, float a43,
                                float a14, float a24, float a34, float a44)
        {
            line1 = new Vector4(a11, a21, a31, a41);
            line2 = new Vector4(a12, a22, a32, a42);
            line3 = new Vector4(a13, a23, a33, a43);
            line4 = new Vector4(a14, a24, a34, a44);
        }
        public Matrix4x4(Vector4 l1,Vector4 l2,Vector4 l3,Vector4 l4)
        {
            line1 = l1;
            line2 = l2;
            line3 = l3;
            line4 = l4;
        }
        public static Matrix4x4 idenity
        {
            get
            {
                return new Matrix4x4(
                 1, 0, 0, 0,
                 0, 1, 0, 0,
                 0, 0, 1, 0,
                 0, 0, 0, 1);
            }
        }
        public static Matrix4x4 operator *(Matrix4x4 a,Matrix4x4 b)
        {
            return new Matrix4x4(a.line1 * b.column1,a.line1 * b.column2,a.line1 * b.column3, a.line1 * b.column4,
                                 a.line2 * b.column1,a.line2 * b.column2,a.line2 * b.column3, a.line2 * b.column4,
                                 a.line3 * b.column1,a.line3 * b.column2,a.line3 * b.column3, a.line3 * b.column4,
                                 a.line4 * b.column1,a.line4 * b.column2,a.line4 * b.column3, a.line4 * b.column4
                                 );
        }
        public static Matrix4x4 operator *(Matrix4x4 a,float b)
        {
            return new Matrix4x4(a.line1.X * b, a.line1.Y * b, a.line1.Z * b, a.line1.W * b,
                                 a.line2.X * b, a.line2.Y * b, a.line2.Z * b, a.line2.W * b,
                                 a.line3.X * b, a.line3.Y * b, a.line3.Z * b, a.line3.W * b,
                                 a.line4.X * b, a.line4.Y * b, a.line4.Z * b, a.line4.W * b);
        }
        public static Matrix4x4 operator *(Matrix4x4 a, Vector4 b)
        {
            return new Matrix4x4(a.line1.X * b.X, a.line1.Y * b.Y, a.line1.Z * b.Z, a.line1.W * b.W,
                                 a.line2.X * b.X, a.line2.Y * b.Y, a.line2.Z * b.Z, a.line2.W * b.W,
                                 a.line3.X * b.X, a.line3.Y * b.Y, a.line3.Z * b.Z, a.line3.W * b.W,
                                 a.line4.X * b.X, a.line4.Y * b.Y, a.line4.Z * b.Z, a.line4.W * b.W);
        }
        public static Vector3 operator *(Vector3 a,Matrix4x4 b)
        {
            return (b * a.getVector4).getColumns;
        }
        public static float cos, sin;
        public static Matrix4x4 X_Matrix(float angle)
        {
            //angle = angle * (float)Math.PI / 180f;
            cos = (float)System.Math.Cos(angle);
            sin = (float)System.Math.Sin(angle);
            return new Matrix4x4(1, 0, 0,0,
                                 0, cos, sin,0,
                                 0, -sin, cos,0,
                                 0,0,0,1);
        }
        public static Matrix4x4 Y_Matrix(float angle)
        {
            //angle = angle * (float)Math.PI / 180f;
            cos = (float)System.Math.Cos(angle);
            sin = (float)System.Math.Sin(angle);
            return new Matrix4x4(cos, 0, -sin,0,
                                 0, 1, 0,0,
                                 sin, 0, cos,0,
                                 0,0,0,1);
        }
        public static Matrix4x4 Z_Matrix(float angle)
        {
            //angle = angle * (float)Math.PI / 180f;
            cos = (float)System.Math.Cos(angle);
            sin = (float)System.Math.Sin(angle);

            return new Matrix4x4(cos, sin, 0,0,
                                 -sin, cos, 0,0,
                                 0, 0, 1,0,
                                 0,0,0,1);
        }
        public static Matrix4x4 W_Matrix(float angle)
        {
            //angle = angle * (float)Math.PI / 180f;
            cos = (float)System.Math.Cos(angle);
            sin = (float)System.Math.Sin(angle);

            return new Matrix4x4(1, 0, 0, 0,
                                 0, 1, 0, 0,
                                 0, 0, cos, sin,
                                 0, 0, -sin, cos);
        }
        public Matrix4x4 dot(Vector3 value)
        {
            return new Matrix4x4(line1 * value.X, line2 * value.Y, line3 * value.Z, line4);
        }

        public static Matrix4x4 modelMatrix(Vector3 point,Vector3 rotation,Vector3 scale)
        {
            rotation = rotation * (float)System.Math.PI / 180F;

            return Z_Matrix(rotation.Z) * Y_Matrix(rotation.Y) * X_Matrix(rotation.X) * point.getVector4 * scale.getVector4;
        }
        
        
    }
}
