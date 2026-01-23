namespace ClinicManagementClient.Forms
{
    partial class FormLeTan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            grpTimKiem = new GroupBox();
            btnTim = new Button();
            txtTimKiem = new TextBox();
            label1 = new Label();
            grpThongTin = new GroupBox();
            txtDiaChi = new TextBox();
            lblDiaChi = new Label();
            txtSDT = new TextBox();
            lblSDT = new Label();
            txtHoTen = new TextBox();
            lblHoTen = new Label();
            grpDangKy = new GroupBox();
            btnTaoPhieu = new Button();
            cboBacSi = new ComboBox();
            label5 = new Label();
            grpTimKiem.SuspendLayout();
            grpThongTin.SuspendLayout();
            grpDangKy.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 122, 204);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(310, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "TIẾP ĐÓN BỆNH NHÂN";
            // 
            // grpTimKiem
            // 
            grpTimKiem.Controls.Add(btnTim);
            grpTimKiem.Controls.Add(txtTimKiem);
            grpTimKiem.Controls.Add(label1);
            grpTimKiem.Location = new Point(25, 70);
            grpTimKiem.Name = "grpTimKiem";
            grpTimKiem.Size = new Size(750, 80);
            grpTimKiem.TabIndex = 1;
            grpTimKiem.TabStop = false;
            grpTimKiem.Text = "Tra cứu";
            // 
            // btnTim
            // 
            btnTim.BackColor = Color.SteelBlue;
            btnTim.ForeColor = Color.White;
            btnTim.Location = new Point(450, 30);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(100, 35);
            btnTim.TabIndex = 2;
            btnTim.Text = "Tìm kiếm";
            btnTim.UseVisualStyleBackColor = false;
            btnTim.Click += btnTim_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(150, 35);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(280, 32);
            txtTimKiem.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 38);
            label1.Name = "label1";
            label1.Size = new Size(156, 25);
            label1.TabIndex = 0;
            label1.Text = "SĐT hoặc CMND:";
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(txtDiaChi);
            grpThongTin.Controls.Add(lblDiaChi);
            grpThongTin.Controls.Add(txtSDT);
            grpThongTin.Controls.Add(lblSDT);
            grpThongTin.Controls.Add(txtHoTen);
            grpThongTin.Controls.Add(lblHoTen);
            grpThongTin.Location = new Point(25, 170);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(750, 180);
            grpThongTin.TabIndex = 2;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin Bệnh nhân";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(150, 120);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(550, 32);
            txtDiaChi.TabIndex = 5;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Location = new Point(30, 123);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(74, 25);
            lblDiaChi.TabIndex = 4;
            lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(150, 80);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(250, 32);
            txtSDT.TabIndex = 3;
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(30, 83);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(127, 25);
            lblSDT.TabIndex = 2;
            lblSDT.Text = "Số điện thoại:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(150, 40);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(250, 32);
            txtHoTen.TabIndex = 1;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(30, 43);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(96, 25);
            lblHoTen.TabIndex = 0;
            lblHoTen.Text = "Họ và tên:";
            // 
            // grpDangKy
            // 
            grpDangKy.Controls.Add(btnTaoPhieu);
            grpDangKy.Controls.Add(cboBacSi);
            grpDangKy.Controls.Add(label5);
            grpDangKy.Location = new Point(25, 370);
            grpDangKy.Name = "grpDangKy";
            grpDangKy.Size = new Size(750, 100);
            grpDangKy.TabIndex = 3;
            grpDangKy.TabStop = false;
            grpDangKy.Text = "Đăng ký khám";
            // 
            // btnTaoPhieu
            // 
            btnTaoPhieu.BackColor = Color.ForestGreen;
            btnTaoPhieu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnTaoPhieu.ForeColor = Color.White;
            btnTaoPhieu.Location = new Point(500, 30);
            btnTaoPhieu.Name = "btnTaoPhieu";
            btnTaoPhieu.Size = new Size(200, 45);
            btnTaoPhieu.TabIndex = 2;
            btnTaoPhieu.Text = "TẠO PHIẾU KHÁM";
            btnTaoPhieu.UseVisualStyleBackColor = false;
            btnTaoPhieu.Click += btnTaoPhieu_Click;
            // 
            // cboBacSi
            // 
            cboBacSi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBacSi.FormattingEnabled = true;
            cboBacSi.Location = new Point(150, 40);
            cboBacSi.Name = "cboBacSi";
            cboBacSi.Size = new Size(250, 33);
            cboBacSi.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 43);
            label5.Name = "label5";
            label5.Size = new Size(114, 25);
            label5.TabIndex = 0;
            label5.Text = "Chọn Bác sĩ:";
            // 
            // FormLeTan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1089, 582);
            Controls.Add(grpDangKy);
            Controls.Add(grpThongTin);
            Controls.Add(grpTimKiem);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 11F);
            Name = "FormLeTan";
            Text = "Lễ Tân - Tiếp đón";
            Load += FormLeTan_Load;
            grpTimKiem.ResumeLayout(false);
            grpTimKiem.PerformLayout();
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpDangKy.ResumeLayout(false);
            grpDangKy.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.GroupBox grpDangKy;
        private System.Windows.Forms.Button btnTaoPhieu;
        private System.Windows.Forms.ComboBox cboBacSi;
        private System.Windows.Forms.Label label5;
    }
}