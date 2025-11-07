using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuanLyPhongKhamPhucHoa
{

    public partial class frmBenhNhan : Form
    {
        private string connStr = "Server=localhost;Database=PhongKhamPhucHoa;Trusted_Connection=True;TrustServerCertificate=True;";
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public frmBenhNhan()
        {

            InitializeComponent();
            NapBenhNhan();
            cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" });
        }
        private void NapBenhNhan()
        {
            string sql = "SELECT BenhNhanId, HoTen, GioiTinh, NgaySinh, DienThoai, DiaChi, Email, GhiChu FROM BenhNhan ORDER BY BenhNhanId ASC";
            SqlDataAdapter da = new SqlDataAdapter(sql, connStr);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // ✅ Thêm cột hiển thị chữ Nam / Nữ
            dt.Columns.Add("GioiTinhText", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                // Nếu bạn lưu 1 = Nam, 2 = Nữ
                var gtValue = row["GioiTinh"]?.ToString();
                if (gtValue == "1")
                    row["GioiTinhText"] = "Nam";
                else if (gtValue == "2")
                    row["GioiTinhText"] = "Nữ";
                else
                    row["GioiTinhText"] = "Không rõ";
            }

            dgvBenhNhan.DataSource = dt;

            // Ẩn cột mã giới tính gốc
            dgvBenhNhan.Columns["GioiTinh"].Visible = false;

            // ✅ Đặt lại tiêu đề các cột
            dgvBenhNhan.Columns["BenhNhanId"].HeaderText = "Mã bệnh nhân";
            dgvBenhNhan.Columns["HoTen"].HeaderText = "Họ tên";
            dgvBenhNhan.Columns["GioiTinhText"].HeaderText = "Giới tính";
            dgvBenhNhan.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvBenhNhan.Columns["DienThoai"].HeaderText = "Số điện thoại";
            dgvBenhNhan.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvBenhNhan.Columns["Email"].HeaderText = "Email";
            dgvBenhNhan.Columns["GhiChu"].HeaderText = "Ghi chú";
        }

        // Làm mới form
        private void LamMoi()
        {
            txtMaBenhNhan.Text = "";
            txtHoTen.Text = "";
            cboGioiTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now;
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtGhiChu.Text = "";
            dgvBenhNhan.ClearSelection();
            txtMaBenhNhan.Enabled = true;
        }

        private void dgvBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridViewRow row = dgvBenhNhan.Rows[e.RowIndex];

            txtMaBenhNhan.Text = row.Cells["BenhNhanId"].Value?.ToString();
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
            cboGioiTinh.Text = (Convert.ToInt32(row.Cells["GioiTinh"].Value) == 1) ? "Nam" : "Nữ";
            dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
            txtSDT.Text = row.Cells["DienThoai"].Value?.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
            txtMaBenhNhan.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            if (!IsValidPhone(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! (phải bắt đầu bằng 0 và có đúng 10 số)");
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ! Vui lòng nhập đúng định dạng (vd: ten@gmail.com)");
                return;
            }
            string sql = @"INSERT INTO BenhNhan (HoTen, GioiTinh, NgaySinh, DienThoai, DiaChi, Email, CreatedAt, GhiChu)
                           VALUES (@HoTen, @GioiTinh, @NgaySinh, @DienThoai, @DiaChi, @Email, GETDATE(), @GhiChu)";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@GioiTinh", cboGioiTinh.Text == "Nam" ? 1 : 0);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@DienThoai", txtSDT.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);

                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        NapBenhNhan();
                        LamMoi();
                        MessageBox.Show("Thêm bệnh nhân thành công.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm: " + ex.Message);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            if (!IsValidPhone(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! (phải bắt đầu bằng 0 và có đúng 10 số)");
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ! Vui lòng nhập đúng định dạng (vd: ten@gmail.com)");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMaBenhNhan.Text))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân để sửa.");
                return;
            }

            string sql = @"UPDATE BenhNhan 
                           SET HoTen=@HoTen, GioiTinh=@GioiTinh, NgaySinh=@NgaySinh, 
                               DienThoai=@DienThoai, DiaChi=@DiaChi, Email=@Email, GhiChu=@GhiChu
                           WHERE BenhNhanId=@BenhNhanId";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@BenhNhanId", Convert.ToInt64(txtMaBenhNhan.Text));
                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@GioiTinh", cboGioiTinh.Text == "Nam" ? 1 : 0);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@DienThoai", txtSDT.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);

                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        NapBenhNhan();
                        LamMoi();
                        MessageBox.Show("Cập nhật bệnh nhân thành công.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaBenhNhan.Text))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân để xóa.");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa bệnh nhân này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string sql = "DELETE FROM BenhNhan WHERE BenhNhanId=@BenhNhanId";

                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@BenhNhanId", Convert.ToInt64(txtMaBenhNhan.Text));

                    try
                    {
                        conn.Open();
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            NapBenhNhan();
                            LamMoi();
                            MessageBox.Show("Xóa thành công.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            string tuKhoa = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                NapBenhNhan();
            }

            string sql = "SELECT * FROM BenhNhan WHERE HoTen LIKE @TuKhoa ORDER BY BenhNhanID ASC";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dgvBenhNhan.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bệnh nhân nào khớp với từ khóa!");
                        dgvBenhNhan.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            // You can leave it empty for now, or trigger search as you like
            // Example: call btnTimKiem_Click(null, null);
            // Gọi tìm kiếm ngay khi gõ
            btnTimKiem_Click(null, null);
        }

        // 🧩 Kiểm tra email hợp lệ
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            return System.Text.RegularExpressions.Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }

        // 🧩 Kiểm tra số điện thoại hợp lệ (bắt đầu bằng 0 và đúng 10 số)
        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            return System.Text.RegularExpressions.Regex.IsMatch(phone, @"^0\d{9}$");
        }

        // 🧩 Hàm kiểm tra dữ liệu đầu vào
        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            if (!IsValidPhone(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại phải có 10 số và bắt đầu bằng 0!", "Sai định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không đúng định dạng!", "Sai định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true; // Hợp lệ
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}