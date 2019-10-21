namespace SoftwareRenderer.Math
{
    public struct Vector2
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

        public float Length { get => length; }
        public float Summ { get => summ; }
        public float Dot { get => dot; }


        private float
            x, y,
            summ, dot,
            length;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;

            summ = dot = length = 0;

            Recalculate();
        }


        public static Vector2 operator +(Vector2 a,Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }
        public static Vector2 operator *(Vector2 a, float b)
        {
            return new Vector2(a.x * b, a.y * b);
        }
        public static Vector2 Lerp(Vector2 uvA, Vector2 uvB, float delta)
        {
            return uvA + (uvB - uvA) * delta;
        }
        public override string ToString()
        {
            return $"({x};{y})";
        }

        private void Recalculate()
        {
            summ = x + y;
            dot = x * y;
            length = (float)System.Math.Sqrt(x * x + y * y);
        }
    }
}
