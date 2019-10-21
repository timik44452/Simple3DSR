namespace SoftwareRenderer.Renderer
{
    public struct Pixel
    {
        public byte R, G, B, A;
        public static Pixel White { get { return new Pixel(255,255,255);} }
        public static Pixel Gray { get { return new Pixel(127, 127, 127); } }
        public int summ { get { return (int)(R + G + B); } }
       
        public Pixel(byte r,byte g,byte b,byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
        public Pixel(int r, int g, int b, int a)
        {
            R = (byte)r;
            G = (byte)g;
            B = (byte)b;
            A = (byte)a;
        }
        public Pixel(byte r,byte g,byte b)
        {
            R = r; 
            G = g;
            B = b;
            A = 255;
        }
        public static Pixel operator * (Pixel a,float b)
        {
            return new Pixel((byte)(a.R * b), (byte)(a.G * b), (byte)(a.B * b),a.A);
        }
        public void FROMRGB(byte r,byte g,byte b,byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
}
