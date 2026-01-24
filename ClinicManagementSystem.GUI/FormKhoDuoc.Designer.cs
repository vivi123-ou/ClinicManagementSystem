namespace ClinicManagementSystem.GUI
{
    partial class FormKhoDuoc
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvThuoc;
        private System.Windows.Forms.TextBox txtMaThuoc;
        private System.Windows.Forms.TextBox txtTenThuoc;
        private System.Windows.Forms.TextBox txtHoatChat;
        private System.Windows.Forms.TextBox txtDonVi;
        private System.Windows.Forms.NumericUpDown nudDonGia;
        private System.Windows.Forms.NumericUpDown nudSoLuongTon;
        private System.Windows.Forms.DateTimePicker dtpHanSuDung;
        private System.Windows.Forms.TextBox txtNhaSanXuat;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblTenThuoc;
        private System.Windows.Forms.Label lblMaThuoc;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvThuoc = new DataGridView();
            txtMaThuoc = new TextBox();
            txtTenThuoc = new TextBox();
            txtHoatChat = new TextBox();
            txtDonVi = new TextBox();
            nudDonGia = new NumericUpDown();
            nudSoLuongTon = new NumericUpDown();
            dtpHanSuDung = new DateTimePicker();
            txtNhaSanXuat = new TextBox();
            txtGhiChu = new TextBox();
            btnThem = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTenThuoc = new Label();
            lblMaThuoc = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvThuoc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDonGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSoLuongTon).BeginInit();
            SuspendLayout();
            // 
            // dgvThuoc
            // 
            dgvThuoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThuoc.Location = new Point(12, 170);
            dgvThuoc.Name = "dgvThuoc";
            dgvThuoc.RowHeadersWidth = 51;
            dgvThuoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThuoc.Size = new Size(850, 300);
            dgvThuoc.TabIndex = 0;
            dgvThuoc.CellClick += dgvThuoc_CellClick;
            // 
            // txtMaThuoc
            // 
            txtMaThuoc.Location = new Point(100, 23);
            txtMaThuoc.Name = "txtMaThuoc";
            txtMaThuoc.Size = new Size(100, 27);
            txtMaThuoc.TabIndex = 1;
            // 
            // txtTenThuoc
            // 
            txtTenThuoc.Location = new Point(100, 53);
            txtTenThuoc.Name = "txtTenThuoc";
            txtTenThuoc.Size = new Size(100, 27);
            txtTenThuoc.TabIndex = 2;
            // 
            // txtHoatChat
            // 
            txtHoatChat.Location = new Point(100, 83);
            txtHoatChat.Name = "txtHoatChat";
            txtHoatChat.Size = new Size(100, 27);
            txtHoatChat.TabIndex = 3;
            // 
            // txtDonVi
            // 
            txtDonVi.Location = new Point(363, 19);
            txtDonVi.Name = "txtDonVi";
            txtDonVi.Size = new Size(100, 27);
            txtDonVi.TabIndex = 4;
            // 
            // nudDonGia
            // 
            nudDonGia.Location = new Point(363, 49);
            nudDonGia.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudDonGia.Name = "nudDonGia";
            nudDonGia.Size = new Size(120, 27);
            nudDonGia.TabIndex = 5;
            // 
            // nudSoLuongTon
            // 
            nudSoLuongTon.Location = new Point(363, 79);
            nudSoLuongTon.Name = "nudSoLuongTon";
            nudSoLuongTon.Size = new Size(120, 27);
            nudSoLuongTon.TabIndex = 6;
            // 
            // dtpHanSuDung
            // 
            dtpHanSuDung.Location = new Point(621, 23);
            dtpHanSuDung.Name = "dtpHanSuDung";
            dtpHanSuDung.Size = new Size(200, 27);
            dtpHanSuDung.TabIndex = 7;
            // 
            // txtNhaSanXuat
            // 
            txtNhaSanXuat.Location = new Point(621, 53);
            txtNhaSanXuat.Name = "txtNhaSanXuat";
            txtNhaSanXuat.Size = new Size(100, 27);
            txtNhaSanXuat.TabIndex = 8;
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(621, 83);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(100, 27);
            txtGhiChu.TabIndex = 9;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(91, 116);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 29);
            btnThem.TabIndex = 10;
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(191, 116);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 29);
            btnXoa.TabIndex = 11;
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(291, 116);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(75, 29);
            btnLamMoi.TabIndex = 12;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // lblTenThuoc
            // 
            lblTenThuoc.Location = new Point(12, 53);
            lblTenThuoc.Name = "lblTenThuoc";
            lblTenThuoc.Size = new Size(100, 23);
            lblTenThuoc.TabIndex = 14;
            lblTenThuoc.Text = "Tên Thuốc:";
            // 
            // lblMaThuoc
            // 
            lblMaThuoc.Location = new Point(12, 23);
            lblMaThuoc.Name = "lblMaThuoc";
            lblMaThuoc.Size = new Size(100, 23);
            lblMaThuoc.TabIndex = 13;
            lblMaThuoc.Text = "Mã Thuốc:";
            // 
            // label1
            // 
            label1.Location = new Point(12, 87);
            label1.Name = "label1";
            label1.Size = new Size(82, 23);
            label1.TabIndex = 15;
            label1.Text = "Hoạt Chất:";
            // 
            // label2
            // 
            label2.Location = new Point(246, 19);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 16;
            label2.Text = "Đơn Vị:";
            // 
            // label3
            // 
            label3.Location = new Point(246, 50);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 17;
            label3.Text = "Đơn Giá:";
            // 
            // label4
            // 
            label4.Location = new Point(246, 82);
            label4.Name = "label4";
            label4.Size = new Size(111, 23);
            label4.TabIndex = 18;
            label4.Text = "Số Lượng Tồn:";
            // 
            // label5
            // 
            label5.Location = new Point(515, 23);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 19;
            label5.Text = "HSD:";
            // 
            // label6
            // 
            label6.Location = new Point(515, 53);
            label6.Name = "label6";
            label6.Size = new Size(108, 23);
            label6.TabIndex = 20;
            label6.Text = "Nhà Sản Xuất:";
            // 
            // label7
            // 
            label7.Location = new Point(515, 86);
            label7.Name = "label7";
            label7.Size = new Size(100, 23);
            label7.TabIndex = 21;
            label7.Text = "Ghi Chú:";
            // 
            // FormKhoDuoc
            // 
            ClientSize = new Size(880, 480);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvThuoc);
            Controls.Add(txtMaThuoc);
            Controls.Add(txtTenThuoc);
            Controls.Add(txtHoatChat);
            Controls.Add(txtDonVi);
            Controls.Add(nudDonGia);
            Controls.Add(nudSoLuongTon);
            Controls.Add(dtpHanSuDung);
            Controls.Add(txtNhaSanXuat);
            Controls.Add(txtGhiChu);
            Controls.Add(btnThem);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(lblMaThuoc);
            Controls.Add(lblTenThuoc);
            Name = "FormKhoDuoc";
            Text = "Quản Lý Kho Dược";
            Load += FormKhoDuoc_Load;
            ((System.ComponentModel.ISupportInitialize)dgvThuoc).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDonGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSoLuongTon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}