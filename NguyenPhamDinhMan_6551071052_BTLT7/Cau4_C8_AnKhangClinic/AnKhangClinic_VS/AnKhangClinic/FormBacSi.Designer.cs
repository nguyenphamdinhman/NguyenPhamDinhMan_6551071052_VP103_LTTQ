namespace AnKhangClinic
{
    partial class FormBacSi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblHoTen = new Label(); lblCK = new Label(); lblSDT = new Label();
            txtHoTen = new TextBox(); txtChuyenKhoa = new TextBox(); txtSDT = new TextBox();
            btnThem = new Button(); btnSua = new Button(); btnXoa = new Button(); btnLamMoi = new Button();
            dgvBS = new DataGridView();
            colMa = new DataGridViewTextBoxColumn(); colHoTen = new DataGridViewTextBoxColumn();
            colCK = new DataGridViewTextBoxColumn(); colSDT = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvBS).BeginInit();
            SuspendLayout();

            lblHoTen.AutoSize = true; lblHoTen.Location = new Point(12, 15); lblHoTen.Text = "Họ tên";
            txtHoTen.Location = new Point(12, 36); txtHoTen.Size = new Size(190, 23);
            lblCK.AutoSize = true; lblCK.Location = new Point(215, 15); lblCK.Text = "Chuyên khoa";
            txtChuyenKhoa.Location = new Point(215, 36); txtChuyenKhoa.Size = new Size(170, 23);
            lblSDT.AutoSize = true; lblSDT.Location = new Point(398, 15); lblSDT.Text = "SĐT";
            txtSDT.Location = new Point(398, 36); txtSDT.Size = new Size(120, 23);

            btnThem.Location = new Point(540, 14); btnThem.Size = new Size(70, 28); btnThem.Text = "Thêm"; btnThem.Click += btnThem_Click;
            btnSua.Location = new Point(540, 48); btnSua.Size = new Size(70, 28); btnSua.Text = "Sửa"; btnSua.Click += btnSua_Click;
            btnXoa.Location = new Point(620, 14); btnXoa.Size = new Size(70, 28); btnXoa.Text = "Xóa"; btnXoa.Click += btnXoa_Click;
            btnLamMoi.Location = new Point(620, 48); btnLamMoi.Size = new Size(70, 28); btnLamMoi.Text = "Làm mới"; btnLamMoi.Click += btnLamMoi_Click;

            dgvBS.Location = new Point(12, 90); dgvBS.Size = new Size(678, 250);
            dgvBS.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBS.AutoGenerateColumns = false; dgvBS.AllowUserToAddRows = false; dgvBS.ReadOnly = true;
            dgvBS.SelectionMode = DataGridViewSelectionMode.FullRowSelect; dgvBS.MultiSelect = false;
            dgvBS.BackgroundColor = Color.White;
            dgvBS.Columns.AddRange(new DataGridViewColumn[] { colMa, colHoTen, colCK, colSDT });
            dgvBS.SelectionChanged += dgvBS_SelectionChanged;
            colMa.HeaderText = "Mã BS"; colMa.DataPropertyName = "MaBS"; colMa.Width = 60;
            colHoTen.HeaderText = "Họ tên"; colHoTen.DataPropertyName = "HoTen"; colHoTen.Width = 200;
            colCK.HeaderText = "Chuyên khoa"; colCK.DataPropertyName = "ChuyenKhoa"; colCK.Width = 180;
            colSDT.HeaderText = "SĐT"; colSDT.DataPropertyName = "SDT"; colSDT.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 352); StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý Bác sĩ";
            Controls.AddRange(new Control[] { lblHoTen, txtHoTen, lblCK, txtChuyenKhoa, lblSDT, txtSDT,
                btnThem, btnSua, btnXoa, btnLamMoi, dgvBS });
            Load += FormBacSi_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBS).EndInit();
            ResumeLayout(false); PerformLayout();
        }

        private Label lblHoTen, lblCK, lblSDT;
        private TextBox txtHoTen, txtChuyenKhoa, txtSDT;
        private Button btnThem, btnSua, btnXoa, btnLamMoi;
        private DataGridView dgvBS;
        private DataGridViewTextBoxColumn colMa, colHoTen, colCK, colSDT;
    }
}
