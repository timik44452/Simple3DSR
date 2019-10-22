using System;
using System.Windows.Forms;
using SoftwareRenderer.Renderer;

namespace SoftwareRenderer
{
    public partial class Engine : Form
    {
        private Object3D object3D;
        private Timer rendererTimer;
        private RendererContext context;

        private Math.Vector2 delta;
        private Math.Vector2 oldMouse;

        public Engine()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            context = new RendererContext(Width, Height);
            context.ResetDepthBuffer();
            rendererBox.InitGDI(Width, Height);

            object3D = new Object3D(Primitives.GetPrimitive("Cube"));

            rendererTimer = new Timer();
            rendererTimer.Interval = 1;
            rendererTimer.Tick += OnUpdate;
            rendererTimer.Start();
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            Graphic.Draw(object3D, context);
            rendererBox.Draw(context);
            Text = $"FPS:{1000 / (DateTime.Now - now).TotalMilliseconds}";
        }

        private bool isMouse;
        private void rendererBox_MouseDown(object sender, MouseEventArgs e)
        {
            isMouse = true;
        }

        private void rendererBox_MouseMove(object sender, MouseEventArgs e)
        {
            Math.Vector2 currentMouse = new Math.Vector2(e.X, e.Y);

            delta = currentMouse - oldMouse;
            oldMouse = currentMouse;

            if (isMouse)
            {
                object3D.Rotate(new Math.Vector3(delta.Y, delta.X, 0));
            }
        }

        private void rendererBox_MouseUp(object sender, MouseEventArgs e)
        {
            isMouse = false;
        }

        private void Engine_Resize(object sender, EventArgs e)
        {
            context = new RendererContext(Width, Height);
            context.ResetDepthBuffer();
            rendererBox.InitGDI(Width, Height);
        }
    }
}
