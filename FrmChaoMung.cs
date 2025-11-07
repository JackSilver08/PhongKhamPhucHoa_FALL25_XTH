using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuanLyPhongKhamPhucHoa
{
    public partial class FrmChaoMung : Form
    {
        private System.Windows.Forms.Timer timer;  // Timer của WinForms
        private int progressValue = 0;             // Biến để đếm tiến trình


        // 📌 Import 2 hàm WinAPI cho phép kéo form
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public FrmChaoMung()
        {
            InitializeComponent();

            // Sự kiện khi giữ chuột trên form
            this.MouseDown += new MouseEventHandler(Form_MouseDown);

        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }


        private void FrmChaoMung_Load(object sender, EventArgs e)
        {

            PB_Welcome.Minimum = 0;
            PB_Welcome.Maximum = 100;
            PB_Welcome.Value = 0;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 20; // ⏱ mỗi 20ms
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            progressValue += 5; // tăng nhanh hơn
            if (progressValue > 100) progressValue = 100;
            PB_Welcome.Value = progressValue;

            if (progressValue >= 100)
            {
                timer.Stop();
                FrmDangNhap frm = new FrmDangNhap();
                frm.Show();
                this.Hide();
            }
        }

        private void PB_Welcome_Click(object sender, EventArgs e)
        {
            // Bạn có thể cho click chuột bỏ qua màn chào nếu muốn
            timer.Stop();
            FrmDangNhap frm = new FrmDangNhap();
            frm.Show();
            this.Hide();
        }

        private void PB_Welcome_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }
    }
}
