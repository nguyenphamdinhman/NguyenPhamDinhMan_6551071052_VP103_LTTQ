namespace AnKhangClinic
{
    partial class FormLichKham
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTen = new Label();
            lblSDT = new Label();
            lblNgay = new Label();
            lblGio = new Label();
            lblBacSi = new Label();
            lblTrangThai = new Label();
            lblTu = new Label();
            lblDen = new Label();
            txtTenBN = new TextBox();
            txtSDT = new TextBox();
            dtpNgay = new DateTimePicker();
            dtpGio = new DateTimePicker();
            cboBacSi = new ComboBox();
            cboTrangThai = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dtpTu = new DateTimePicker();
            dtpDen = new DateTimePicker();
            cboLocBS = new ComboBox();
            btnTimKiem = new Button();
            btnBacSi = new Button();
            dgvLich = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLich).BeginInit();
            SuspendLayout();
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Location = new Point(17, 27);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(105, 20);
            lblTen.TabIndex = 0;
            lblTen.Text = "Tên bệnh nhân";
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(17, 77);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(97, 20);
            lblSDT.TabIndex = 2;
            lblSDT.Text = "Số điện thoại";
            // 
            // lblNgay
            // 
            lblNgay.AutoSize = true;
            lblNgay.Location = new Point(17, 131);
            lblNgay.Name = "lblNgay";
            lblNgay.Size = new Size(84, 20);
            lblNgay.TabIndex = 5;
            lblNgay.Text = "Ngày khám";
            // 
            // lblGio
            // 
            lblGio.AutoSize = true;
            lblGio.Location = new Point(314, 77);
            lblGio.Name = "lblGio";
            lblGio.Size = new Size(72, 20);
            lblGio.TabIndex = 4;
            lblGio.Text = "Giờ khám";
            // 
            // lblBacSi
            // 
            lblBacSi.AutoSize = true;
            lblBacSi.Location = new Point(451, 35);
            lblBacSi.Name = "lblBacSi";
            lblBacSi.Size = new Size(47, 20);
            lblBacSi.TabIndex = 8;
            lblBacSi.Text = "Bác sĩ";
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(733, 40);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(75, 20);
            lblTrangThai.TabIndex = 10;
            lblTrangThai.Text = "Trạng thái";
            // 
            // lblTu
            // 
            lblTu.AutoSize = true;
            lblTu.Location = new Point(17, 189);
            lblTu.Name = "lblTu";
            lblTu.Size = new Size(62, 20);
            lblTu.TabIndex = 16;
            lblTu.Text = "Từ ngày";
            // 
            // lblDen
            // 
            lblDen.AutoSize = true;
            lblDen.Location = new Point(206, 189);
            lblDen.Name = "lblDen";
            lblDen.Size = new Size(72, 20);
            lblDen.TabIndex = 18;
            lblDen.Text = "Đến ngày";
            // 
            // txtTenBN
            // 
            txtTenBN.Location = new Point(114, 21);
            txtTenBN.Margin = new Padding(3, 4, 3, 4);
            txtTenBN.Name = "txtTenBN";
            txtTenBN.Size = new Size(180, 27);
            txtTenBN.TabIndex = 1;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(114, 72);
            txtSDT.Margin = new Padding(3, 4, 3, 4);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(180, 27);
            txtSDT.TabIndex = 3;
            // 
            // dtpNgay
            // 
            dtpNgay.Format = DateTimePickerFormat.Short;
            dtpNgay.Location = new Point(114, 125);
            dtpNgay.Margin = new Padding(3, 4, 3, 4);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.Size = new Size(180, 27);
            dtpNgay.TabIndex = 6;
            // 
            // dtpGio
            // 
            dtpGio.Format = DateTimePickerFormat.Time;
            dtpGio.Location = new Point(314, 107);
            dtpGio.Margin = new Padding(3, 4, 3, 4);
            dtpGio.Name = "dtpGio";
            dtpGio.ShowUpDown = true;
            dtpGio.Size = new Size(108, 27);
            dtpGio.TabIndex = 7;
            // 
            // cboBacSi
            // 
            cboBacSi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBacSi.Location = new Point(451, 64);
            cboBacSi.Margin = new Padding(3, 4, 3, 4);
            cboBacSi.Name = "cboBacSi";
            cboBacSi.Size = new Size(276, 28);
            cboBacSi.TabIndex = 9;
            // 
            // cboTrangThai
            // 
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Location = new Point(734, 64);
            cboTrangThai.Margin = new Padding(3, 4, 3, 4);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(182, 28);
            cboTrangThai.TabIndex = 11;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(654, 16);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(63, 37);
            btnThem.TabIndex = 12;
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(722, 16);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(63, 37);
            btnSua.TabIndex = 13;
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(791, 16);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(63, 37);
            btnXoa.TabIndex = 14;
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(859, 16);
            btnLamMoi.Margin = new Padding(3, 4, 3, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(66, 37);
            btnLamMoi.TabIndex = 15;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // dtpTu
            // 
            dtpTu.Format = DateTimePickerFormat.Short;
            dtpTu.Location = new Point(78, 184);
            dtpTu.Margin = new Padding(3, 4, 3, 4);
            dtpTu.Name = "dtpTu";
            dtpTu.Size = new Size(114, 27);
            dtpTu.TabIndex = 17;
            // 
            // dtpDen
            // 
            dtpDen.Format = DateTimePickerFormat.Short;
            dtpDen.Location = new Point(274, 184);
            dtpDen.Margin = new Padding(3, 4, 3, 4);
            dtpDen.Name = "dtpDen";
            dtpDen.Size = new Size(114, 27);
            dtpDen.TabIndex = 19;
            // 
            // cboLocBS
            // 
            cboLocBS.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocBS.Location = new Point(400, 184);
            cboLocBS.Margin = new Padding(3, 4, 3, 4);
            cboLocBS.Name = "cboLocBS";
            cboLocBS.Size = new Size(245, 28);
            cboLocBS.TabIndex = 20;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(657, 181);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(80, 36);
            btnTimKiem.TabIndex = 21;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnBacSi
            // 
            btnBacSi.Location = new Point(817, 181);
            btnBacSi.Margin = new Padding(3, 4, 3, 4);
            btnBacSi.Name = "btnBacSi";
            btnBacSi.Size = new Size(109, 36);
            btnBacSi.TabIndex = 22;
            btnBacSi.Text = "Quản lý BS";
            btnBacSi.Click += btnBacSi_Click;
            // 
            // dgvLich
            // 
            dgvLich.AllowUserToAddRows = false;
            dgvLich.AllowUserToDeleteRows = false;
            dgvLich.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLich.BackgroundColor = Color.White;
            dgvLich.ColumnHeadersHeight = 29;
            dgvLich.Location = new Point(17, 237);
            dgvLich.Margin = new Padding(3, 4, 3, 4);
            dgvLich.MultiSelect = false;
            dgvLich.Name = "dgvLich";
            dgvLich.ReadOnly = true;
            dgvLich.RowHeadersWidth = 25;
            dgvLich.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLich.Size = new Size(909, 429);
            dgvLich.TabIndex = 23;
            dgvLich.SelectionChanged += dgvLich_SelectionChanged;
            // 
            // FormLichKham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 683);
            Controls.Add(lblTen);
            Controls.Add(txtTenBN);
            Controls.Add(lblSDT);
            Controls.Add(txtSDT);
            Controls.Add(lblGio);
            Controls.Add(lblNgay);
            Controls.Add(dtpNgay);
            Controls.Add(dtpGio);
            Controls.Add(lblBacSi);
            Controls.Add(cboBacSi);
            Controls.Add(lblTrangThai);
            Controls.Add(cboTrangThai);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(lblTu);
            Controls.Add(dtpTu);
            Controls.Add(lblDen);
            Controls.Add(dtpDen);
            Controls.Add(cboLocBS);
            Controls.Add(btnTimKiem);
            Controls.Add(btnBacSi);
            Controls.Add(dgvLich);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormLichKham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Lịch Khám Bệnh - An Khang Clinic";
            Load += FormLichKham_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLich).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTen, lblSDT, lblNgay, lblGio, lblBacSi, lblTrangThai, lblTu, lblDen;
        private TextBox txtTenBN, txtSDT;
        private DateTimePicker dtpNgay, dtpGio, dtpTu, dtpDen;
        private ComboBox cboBacSi, cboTrangThai, cboLocBS;
        private Button btnThem, btnSua, btnXoa, btnLamMoi, btnTimKiem, btnBacSi;
        private DataGridView dgvLich;
        private DataGridViewTextBoxColumn colMaLich, colTenBN, colSDT, colNgay, colGio, colBacSi, colChuyenKhoa, colTrangThai;
    }
}
