using System;
using System.Windows.Forms;
using SoftwareRenderer.Renderer;

namespace SoftwareRenderer
{
    public partial class Engine : Form
    {
        private Mesh mesh;
        private Timer rendererTimer;
        private RendererContext context;

        public Engine()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            context = new RendererContext();
            context.Width = Width;
            context.Height = Height;
            context.Buffer = new int[context.Width * context.Height];

            rendererBox.InitGDI();

            rendererTimer = new Timer();
            rendererTimer.Interval = 1;
            rendererTimer.Tick += OnUpdate;
            rendererTimer.Start();
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            Graphic.Draw(mesh, context);
            rendererBox.Draw(context);
        }
    }
}
