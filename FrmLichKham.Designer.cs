namespace QuanLyPhongKhamPhucHoa
{
    partial class FrmLichKham
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dtpKetThuc = new DateTimePicker();
            dtpBatDau = new DateTimePicker();
            cboBenhNhan = new ComboBox();
            cboBacSi = new ComboBox();
            btnTimKiem = new Button();
            txtTimKiem = new TextBox();
            dtpNgayKham = new DateTimePicker();
            cboTrangThai = new ComboBox();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            dgvLichKham = new DataGridView();
            txtLichKhamID = new TextBox();
            txtGhiChu = new TextBox();
            txtMaLich = new TextBox();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            btnMinimize = new Guna.UI2.WinForms.Guna2Button();
            panel1 = new Panel();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            btnMaximize = new Guna.UI2.WinForms.Guna2Button();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)dgvLichKham).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dtpKetThuc
            // 
            dtpKetThuc.CustomFormat = "HH:mm";
            dtpKetThuc.Format = DateTimePickerFormat.Custom;
            dtpKetThuc.Location = new Point(625, 336);
            dtpKetThuc.Name = "dtpKetThuc";
            dtpKetThuc.Size = new Size(152, 27);
            dtpKetThuc.TabIndex = 54;
            // 
            // dtpBatDau
            // 
            dtpBatDau.CustomFormat = "HH:mm";
            dtpBatDau.Format = DateTimePickerFormat.Custom;
            dtpBatDau.Location = new Point(625, 299);
            dtpBatDau.Name = "dtpBatDau";
            dtpBatDau.Size = new Size(152, 27);
            dtpBatDau.TabIndex = 53;
            // 
            // cboBenhNhan
            // 
            cboBenhNhan.FormattingEnabled = true;
            cboBenhNhan.Location = new Point(626, 138);
            cboBenhNhan.Name = "cboBenhNhan";
            cboBenhNhan.Size = new Size(151, 28);
            cboBenhNhan.TabIndex = 52;
            cboBenhNhan.Text = "Bệnh nhân";
            // 
            // cboBacSi
            // 
            cboBacSi.FormattingEnabled = true;
            cboBacSi.Location = new Point(626, 178);
            cboBacSi.Name = "cboBacSi";
            cboBacSi.Size = new Size(151, 28);
            cboBacSi.TabIndex = 51;
            cboBacSi.Text = "Bác sĩ";
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.Crimson;
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(684, 414);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 50;
            btnTimKiem.Text = "Tìm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(491, 414);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tìm tên";
            txtTimKiem.Size = new Size(187, 27);
            txtTimKiem.TabIndex = 49;
            // 
            // dtpNgayKham
            // 
            dtpNgayKham.CustomFormat = "dd/MM/yyyy";
            dtpNgayKham.Format = DateTimePickerFormat.Custom;
            dtpNgayKham.Location = new Point(626, 261);
            dtpNgayKham.Name = "dtpNgayKham";
            dtpNgayKham.Size = new Size(151, 27);
            dtpNgayKham.TabIndex = 48;
            // 
            // cboTrangThai
            // 
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(626, 221);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(151, 28);
            cboTrangThai.TabIndex = 47;
            cboTrangThai.Text = "Trạng thái";
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.Crimson;
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(367, 414);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 46;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Crimson;
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(247, 414);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 45;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.Crimson;
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(127, 414);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 44;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.Crimson;
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(17, 414);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 43;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // dgvLichKham
            // 
            dgvLichKham.AllowUserToAddRows = false;
            dgvLichKham.AllowUserToDeleteRows = false;
            dgvLichKham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichKham.Location = new Point(18, 64);
            dgvLichKham.Name = "dgvLichKham";
            dgvLichKham.ReadOnly = true;
            dgvLichKham.RowHeadersWidth = 51;
            dgvLichKham.Size = new Size(579, 335);
            dgvLichKham.TabIndex = 42;
            dgvLichKham.CellClick += dgvLichKham_CellClick;
            // 
            // txtLichKhamID
            // 
            txtLichKhamID.Enabled = false;
            txtLichKhamID.Location = new Point(626, 100);
            txtLichKhamID.Name = "txtLichKhamID";
            txtLichKhamID.PlaceholderText = "Lịch Khám ID";
            txtLichKhamID.Size = new Size(151, 27);
            txtLichKhamID.TabIndex = 41;
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(625, 373);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.PlaceholderText = "Ghi chú";
            txtGhiChu.Size = new Size(151, 27);
            txtGhiChu.TabIndex = 40;
            // 
            // txtMaLich
            // 
            txtMaLich.BackColor = Color.White;
            txtMaLich.ForeColor = Color.Black;
            txtMaLich.Location = new Point(626, 62);
            txtMaLich.Name = "txtMaLich";
            txtMaLich.PlaceholderText = "Mã Lịch Khám";
            txtMaLich.Size = new Size(151, 27);
            txtMaLich.TabIndex = 39;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.ForeColor = Color.White;
            guna2HtmlLabel2.Location = new Point(28, 4);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(196, 33);
            guna2HtmlLabel2.TabIndex = 4;
            guna2HtmlLabel2.Text = "Quản lý lịch khám";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.Transparent;
            btnClose.BorderColor = Color.White;
            btnClose.CustomizableEdges = customizableEdges11;
            btnClose.DisabledState.BorderColor = Color.DarkGray;
            btnClose.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClose.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClose.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClose.FillColor = Color.Crimson;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(767, -1);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnClose.Size = new Size(33, 40);
            btnClose.TabIndex = 55;
            btnClose.Text = "×";
            btnClose.Click += btnClose_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.BackColor = Color.Transparent;
            btnMinimize.BorderColor = Color.White;
            btnMinimize.CustomizableEdges = customizableEdges13;
            btnMinimize.DisabledState.BorderColor = Color.DarkGray;
            btnMinimize.DisabledState.CustomBorderColor = Color.DarkGray;
            btnMinimize.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnMinimize.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnMinimize.FillColor = Color.Crimson;
            btnMinimize.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Location = new Point(733, -1);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnMinimize.Size = new Size(34, 40);
            btnMinimize.TabIndex = 56;
            btnMinimize.Text = "—";
            btnMinimize.Click += btnMinimize_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Crimson;
            panel1.BackgroundImageLayout = ImageLayout.Center;
            panel1.Controls.Add(guna2HtmlLabel2);
            panel1.Controls.Add(guna2Button1);
            panel1.Controls.Add(btnMaximize);
            panel1.Controls.Add(guna2Button2);
            panel1.ForeColor = Color.Red;
            panel1.Location = new Point(-15, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(830, 40);
            panel1.TabIndex = 57;
            panel1.Paint += panel1_Paint;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // guna2Button1
            // 
            guna2Button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2Button1.BackColor = Color.Transparent;
            guna2Button1.CustomizableEdges = customizableEdges15;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.Transparent;
            guna2Button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.Red;
            guna2Button1.Location = new Point(2013, 0);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges16;
            guna2Button1.Size = new Size(33, 39);
            guna2Button1.TabIndex = 3;
            guna2Button1.Text = "×";
            // 
            // btnMaximize
            // 
            btnMaximize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMaximize.BackColor = Color.Transparent;
            btnMaximize.CustomizableEdges = customizableEdges17;
            btnMaximize.DisabledState.BorderColor = Color.DarkGray;
            btnMaximize.DisabledState.CustomBorderColor = Color.DarkGray;
            btnMaximize.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnMaximize.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnMaximize.FillColor = Color.Transparent;
            btnMaximize.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMaximize.ForeColor = Color.Red;
            btnMaximize.Location = new Point(1975, 0);
            btnMaximize.Name = "btnMaximize";
            btnMaximize.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnMaximize.Size = new Size(41, 39);
            btnMaximize.TabIndex = 3;
            btnMaximize.Text = "☐";
            // 
            // guna2Button2
            // 
            guna2Button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2Button2.BackColor = Color.Transparent;
            guna2Button2.CustomizableEdges = customizableEdges19;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.FillColor = Color.Transparent;
            guna2Button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button2.ForeColor = Color.Red;
            guna2Button2.Location = new Point(1944, 0);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges20;
            guna2Button2.Size = new Size(34, 39);
            guna2Button2.TabIndex = 3;
            guna2Button2.Text = "—";
            // 
            // FrmLichKham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClose);
            Controls.Add(btnMinimize);
            Controls.Add(panel1);
            Controls.Add(dtpKetThuc);
            Controls.Add(dtpBatDau);
            Controls.Add(cboBenhNhan);
            Controls.Add(cboBacSi);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(dtpNgayKham);
            Controls.Add(cboTrangThai);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtLichKhamID);
            Controls.Add(txtGhiChu);
            Controls.Add(txtMaLich);
            Controls.Add(dgvLichKham);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmLichKham";
            Text = "FrmLichKham";
            ((System.ComponentModel.ISupportInitialize)dgvLichKham).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpKetThuc;
        private DateTimePicker dtpBatDau;
        private ComboBox cboBenhNhan;
        private ComboBox cboBacSi;
        private Button btnTimKiem;
        private TextBox txtTimKiem;
        private DateTimePicker dtpNgayKham;
        private ComboBox cboTrangThai;
        private Button btnLamMoi;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private DataGridView dgvLichKham;
        private TextBox txtLichKhamID;
        private TextBox txtGhiChu;
        private TextBox txtMaLich;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnMinimize;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button btnMaximize;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}