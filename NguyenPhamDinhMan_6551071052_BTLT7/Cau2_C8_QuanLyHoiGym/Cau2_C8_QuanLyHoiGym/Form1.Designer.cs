namespace Cau2_C8_QuanLyHoiGym
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblMaHV = new Label();
            lblHoTen = new Label();
            lblNgaySinh = new Label();
            lblSDT = new Label();
            lblEmail = new Label();
            txtMaHV = new TextBox();
            txtHoTen = new TextBox();
            dtpNgaySinh = new DateTimePicker();
            txtSDT = new TextBox();
            txtEmail = new TextBox();
            grpGioiTinh = new GroupBox();
            rbNu = new RadioButton();
            rbNam = new RadioButton();
            lblHangThanhVien = new Label();
            cmbHangThanhVien = new ComboBox();
            chkTrangThai = new CheckBox();
            lblNgayDangKy = new Label();
            lblNgayDangKyValue = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            label1 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            txtTimKiem = new TextBox();
            cmbTimHang = new ComboBox();
            btnTimKiem = new Button();
            dgvHoiVien = new DataGridView();
            grpGioiTinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoiVien).BeginInit();
            SuspendLayout();
            // 
            // lblMaHV
            // 
            lblMaHV.AutoSize = true;
            lblMaHV.Location = new Point(12, 9);
            lblMaHV.Name = "lblMaHV";
            lblMaHV.Size = new Size(86, 20);
            lblMaHV.TabIndex = 0;
            lblMaHV.Text = "Mã hội viên";
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(12, 44);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(54, 20);
            lblHoTen.TabIndex = 1;
            lblHoTen.Text = "Họ tên";
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(12, 83);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(74, 20);
            lblNgaySinh.TabIndex = 2;
            lblNgaySinh.Text = "Ngày sinh";
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(12, 121);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(35, 20);
            lblSDT.TabIndex = 3;
            lblSDT.Text = "SDT";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(12, 159);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email";
            // 
            // txtMaHV
            // 
            txtMaHV.Location = new Point(117, 2);
            txtMaHV.Name = "txtMaHV";
            txtMaHV.ReadOnly = true;
            txtMaHV.Size = new Size(330, 27);
            txtMaHV.TabIndex = 5;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(117, 44);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(330, 27);
            txtHoTen.TabIndex = 6;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Location = new Point(117, 83);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(330, 27);
            dtpNgaySinh.TabIndex = 7;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(117, 121);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(330, 27);
            txtSDT.TabIndex = 8;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(117, 159);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(330, 27);
            txtEmail.TabIndex = 9;
            // 
            // grpGioiTinh
            // 
            grpGioiTinh.Controls.Add(rbNu);
            grpGioiTinh.Controls.Add(rbNam);
            grpGioiTinh.Location = new Point(480, 9);
            grpGioiTinh.Name = "grpGioiTinh";
            grpGioiTinh.Size = new Size(164, 94);
            grpGioiTinh.TabIndex = 10;
            grpGioiTinh.TabStop = false;
            grpGioiTinh.Text = "Giới tính";
            // 
            // rbNu
            // 
            rbNu.AutoSize = true;
            rbNu.Location = new Point(87, 50);
            rbNu.Name = "rbNu";
            rbNu.Size = new Size(50, 24);
            rbNu.TabIndex = 1;
            rbNu.TabStop = true;
            rbNu.Text = "Nữ";
            rbNu.UseVisualStyleBackColor = true;
            // 
            // rbNam
            // 
            rbNam.AutoSize = true;
            rbNam.Location = new Point(19, 50);
            rbNam.Name = "rbNam";
            rbNam.Size = new Size(62, 24);
            rbNam.TabIndex = 0;
            rbNam.TabStop = true;
            rbNam.Text = "Nam";
            rbNam.UseVisualStyleBackColor = true;
            // 
            // lblHangThanhVien
            // 
            lblHangThanhVien.AutoSize = true;
            lblHangThanhVien.Location = new Point(12, 199);
            lblHangThanhVien.Name = "lblHangThanhVien";
            lblHangThanhVien.Size = new Size(117, 20);
            lblHangThanhVien.TabIndex = 11;
            lblHangThanhVien.Text = "Hạng thành viên";
            // 
            // cmbHangThanhVien
            // 
            cmbHangThanhVien.FormattingEnabled = true;
            cmbHangThanhVien.Location = new Point(149, 199);
            cmbHangThanhVien.Name = "cmbHangThanhVien";
            cmbHangThanhVien.Size = new Size(151, 28);
            cmbHangThanhVien.TabIndex = 12;
            // 
            // chkTrangThai
            // 
            chkTrangThai.AutoSize = true;
            chkTrangThai.Location = new Point(12, 233);
            chkTrangThai.Name = "chkTrangThai";
            chkTrangThai.Size = new Size(140, 24);
            chkTrangThai.TabIndex = 13;
            chkTrangThai.Text = "Đang hoạt động";
            chkTrangThai.UseVisualStyleBackColor = true;
            // 
            // lblNgayDangKy
            // 
            lblNgayDangKy.AutoSize = true;
            lblNgayDangKy.Location = new Point(12, 260);
            lblNgayDangKy.Name = "lblNgayDangKy";
            lblNgayDangKy.Size = new Size(100, 20);
            lblNgayDangKy.TabIndex = 14;
            lblNgayDangKy.Text = "Ngày đăng ký";
            // 
            // lblNgayDangKyValue
            // 
            lblNgayDangKyValue.AutoSize = true;
            lblNgayDangKyValue.Location = new Point(12, 294);
            lblNgayDangKyValue.Name = "lblNgayDangKyValue";
            lblNgayDangKyValue.Size = new Size(0, 20);
            lblNgayDangKyValue.TabIndex = 15;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(687, 12);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(89, 34);
            btnThem.TabIndex = 16;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(687, 52);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(89, 34);
            btnSua.TabIndex = 17;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(687, 92);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(89, 34);
            btnXoa.TabIndex = 18;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(687, 132);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(89, 34);
            btnLamMoi.TabIndex = 19;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 294);
            label1.Name = "label1";
            label1.Size = new Size(114, 20);
            label1.TabIndex = 20;
            label1.Text = "Tìm theo họ tên";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(132, 294);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(315, 27);
            txtTimKiem.TabIndex = 22;
            // 
            // cmbTimHang
            // 
            cmbTimHang.FormattingEnabled = true;
            cmbTimHang.Location = new Point(466, 294);
            cmbTimHang.Name = "cmbTimHang";
            cmbTimHang.Size = new Size(151, 28);
            cmbTimHang.TabIndex = 23;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(687, 287);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(89, 34);
            btnTimKiem.TabIndex = 24;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvHoiVien
            // 
            dgvHoiVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoiVien.Location = new Point(12, 327);
            dgvHoiVien.Name = "dgvHoiVien";
            dgvHoiVien.RowHeadersWidth = 51;
            dgvHoiVien.Size = new Size(984, 427);
            dgvHoiVien.TabIndex = 25;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvHoiVien);
            Controls.Add(btnTimKiem);
            Controls.Add(cmbTimHang);
            Controls.Add(txtTimKiem);
            Controls.Add(label1);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(lblNgayDangKyValue);
            Controls.Add(lblNgayDangKy);
            Controls.Add(chkTrangThai);
            Controls.Add(cmbHangThanhVien);
            Controls.Add(lblHangThanhVien);
            Controls.Add(grpGioiTinh);
            Controls.Add(txtEmail);
            Controls.Add(txtSDT);
            Controls.Add(dtpNgaySinh);
            Controls.Add(txtHoTen);
            Controls.Add(txtMaHV);
            Controls.Add(lblEmail);
            Controls.Add(lblSDT);
            Controls.Add(lblNgaySinh);
            Controls.Add(lblHoTen);
            Controls.Add(lblMaHV);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            grpGioiTinh.ResumeLayout(false);
            grpGioiTinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoiVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaHV;
        private Label lblHoTen;
        private Label lblNgaySinh;
        private Label lblSDT;
        private Label lblEmail;
        private TextBox txtMaHV;
        private TextBox txtHoTen;
        private DateTimePicker dtpNgaySinh;
        private TextBox txtSDT;
        private TextBox txtEmail;
        private GroupBox grpGioiTinh;
        private RadioButton rbNu;
        private RadioButton rbNam;
        private Label lblHangThanhVien;
        private ComboBox cmbHangThanhVien;
        private CheckBox chkTrangThai;
        private Label lblNgayDangKy;
        private Label lblNgayDangKyValue;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label label1;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox txtTimKiem;
        private ComboBox cmbTimHang;
        private Button btnTimKiem;
        private DataGridView dgvHoiVien;
    }
}
