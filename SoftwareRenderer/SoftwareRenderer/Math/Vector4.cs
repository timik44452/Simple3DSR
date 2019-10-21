using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareRenderer.Math
{
    public struct Vector4
    {
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

        public float W
        {
            get => w;
            set
            {
                w = value;
                Recalculate();
            }
        }

        public float Length { get => length; }
        public float Summ { get => summ; }
        public float Dot { get => dot; }

        private float 
            x, y, z, w, 
            summ, dot, 
            length;

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;

            summ = dot = length = 0;

            Recalculate();
        }

        
        public static float operator * (Vector4 a, Vector4 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
        }

        public static Vector4 operator *(Vector4 a, Vector3 b)
        {
            a.x *= b.X;
            a.y *= b.Y;
            a.z *= b.Z;

            return a;
        }

        public static Vector4 operator *(Vector4 a, float b)
        {
            a.x *= b;
            a.y *= b;
            a.z *= b;
            a.w *= b;

            return a;
        }
        public override string ToString()
        {
            return $"({x};{y};{z};{w})";
        }

        private void Recalculate()
        {
            summ = x + y + z + w;
            dot = x * y * z * w;
            length = (float)System.Math.Sqrt(x * x + y * y + z * z + w * w);
        }
    }
}
