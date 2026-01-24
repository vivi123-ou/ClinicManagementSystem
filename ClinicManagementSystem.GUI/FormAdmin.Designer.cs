namespace ClinicManagementSystem.GUI
{
    partial class FormAdmin
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox grpNhanVien;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.Button btnTaoTaiKhoan;

        private System.Windows.Forms.GroupBox grpThuoc;
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
        private System.Windows.Forms.Button btnThemThuoc;
        private System.Windows.Forms.Button btnXoaThuoc;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpNhanVien = new GroupBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtHoTen = new TextBox();
            cboVaiTro = new ComboBox();
            btnTaoTaiKhoan = new Button();
            grpThuoc = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
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
            btnThemThuoc = new Button();
            btnXoaThuoc = new Button();
            grpNhanVien.SuspendLayout();
            grpThuoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThuoc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDonGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSoLuongTon).BeginInit();
            SuspendLayout();
            // 
            // grpNhanVien
            // 
            grpNhanVien.Controls.Add(txtUsername);
            grpNhanVien.Controls.Add(txtPassword);
            grpNhanVien.Controls.Add(txtHoTen);
            grpNhanVien.Controls.Add(cboVaiTro);
            grpNhanVien.Controls.Add(btnTaoTaiKhoan);
            grpNhanVien.Location = new Point(20, 20);
            grpNhanVien.Name = "grpNhanVien";
            grpNhanVien.Size = new Size(350, 212);
            grpNhanVien.TabIndex = 0;
            grpNhanVien.TabStop = false;
            grpNhanVien.Text = "Quản lý nhân viên";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(20, 30);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Tên đăng nhập";
            txtUsername.Size = new Size(196, 27);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(20, 60);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Mật khẩu";
            txtPassword.Size = new Size(196, 27);
            txtPassword.TabIndex = 1;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(20, 90);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.PlaceholderText = "Họ tên";
            txtHoTen.Size = new Size(196, 27);
            txtHoTen.TabIndex = 2;
            // 
            // cboVaiTro
            // 
            cboVaiTro.Items.AddRange(new object[] { "Bác sĩ", "Lễ tân", "Thu ngân", "Kho dược" });
            cboVaiTro.Location = new Point(20, 120);
            cboVaiTro.Name = "cboVaiTro";
            cboVaiTro.Size = new Size(121, 28);
            cboVaiTro.TabIndex = 3;
            // 
            // btnTaoTaiKhoan
            // 
            btnTaoTaiKhoan.Location = new Point(20, 160);
            btnTaoTaiKhoan.Name = "btnTaoTaiKhoan";
            btnTaoTaiKhoan.Size = new Size(121, 28);
            btnTaoTaiKhoan.TabIndex = 4;
            btnTaoTaiKhoan.Text = "Tạo tài khoản";
            btnTaoTaiKhoan.Click += btnTaoTaiKhoan_Click;
            // 
            // grpThuoc
            // 
            grpThuoc.Controls.Add(label3);
            grpThuoc.Controls.Add(label2);
            grpThuoc.Controls.Add(label1);
            grpThuoc.Controls.Add(dgvThuoc);
            grpThuoc.Controls.Add(txtMaThuoc);
            grpThuoc.Controls.Add(txtTenThuoc);
            grpThuoc.Controls.Add(txtHoatChat);
            grpThuoc.Controls.Add(txtDonVi);
            grpThuoc.Controls.Add(nudDonGia);
            grpThuoc.Controls.Add(nudSoLuongTon);
            grpThuoc.Controls.Add(dtpHanSuDung);
            grpThuoc.Controls.Add(txtNhaSanXuat);
            grpThuoc.Controls.Add(txtGhiChu);
            grpThuoc.Controls.Add(btnThemThuoc);
            grpThuoc.Controls.Add(btnXoaThuoc);
            grpThuoc.Location = new Point(400, 20);
            grpThuoc.Name = "grpThuoc";
            grpThuoc.Size = new Size(600, 400);
            grpThuoc.TabIndex = 1;
            grpThuoc.TabStop = false;
            grpThuoc.Text = "Quản lý thuốc";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(168, 265);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 14;
            label3.Text = "HSD";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(168, 202);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 13;
            label2.Text = "Đơn giá";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(168, 233);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 12;
            label1.Text = "Số lượng tồn";
            // 
            // dgvThuoc
            // 
            dgvThuoc.ColumnHeadersHeight = 29;
            dgvThuoc.Location = new Point(20, 30);
            dgvThuoc.Name = "dgvThuoc";
            dgvThuoc.RowHeadersWidth = 51;
            dgvThuoc.Size = new Size(550, 150);
            dgvThuoc.TabIndex = 0;
            // 
            // txtMaThuoc
            // 
            txtMaThuoc.Location = new Point(20, 200);
            txtMaThuoc.Name = "txtMaThuoc";
            txtMaThuoc.PlaceholderText = "Mã thuốc";
            txtMaThuoc.Size = new Size(100, 27);
            txtMaThuoc.TabIndex = 1;
            // 
            // txtTenThuoc
            // 
            txtTenThuoc.Location = new Point(20, 230);
            txtTenThuoc.Name = "txtTenThuoc";
            txtTenThuoc.PlaceholderText = "Tên thuốc";
            txtTenThuoc.Size = new Size(100, 27);
            txtTenThuoc.TabIndex = 2;
            // 
            // txtHoatChat
            // 
            txtHoatChat.Location = new Point(20, 260);
            txtHoatChat.Name = "txtHoatChat";
            txtHoatChat.PlaceholderText = "Hoạt chất";
            txtHoatChat.Size = new Size(100, 27);
            txtHoatChat.TabIndex = 3;
            // 
            // txtDonVi
            // 
            txtDonVi.Location = new Point(20, 290);
            txtDonVi.Name = "txtDonVi";
            txtDonVi.PlaceholderText = "Đơn vị";
            txtDonVi.Size = new Size(100, 27);
            txtDonVi.TabIndex = 4;
            // 
            // nudDonGia
            // 
            nudDonGia.Location = new Point(269, 200);
            nudDonGia.Name = "nudDonGia";
            nudDonGia.Size = new Size(120, 27);
            nudDonGia.TabIndex = 5;
            // 
            // nudSoLuongTon
            // 
            nudSoLuongTon.Location = new Point(269, 230);
            nudSoLuongTon.Name = "nudSoLuongTon";
            nudSoLuongTon.Size = new Size(120, 27);
            nudSoLuongTon.TabIndex = 6;
            // 
            // dtpHanSuDung
            // 
            dtpHanSuDung.Location = new Point(269, 260);
            dtpHanSuDung.Name = "dtpHanSuDung";
            dtpHanSuDung.Size = new Size(200, 27);
            dtpHanSuDung.TabIndex = 7;
            // 
            // txtNhaSanXuat
            // 
            txtNhaSanXuat.Location = new Point(269, 290);
            txtNhaSanXuat.Name = "txtNhaSanXuat";
            txtNhaSanXuat.PlaceholderText = "Nhà sản xuất";
            txtNhaSanXuat.Size = new Size(100, 27);
            txtNhaSanXuat.TabIndex = 8;
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(269, 320);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.PlaceholderText = "Ghi chú";
            txtGhiChu.Size = new Size(100, 27);
            txtGhiChu.TabIndex = 9;
            // 
            // btnThemThuoc
            // 
            btnThemThuoc.Location = new Point(20, 360);
            btnThemThuoc.Name = "btnThemThuoc";
            btnThemThuoc.Size = new Size(75, 34);
            btnThemThuoc.TabIndex = 10;
            btnThemThuoc.Text = "Thêm thuốc";
            btnThemThuoc.Click += btnThemThuoc_Click;
            // 
            // btnXoaThuoc
            // 
            btnXoaThuoc.Location = new Point(120, 360);
            btnXoaThuoc.Name = "btnXoaThuoc";
            btnXoaThuoc.Size = new Size(75, 34);
            btnXoaThuoc.TabIndex = 11;
            btnXoaThuoc.Text = "Xóa thuốc";
            btnXoaThuoc.Click += btnXoaThuoc_Click;
            // 
            // FormAdmin
            // 
            ClientSize = new Size(1024, 480);
            Controls.Add(grpNhanVien);
            Controls.Add(grpThuoc);
            Name = "FormAdmin";
            Text = "Quản trị hệ thống";
            Load += FormAdmin_Load;
            grpNhanVien.ResumeLayout(false);
            grpNhanVien.PerformLayout();
            grpThuoc.ResumeLayout(false);
            grpThuoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThuoc).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDonGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSoLuongTon).EndInit();
            ResumeLayout(false);
        }

        private Label label3;
        private Label label2;
        private Label label1;
    }
}