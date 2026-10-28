namespace NguyenPhamDinhMan_6551071052_VP103_LTTQ
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
            groupBox1 = new GroupBox();
            txtGiaSach = new TextBox();
            txtTenTheLoai = new TextBox();
            txtMaSach = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnThem = new Button();
            nll = new GroupBox();
            dgvThongTinSach = new DataGridView();
            btnSua = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            groupBox1.SuspendLayout();
            nll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThongTinSach).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtGiaSach);
            groupBox1.Controls.Add(txtTenTheLoai);
            groupBox1.Controls.Add(txtMaSach);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(197, 426);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sách";
            // 
            // txtGiaSach
            // 
            txtGiaSach.Location = new Point(6, 320);
            txtGiaSach.Name = "txtGiaSach";
            txtGiaSach.Size = new Size(174, 27);
            txtGiaSach.TabIndex = 5;
            // 
            // txtTenTheLoai
            // 
            txtTenTheLoai.Location = new Point(6, 200);
            txtTenTheLoai.Name = "txtTenTheLoai";
            txtTenTheLoai.Size = new Size(174, 27);
            txtTenTheLoai.TabIndex = 4;
            // 
            // txtMaSach
            // 
            txtMaSach.Location = new Point(6, 88);
            txtMaSach.Name = "txtMaSach";
            txtMaSach.Size = new Size(174, 27);
            txtMaSach.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 266);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 3;
            label3.Text = "Giá tiền";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 151);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 2;
            label2.Text = "Tên sách";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 45);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 1;
            label1.Text = "Mã sách";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(264, 22);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // nll
            // 
            nll.Controls.Add(dgvThongTinSach);
            nll.Location = new Point(264, 100);
            nll.Name = "nll";
            nll.Size = new Size(524, 338);
            nll.TabIndex = 3;
            nll.TabStop = false;
            nll.Text = "Danh sách sách";
            // 
            // dgvThongTinSach
            // 
            dgvThongTinSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThongTinSach.Location = new Point(18, 26);
            dgvThongTinSach.Name = "dgvThongTinSach";
            dgvThongTinSach.RowHeadersWidth = 51;
            dgvThongTinSach.Size = new Size(500, 306);
            dgvThongTinSach.TabIndex = 0;
            dgvThongTinSach.CellClick += dgvThongTinSach_CellClick;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(391, 22);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 4;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(529, 22);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 5;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(665, 22);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 6;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(nll);
            Controls.Add(btnThem);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            nll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvThongTinSach).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtGiaSach;
        private TextBox txtTenTheLoai;
        private TextBox txtMaSach;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnThem;
        private GroupBox nll;
        private DataGridView dgvThongTinSach;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThoat;
    }
}
