using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; // Thêm namespace này
namespace QuanLyPhongKhamPhucHoa
{
    public partial class FrmMain : Form
    {
        private string hoTen; // Lưu tên người dùng
                              // 📌 Import 2 hàm WinAPI
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        private Size originalFormSize;
        private Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();


        public FrmMain(string hoTenNguoiDung)
        {
            InitializeComponent();
            this.hoTen = hoTenNguoiDung; // Gán tên từ form đăng nhập

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Hiển thị tên người dùng
            if (!string.IsNullOrEmpty(hoTen))
                label1.Text = $"Xin chào, {hoTen}!";
            else
                label1.Text = "Xin chào!";

            // Lưu kích thước gốc của form
            originalFormSize = this.Size;

            // Lưu vị trí và kích thước gốc của các control
            foreach (Control ctrl in this.Controls)
            {
                originalControlBounds[ctrl] = ctrl.Bounds;
            }
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMaximize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;

        }

        // Hàm resize các control theo tỉ lệ
        private void ResizeControls()
        {
            float ratioX = (float)this.Width / originalFormSize.Width;
            float ratioY = (float)this.Height / originalFormSize.Height;

            foreach (Control ctrl in this.Controls)
            {
                Rectangle r = originalControlBounds[ctrl];
                ctrl.SetBounds(
                    (int)(r.X * ratioX),
                    (int)(r.Y * ratioY),
                    (int)(r.Width * ratioX),
                    (int)(r.Height * ratioY)
                );
            }
        }

        private void quanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnBenhNhan_Click(object sender, EventArgs e)
        {
            frmBenhNhan bn = new frmBenhNhan();
            bn.Show();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }



        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

            // Ẩn form hiện tại
            this.Hide();

            // Tạo form đăng nhập mới
            FrmDangNhap frm = new FrmDangNhap();

            // Hiển thị form đăng nhập
            frm.Show();

            // (Tuỳ chọn) Đóng form hiện tại sau khi mở FrmDangNhap
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLichKham_Click(object sender, EventArgs e)
        {
            FrmLichKham lk = new FrmLichKham();
            lk.Show();
        }

        private void btnKhamBenh_Click(object sender, EventArgs e)
        {

        }

        private void btnDonThuoc_Click(object sender, EventArgs e)
        {

        }

        private void btnThuoc_Click(object sender, EventArgs e)
        {

        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture(); // Giải phóng capture chuột hiện tại
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0); // Gửi lệnh kéo form
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaximize.Text = "🗗";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                btnMaximize.Text = "☐";
            }

            ResizeControls(); // resize các control theo tỉ lệ
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }
    }
}
