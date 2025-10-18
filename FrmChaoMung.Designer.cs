namespace QuanLyPhongKhamPhucHoa
{
    partial class FrmChaoMung
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChaoMung));
            PB_Welcome = new Guna.UI2.WinForms.Guna2ProgressBar();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // PB_Welcome
            // 
            PB_Welcome.CustomizableEdges = customizableEdges1;
            PB_Welcome.Location = new Point(-4, 438);
            PB_Welcome.Name = "PB_Welcome";
            PB_Welcome.ProgressColor = Color.Red;
            PB_Welcome.ProgressColor2 = Color.FromArgb(192, 0, 0);
            PB_Welcome.ShadowDecoration.CustomizableEdges = customizableEdges2;
            PB_Welcome.Size = new Size(810, 15);
            PB_Welcome.TabIndex = 1;
            PB_Welcome.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            PB_Welcome.ValueChanged += PB_Welcome_ValueChanged;
            PB_Welcome.Click += PB_Welcome_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.FrmWelCome_PHUCHOA;
            pictureBox1.Location = new Point(-4, -7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(810, 445);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            // 
            // FrmChaoMung
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PB_Welcome);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmChaoMung";
            Text = "FrmChaoMung";
            Load += FrmChaoMung_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2ProgressBar PB_Welcome;
        private PictureBox pictureBox1;
    }
}