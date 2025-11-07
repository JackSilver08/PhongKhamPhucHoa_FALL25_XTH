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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace QuanLyPhongKhamPhucHoa
{
    public partial class FrmLichKham : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private string connStr = "Server=localhost;Database=PhongKhamPhucHoa;Trusted_Connection=True;TrustServerCertificate=True;";
        public FrmLichKham()
        {
            InitializeComponent();
            NapLichKham();
            NapComboBox();
        }
        private void NapLichKham()
        {
            string sql = @"
                SELECT 
                    LK.LichKhamId,
                    LK.MaLich,
                    BN.HoTen AS TenBenhNhan,
                    NV.HoTen AS TenBacSi,
                    LK.NgayKham,
                    LK.BatDau,
                    LK.KetThuc,
                    TT.TenTrangThai,
                    LK.GhiChu,
                    LK.CreatedAt
                FROM LichKham LK
                JOIN BenhNhan BN ON LK.BenhNhanId = BN.BenhNhanId
                JOIN NhanVien NV ON LK.NhanVienId = NV.NhanVienId
                JOIN TrangThaiLich TT ON LK.TrangThaiId = TT.TrangThaiId
                ORDER BY LK.NgayKham, LK.BatDau";

            SqlDataAdapter da = new SqlDataAdapter(sql, connStr);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvLichKham.DataSource = dt;

            // ✅ Đặt tiêu đề cột
            dgvLichKham.Columns["LichKhamId"].HeaderText = "Lịch khám ID";
            dgvLichKham.Columns["MaLich"].HeaderText = "Mã lịch";
            dgvLichKham.Columns["TenBenhNhan"].HeaderText = "Bệnh nhân";
            dgvLichKham.Columns["TenBacSi"].HeaderText = "Bác sĩ";
            dgvLichKham.Columns["NgayKham"].HeaderText = "Ngày khám";
            dgvLichKham.Columns["BatDau"].HeaderText = "Giờ bắt đầu";
            dgvLichKham.Columns["KetThuc"].HeaderText = "Giờ kết thúc";
            dgvLichKham.Columns["TenTrangThai"].HeaderText = "Trạng thái";
            dgvLichKham.Columns["GhiChu"].HeaderText = "Ghi chú";
            dgvLichKham.Columns["CreatedAt"].HeaderText = "Ngày tạo";

        }

        // 🧩 Nạp combo box cho các bảng liên quan
        private void NapComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Bệnh nhân
                SqlDataAdapter daBN = new SqlDataAdapter("SELECT BenhNhanId, HoTen FROM BenhNhan ORDER BY HoTen", conn);
                DataTable dtBN = new DataTable();
                daBN.Fill(dtBN);
                cboBenhNhan.DataSource = dtBN;
                cboBenhNhan.DisplayMember = "HoTen";
                cboBenhNhan.ValueMember = "BenhNhanId";

                // Bác sĩ
                SqlDataAdapter daBS = new SqlDataAdapter("SELECT NhanVienId, HoTen FROM NhanVien WHERE VaiTroId = 2 ORDER BY HoTen", conn);
                DataTable dtBS = new DataTable();
                daBS.Fill(dtBS);
                cboBacSi.DataSource = dtBS;
                cboBacSi.DisplayMember = "HoTen";
                cboBacSi.ValueMember = "NhanVienId";

                // Trạng thái
                SqlDataAdapter daTT = new SqlDataAdapter("SELECT TrangThaiId, TenTrangThai FROM TrangThaiLich", conn);
                DataTable dtTT = new DataTable();
                daTT.Fill(dtTT);
                cboTrangThai.DataSource = dtTT;
                cboTrangThai.DisplayMember = "TenTrangThai";
                cboTrangThai.ValueMember = "TrangThaiId";
            }
        }

        // 🧩 Làm mới form
        private void LamMoi()
        {
            txtMaLich.Text = "";
            cboBenhNhan.SelectedIndex = -1;
            cboBacSi.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
            dtpNgayKham.Value = DateTime.Now;
            dtpBatDau.Value = DateTime.Now;
            dtpKetThuc.Value = DateTime.Now.AddMinutes(30);
            txtGhiChu.Text = "";
            dgvLichKham.ClearSelection();
            txtMaLich.Enabled = true;

        }

        private void dgvLichKham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridViewRow row = dgvLichKham.Rows[e.RowIndex];
            txtMaLich.Text = row.Cells["MaLich"].Value?.ToString();
            txtLichKhamID.Text = row.Cells["LichKhamId"].Value?.ToString();
            cboBenhNhan.Text = row.Cells["TenBenhNhan"].Value?.ToString();
            cboBacSi.Text = row.Cells["TenBacSi"].Value?.ToString();
            dtpNgayKham.Value = Convert.ToDateTime(row.Cells["NgayKham"].Value);
            dtpBatDau.Value = Convert.ToDateTime(row.Cells["BatDau"].Value.ToString());
            dtpKetThuc.Value = Convert.ToDateTime(row.Cells["KetThuc"].Value.ToString());
            cboTrangThai.Text = row.Cells["TenTrangThai"].Value?.ToString();
            txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
            txtLichKhamID.Enabled = false;
            txtMaLich.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            string sql = @"
        INSERT INTO LichKham 
        (MaLich, BenhNhanId, NhanVienId, NgayKham, BatDau, KetThuc, TrangThaiId, CreatedBy, CreatedAt, GhiChu)
        VALUES 
        (@MaLich, @BenhNhanId, @BacSiId, @NgayKham, @BatDau, @KetThuc, @TrangThaiId, @CreatedBy, GETDATE(), @GhiChu);
        SELECT SCOPE_IDENTITY(); -- ✅ Lấy ID vừa được tạo
    ";

            string maLich = "LK" + DateTime.Now.ToString("yyyyMMddHHmmss");

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaLich", maLich);
                cmd.Parameters.AddWithValue("@BenhNhanId", cboBenhNhan.SelectedValue);
                cmd.Parameters.AddWithValue("@BacSiId", cboBacSi.SelectedValue);
                cmd.Parameters.AddWithValue("@NgayKham", dtpNgayKham.Value.Date);
                cmd.Parameters.AddWithValue("@BatDau", dtpBatDau.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@KetThuc", dtpKetThuc.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@TrangThaiId", cboTrangThai.SelectedValue);
                cmd.Parameters.AddWithValue("@CreatedBy", cboBacSi.SelectedValue); // 🔹 Người tạo
                cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar(); // 🔹 Phải dùng ExecuteScalar() để lấy giá trị SELECT SCOPE_IDENTITY()

                    if (result != null)
                    {
                        int lichKhamIdMoi = Convert.ToInt32(result);
                        txtLichKhamID.Text = lichKhamIdMoi.ToString(); // ✅ gán vào textbox hiển thị ID

                        NapLichKham();
                        LamMoi();
                        MessageBox.Show("Thêm lịch khám thành công!");
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
            if (string.IsNullOrWhiteSpace(txtMaLich.Text))
            {
                MessageBox.Show("Vui lòng chọn lịch khám cần sửa!");
                return;
            }
            if (!KiemTraDuLieu()) return;

            string sql = @"
    UPDATE LichKham
    SET BenhNhanId=@BenhNhanId,
        NhanVienId=@BacSiId,
        NgayKham=@NgayKham,
        BatDau=@BatDau,
        KetThuc=@KetThuc,
        TrangThaiId=@TrangThaiId,
        GhiChu=@GhiChu,
        CreatedBy=@CreatedBy
    WHERE MaLich=@MaLich";


            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaLich", txtMaLich.Text);
                cmd.Parameters.AddWithValue("@BenhNhanId", cboBenhNhan.SelectedValue);
                cmd.Parameters.AddWithValue("@BacSiId", cboBacSi.SelectedValue);
                cmd.Parameters.AddWithValue("@NgayKham", dtpNgayKham.Value.Date);
                cmd.Parameters.AddWithValue("@BatDau", dtpBatDau.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@KetThuc", dtpKetThuc.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@TrangThaiId", cboTrangThai.SelectedValue);
                cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);
                cmd.Parameters.AddWithValue("@CreatedBy", cboBacSi.SelectedValue);


                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        NapLichKham();
                        LamMoi();
                        MessageBox.Show("Cập nhật lịch khám thành công!");
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
            if (string.IsNullOrWhiteSpace(txtMaLich.Text))
            {
                MessageBox.Show("Vui lòng chọn lịch khám cần xóa!");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa lịch khám này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string sql = "DELETE FROM LichKham WHERE MaLich=@MaLich";

                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaLich", txtMaLich.Text);

                    try
                    {
                        conn.Open();
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            NapLichKham();
                            LamMoi();
                            MessageBox.Show("Xóa thành công!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                    }
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa))
            {
                NapLichKham();
                return;
            }

            string sql = @"
                SELECT LK.MaLich, BN.HoTen AS TenBenhNhan, NV.HoTen AS TenBacSi, LK.NgayKham, LK.BatDau, LK.KetThuc, TT.TenTrangThai, LK.GhiChu
                FROM LichKham LK
                JOIN BenhNhan BN ON LK.BenhNhanId = BN.BenhNhanId
                JOIN NhanVien NV ON LK.NhanVienId = NV.NhanVienId
                JOIN TrangThaiLich TT ON LK.TrangThaiId = TT.TrangThaiId
                WHERE BN.HoTen LIKE @TuKhoa OR NV.HoTen LIKE @TuKhoa";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show(
                            "Không tìm thấy bác sĩ hay bệnh nhân nào có tên như vậy.",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    dgvLichKham.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }
        private bool KiemTraDuLieu()
        {
            if (cboBenhNhan.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboBenhNhan.Focus();
                return false;
            }

            if (cboBacSi.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn bác sĩ!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboBacSi.Focus();
                return false;
            }

            if (dtpKetThuc.Value <= dtpBatDau.Value)
            {
                MessageBox.Show("Giờ kết thúc phải lớn hơn giờ bắt đầu!", "Sai dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpKetThuc.Focus();
                return false;
            }

            if (dtpNgayKham.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày khám không được nhỏ hơn ngày hiện tại!", "Sai dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayKham.Focus();
                return false;
            }

            return true;
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
