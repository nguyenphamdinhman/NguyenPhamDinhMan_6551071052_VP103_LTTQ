namespace Cau1_C8_NhaSachMini
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
            lblMaTL = new Label();
            lblTenTheLoai = new Label();
            lblMoTa = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnTimKiem = new Button();
            txtMaTL = new TextBox();
            txtTenTheLoai = new TextBox();
            txtMoTa = new TextBox();
            lblNgayTao = new Label();
            lblNgayTaoValue = new Label();
            txtTimKiem = new TextBox();
            dgvTheLoaiSach = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTheLoaiSach).BeginInit();
            SuspendLayout();
            // 
            // lblMaTL
            // 
            lblMaTL.AutoSize = true;
            lblMaTL.Location = new Point(31, 26);
            lblMaTL.Name = "lblMaTL";
            lblMaTL.Size = new Size(84, 20);
            lblMaTL.TabIndex = 0;
            lblMaTL.Text = "Mã thể loại";
            // 
            // lblTenTheLoai
            // 
            lblTenTheLoai.AutoSize = true;
            lblTenTheLoai.Location = new Point(31, 70);
            lblTenTheLoai.Name = "lblTenTheLoai";
            lblTenTheLoai.Size = new Size(86, 20);
            lblTenTheLoai.TabIndex = 1;
            lblTenTheLoai.Text = "Tên thể loại";
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(31, 115);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(48, 20);
            lblMoTa.TabIndex = 2;
            lblMoTa.Text = "Mô tả";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(395, 26);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 3;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(495, 26);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 4;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(595, 26);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 5;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(695, 26);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 6;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(327, 228);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 7;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtMaTL
            // 
            txtMaTL.Location = new Point(121, 23);
            txtMaTL.Name = "txtMaTL";
            txtMaTL.ReadOnly = true;
            txtMaTL.Size = new Size(267, 27);
            txtMaTL.TabIndex = 8;
            // 
            // txtTenTheLoai
            // 
            txtTenTheLoai.Location = new Point(123, 70);
            txtTenTheLoai.Name = "txtTenTheLoai";
            txtTenTheLoai.Size = new Size(267, 27);
            txtTenTheLoai.TabIndex = 9;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(123, 115);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(267, 27);
            txtMoTa.TabIndex = 10;
            // 
            // lblNgayTao
            // 
            lblNgayTao.AutoSize = true;
            lblNgayTao.Location = new Point(31, 158);
            lblNgayTao.Name = "lblNgayTao";
            lblNgayTao.Size = new Size(70, 20);
            lblNgayTao.TabIndex = 11;
            lblNgayTao.Text = "Ngày tạo";
            // 
            // lblNgayTaoValue
            // 
            lblNgayTaoValue.AutoSize = true;
            lblNgayTaoValue.Location = new Point(31, 194);
            lblNgayTaoValue.Name = "lblNgayTaoValue";
            lblNgayTaoValue.Size = new Size(41, 20);
            lblNgayTaoValue.TabIndex = 12;
            lblNgayTaoValue.Text = "ngay";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(31, 228);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(267, 27);
            txtTimKiem.TabIndex = 13;
            // 
            // dgvTheLoaiSach
            // 
            dgvTheLoaiSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTheLoaiSach.Location = new Point(31, 263);
            dgvTheLoaiSach.Name = "dgvTheLoaiSach";
            dgvTheLoaiSach.RowHeadersWidth = 51;
            dgvTheLoaiSach.Size = new Size(657, 175);
            dgvTheLoaiSach.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvTheLoaiSach);
            Controls.Add(txtTimKiem);
            Controls.Add(lblNgayTaoValue);
            Controls.Add(lblNgayTao);
            Controls.Add(txtMoTa);
            Controls.Add(txtTenTheLoai);
            Controls.Add(txtMaTL);
            Controls.Add(btnTimKiem);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(lblMoTa);
            Controls.Add(lblTenTheLoai);
            Controls.Add(lblMaTL);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTheLoaiSach).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaTL;
        private Label lblTenTheLoai;
        private Label lblMoTa;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnTimKiem;
        private TextBox txtMaTL;
        private TextBox txtTenTheLoai;
        private TextBox txtMoTa;
        private Label lblNgayTao;
        private Label lblNgayTaoValue;
        private TextBox txtTimKiem;
        private DataGridView dgvTheLoaiSach;
    }
}
