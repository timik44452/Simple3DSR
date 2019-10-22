
namespace SoftwareRenderer.Math
{
    [System.Serializable]
    public struct Vector3
    {
        public static Vector3 Zero { get { return new Vector3(0, 0, 0); } }
        public static Vector3 One { get { return new Vector3(1, 1, 1); } }
        public static Vector3 Up { get { return new Vector3(0,1,0);} }

        public float X
        {
            get => x;
            set
            {
                x = value;
                Recalculate();
            }
        }

        public float Y
        {
            get => y;
            set
            {
                y = value;
                Recalculate();
            }
        }

        public float Z
        {
            get => z;
            set
            {
                z = value;
                Recalculate();
            }
        }

        public float Length { get => length; }
        public float Summ { get => summ; }
        public float Dot { get => dot; }

        public Vector4 getVector4 { get { return new Vector4(x,y,z,1); } }


        private float 
            x, y, z,
            summ, dot,
            length;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;

            summ = dot = length = 0;

            Recalculate();
        }

        public static float Angle(Vector3 a,Vector3 b)
        {
            if (a.Length != 0 & b.Length != 0)
                return (float)(System.Math.Acos((a * b) / (a.Length * b.Length)) * 180f / System.Math.PI);
            else
                return 0;
        }

        public static Vector3 Cross(Vector3 left, Vector3 right)
        {
            Vector3 returnValue = Zero;

            returnValue.x = left.y * right.z - left.z * right.y;
            returnValue.y = left.z * right.x - left.x * right.z;
            returnValue.z = left.x * right.y - left.y * right.x;

            return returnValue;
        }


        public static void Swap(ref Vector3 a, ref Vector3 b)
        {
            Vector3 buffer = a;
            a = b;
            b = buffer;
        }
        

        public static float Distance(Vector3 a, Vector3 b)
        {
            return (a - b).Length;
        }
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3 operator *(Vector3 a, float b)
        {
            return new Vector3(a.x * b, a.y * b, a.z * b);
        }
        public static Vector3 operator /(Vector3 a, float b)
        {
            return new Vector3(a.x / b, a.y / b, a.z / b);
        }
        public static float operator *(Vector3 a, Vector3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }
        public static Vector3 operator &(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x , a.y * b.y , a.z * b.z);
        }
        public static Vector3 Lerp(Vector3 a, Vector3 b, float alpha)
        {
            a.x += (b.x - a.x) * alpha;
            a.y += (b.y - a.y) * alpha;
            a.z += (b.z - a.z) * alpha;

            a.Recalculate();

            return a;
        }

        public override string ToString()
        {
            return $"({x};{y};{z})";
        }

        private void Recalculate()
        {
            summ = x + y + z;
            dot = x * y * z;
            length = (float)System.Math.Sqrt(x * x + y * y + z * z);
        }

        public override bool Equals(object obj)
        {
            return obj is Vector3 vector &&
                   x == vector.x &&
                   y == vector.y &&
                   z == vector.z;
        }
    }
}
