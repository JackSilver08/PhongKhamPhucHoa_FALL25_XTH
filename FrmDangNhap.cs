using Microsoft.Data.SqlClient;

namespace QuanLyPhongKhamPhucHoa
{
    public partial class FrmDangNhap : Form
    {
        public static string TenDangNhapHienTai = string.Empty;

        public FrmDangNhap()
        {
            InitializeComponent();


        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Bạn có chắc muốn thoát chương trình không?",
        "Xác nhận thoát",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

            if (result == DialogResult.No)
            {
                e.Cancel = true; // ❌ Hủy việc đóng form
            }
            else
            {
                // ✅ Cho phép đóng form, hoặc làm thêm hành động khác
                // Ví dụ: lưu dữ liệu, ngắt kết nối DB...
                MessageBox.Show("Hẹn gặp lại!");
            }
        }

        private void txtQMK_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkQMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Ẩn/hiện textbox khi nhấn link
            txtQMK.Visible = !txtQMK.Visible;

            if (txtQMK.Visible)
            {
                txtQMK.Focus();
            }
        }

        private void txtTenTK_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMK_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenTK.Text.Trim();
            string matKhau = txtMK.Text.Trim();
            string email = txtQMK.Text.Trim();

            if (string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "Server=localhost;Database=PhongKhamPhucHoa;Trusted_Connection=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Nếu người dùng nhập email => đang quên mật khẩu
                    if (!string.IsNullOrEmpty(email))
                    {
                        string qmkQuery = "SELECT * FROM NhanVien WHERE TenDangNhap = @TenDangNhap AND Email = @Email";
                        using (SqlCommand cmd = new SqlCommand(qmkQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                            cmd.Parameters.AddWithValue("@Email", email);

                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                string hoTen = reader["HoTen"].ToString();
                                string matKhauCu = reader["MatKhauHash"].ToString();

                                // ✅ Lưu lại tên đăng nhập hiện tại
                                TenDangNhapHienTai = tenDangNhap;

                                MessageBox.Show($"Xin chào {hoTen}!\n\nMật khẩu của bạn là: {matKhauCu}", "Quên mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Tên đăng nhập hoặc email không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        return; // Dừng lại, không chạy tiếp phần đăng nhập
                    }

                    // Ngược lại: thực hiện đăng nhập bình thường
                    if (string.IsNullOrEmpty(matKhau))
                    {
                        MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string query = "SELECT * FROM NhanVien WHERE TenDangNhap = @TenDangNhap AND MatKhauHash = @MatKhauHash AND IsActive = 1";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                        cmd.Parameters.AddWithValue("@MatKhauHash", matKhau);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            string hoTen = reader["HoTen"].ToString();
                            string vaiTroId = reader["VaiTroId"].ToString();

                            MessageBox.Show($"Đăng nhập thành công!\nXin chào, {hoTen} ({vaiTroId})",
                                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Hide();

                            // ✅ Gọi FrmMain và truyền tên người dùng vào
                            FrmMain frm = new FrmMain(hoTen);
                            frm.ShowDialog();

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
