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

namespace QuanLyPhongKhamPhucHoa
{
    public partial class FrmMain : Form
    {
        private string hoTen; // Lưu tên người dùng


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
        }

        private void quanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnBenhNhan_Click(object sender, EventArgs e)
        {

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
    }
}
