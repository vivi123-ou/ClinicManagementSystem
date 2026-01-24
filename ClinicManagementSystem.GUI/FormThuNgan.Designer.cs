namespace ClinicManagementClient.Forms
{
    partial class FormThuNgan
    {
        private System.ComponentModel.IContainer components = null;
        
        // Controls cho phần Tạo Hóa Đơn
        private System.Windows.Forms.GroupBox grpTaoHoaDon;
        private System.Windows.Forms.Label lblMaBenhNhan;
        private System.Windows.Forms.TextBox txtMaBenhNhan;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.NumericUpDown nudTongTien;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnTaoHoaDon;

        // Controls cho phần Thanh Toán
        private System.Windows.Forms.GroupBox grpThanhToan;
        private System.Windows.Forms.Label lblMaHoaDon;
        private System.Windows.Forms.TextBox txtMaHoaDon;
        private System.Windows.Forms.Button btnThanhToan;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpTaoHoaDon = new GroupBox();
            btnTaoHoaDon = new Button();
            txtGhiChu = new TextBox();
            lblGhiChu = new Label();
            nudTongTien = new NumericUpDown();
            lblTongTien = new Label();
            txtMaBenhNhan = new TextBox();
            lblMaBenhNhan = new Label();
            grpThanhToan = new GroupBox();
            btnThanhToan = new Button();
            txtMaHoaDon = new TextBox();
            lblMaHoaDon = new Label();
            grpTaoHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudTongTien).BeginInit();
            grpThanhToan.SuspendLayout();
            SuspendLayout();
            // 
            // grpTaoHoaDon
            // 
            grpTaoHoaDon.Controls.Add(btnTaoHoaDon);
            grpTaoHoaDon.Controls.Add(txtGhiChu);
            grpTaoHoaDon.Controls.Add(lblGhiChu);
            grpTaoHoaDon.Controls.Add(nudTongTien);
            grpTaoHoaDon.Controls.Add(lblTongTien);
            grpTaoHoaDon.Controls.Add(txtMaBenhNhan);
            grpTaoHoaDon.Controls.Add(lblMaBenhNhan);
            grpTaoHoaDon.Location = new Point(20, 20);
            grpTaoHoaDon.Name = "grpTaoHoaDon";
            grpTaoHoaDon.Size = new Size(360, 300);
            grpTaoHoaDon.TabIndex = 0;
            grpTaoHoaDon.TabStop = false;
            grpTaoHoaDon.Text = "Tạo Hóa Đơn Mới";
            // 
            // btnTaoHoaDon
            // 
            btnTaoHoaDon.Location = new Point(144, 217);
            btnTaoHoaDon.Name = "btnTaoHoaDon";
            btnTaoHoaDon.Size = new Size(119, 34);
            btnTaoHoaDon.TabIndex = 0;
            btnTaoHoaDon.Text = "Tạo Hóa Đơn";
            btnTaoHoaDon.Click += btnTaoHoaDon_Click;
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(144, 117);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(200, 80);
            txtGhiChu.TabIndex = 1;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.Location = new Point(20, 120);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(63, 20);
            lblGhiChu.TabIndex = 2;
            lblGhiChu.Text = "Ghi Chú:";
            // 
            // nudTongTien
            // 
            nudTongTien.Location = new Point(144, 77);
            nudTongTien.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudTongTien.Name = "nudTongTien";
            nudTongTien.Size = new Size(200, 27);
            nudTongTien.TabIndex = 3;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(20, 80);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(123, 20);
            lblTongTien.TabIndex = 4;
            lblTongTien.Text = "Tổng Tiền (VNĐ):";
            // 
            // txtMaBenhNhan
            // 
            txtMaBenhNhan.Location = new Point(144, 37);
            txtMaBenhNhan.Name = "txtMaBenhNhan";
            txtMaBenhNhan.Size = new Size(200, 27);
            txtMaBenhNhan.TabIndex = 5;
            // 
            // lblMaBenhNhan
            // 
            lblMaBenhNhan.AutoSize = true;
            lblMaBenhNhan.Location = new Point(20, 40);
            lblMaBenhNhan.Name = "lblMaBenhNhan";
            lblMaBenhNhan.Size = new Size(109, 20);
            lblMaBenhNhan.TabIndex = 6;
            lblMaBenhNhan.Text = "Mã Bệnh Nhân:";
            // 
            // grpThanhToan
            // 
            grpThanhToan.Controls.Add(btnThanhToan);
            grpThanhToan.Controls.Add(txtMaHoaDon);
            grpThanhToan.Controls.Add(lblMaHoaDon);
            grpThanhToan.Location = new Point(400, 20);
            grpThanhToan.Name = "grpThanhToan";
            grpThanhToan.Size = new Size(350, 150);
            grpThanhToan.TabIndex = 1;
            grpThanhToan.TabStop = false;
            grpThanhToan.Text = "Thanh Toán Hóa Đơn";
            // 
            // btnThanhToan
            // 
            btnThanhToan.Location = new Point(130, 73);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(150, 34);
            btnThanhToan.TabIndex = 0;
            btnThanhToan.Text = "Xác Nhận Đã Thu Tiền";
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // txtMaHoaDon
            // 
            txtMaHoaDon.Location = new Point(130, 37);
            txtMaHoaDon.Name = "txtMaHoaDon";
            txtMaHoaDon.Size = new Size(200, 27);
            txtMaHoaDon.TabIndex = 1;
            // 
            // lblMaHoaDon
            // 
            lblMaHoaDon.AutoSize = true;
            lblMaHoaDon.Location = new Point(20, 40);
            lblMaHoaDon.Name = "lblMaHoaDon";
            lblMaHoaDon.Size = new Size(97, 20);
            lblMaHoaDon.TabIndex = 2;
            lblMaHoaDon.Text = "Mã Hóa Đơn:";
            // 
            // FormThuNgan
            // 
            ClientSize = new Size(780, 350);
            Controls.Add(grpThanhToan);
            Controls.Add(grpTaoHoaDon);
            Name = "FormThuNgan";
            Text = "Thu Ngân - Hệ Thống Phòng Khám";
            //Load += FormThuNgan_Load;
            grpTaoHoaDon.ResumeLayout(false);
            grpTaoHoaDon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudTongTien).EndInit();
            grpThanhToan.ResumeLayout(false);
            grpThanhToan.PerformLayout();
            ResumeLayout(false);
        }
    }
}