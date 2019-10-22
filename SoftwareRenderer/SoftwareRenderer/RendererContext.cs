using System;

namespace SoftwareRenderer
{
    public class RendererContext
    {
        public static RendererContext CurrentContext;

        public int[] Buffer;
        public float[] depthBuffer;

        public int Width;
        public int Height;
        public Math.Vector2 Size;

        public RendererContext(int Width, int Height)
        {
            Size = new Math.Vector2(Width, Height);
            Buffer = new int[Width * Height];
            depthBuffer = new float[Width * Height];

            this.Width = Width;
            this.Height = Height;

            CurrentContext = this;
        }
        public void ResetDepthBuffer()
        {
            for (int i = 0; i < depthBuffer.Length; i++)
                depthBuffer[i] = float.MinValue;
        }

        public void ResetBuffers()
        {
            for (int i = 0; i < depthBuffer.Length; i++)
            {
                Buffer[i] = 0;
                depthBuffer[i] = float.MinValue;
            }
        }
    }
}
