namespace SoftwareRenderer
{
    partial class Engine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rendererBox = new SoftwareRenderer.RendererBox();
            this.SuspendLayout();
            // 
            // rendererBox
            // 
            this.rendererBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rendererBox.Location = new System.Drawing.Point(0, 0);
            this.rendererBox.Name = "rendererBox";
            this.rendererBox.Size = new System.Drawing.Size(624, 441);
            this.rendererBox.TabIndex = 0;
            this.rendererBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rendererBox_MouseDown);
            this.rendererBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rendererBox_MouseMove);
            this.rendererBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rendererBox_MouseUp);
            // 
            // Engine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.rendererBox);
            this.Name = "Engine";
            this.Text = "Engine";
            this.Load += new System.EventHandler(this.OnLoad);
            this.Resize += new System.EventHandler(this.Engine_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private RendererBox rendererBox;
    }
}