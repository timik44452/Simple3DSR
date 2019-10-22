using System;
using SoftwareRenderer.GDI;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SoftwareRenderer
{
    public partial class RendererBox : UserControl
    {
        private bool isInitialized;

        private BITMAPINFO info;
        private HandleRef handle;

        private int width;
        private int height;

        public RendererBox()
        {
            InitializeComponent();
        }

        public void InitGDI(int Width, int Height)
        {
            try
            {
                var graphics = CreateGraphics();

                width = Width;
                height = Height;

                info = GDIHelper.CreateBitmapinfo(width, height);
                handle = new HandleRef(graphics, graphics.GetHdc());

                isInitialized = true;
            }
            catch(Exception e)
            {

            }
        }

        public void Draw(RendererContext context)
        {
            if(!isInitialized)
            {
                return;
            }

            GDIHelper.SetDIBitsToDevice(handle, 0, 0, width, height, 0, 0, 0, height, ref context.Buffer[0], ref info, 0);
        }
    }
}
