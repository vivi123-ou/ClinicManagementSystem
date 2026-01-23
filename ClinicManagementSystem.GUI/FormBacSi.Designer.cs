namespace ClinicManagementClient.Forms
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
            panelLeft = new Panel();
            dgvChoKham = new DataGridView();
            lblDanhSach = new Label();
            panelRight = new Panel();
            btnHoanThanh = new Button();
            btnLuuBenhAn = new Button();
            grpKetQua = new GroupBox();
            txtChanDoan = new TextBox();
            label4 = new Label();
            txtHuyetAp = new TextBox();
            label3 = new Label();
            grpThongTin = new GroupBox();
            txtTrieuChung = new TextBox();
            label2 = new Label();
            txtTenBN = new TextBox();
            label1 = new Label();
            lblTitle = new Label();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChoKham).BeginInit();
            panelRight.SuspendLayout();
            grpKetQua.SuspendLayout();
            grpThongTin.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.WhiteSmoke;
            panelLeft.Controls.Add(dgvChoKham);
            panelLeft.Controls.Add(lblDanhSach);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(628, 640);
            panelLeft.TabIndex = 0;
            // 
            // dgvChoKham
            // 
            dgvChoKham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChoKham.Dock = DockStyle.Fill;
            dgvChoKham.Location = new Point(0, 40);
            dgvChoKham.Name = "dgvChoKham";
            dgvChoKham.RowHeadersVisible = false;
            dgvChoKham.RowHeadersWidth = 51;
            dgvChoKham.RowTemplate.Height = 25;
            dgvChoKham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChoKham.Size = new Size(628, 600);
            dgvChoKham.TabIndex = 1;
            dgvChoKham.CellClick += dgvChoKham_CellClick;
            // 
            // lblDanhSach
            // 
            lblDanhSach.BackColor = Color.LightGray;
            lblDanhSach.Dock = DockStyle.Top;
            lblDanhSach.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDanhSach.Location = new Point(0, 0);
            lblDanhSach.Name = "lblDanhSach";
            lblDanhSach.Size = new Size(628, 40);
            lblDanhSach.TabIndex = 0;
            lblDanhSach.Text = "DANH SÁCH CHỜ KHÁM";
            lblDanhSach.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.White;
            panelRight.Controls.Add(btnHoanThanh);
            panelRight.Controls.Add(btnLuuBenhAn);
            panelRight.Controls.Add(grpKetQua);
            panelRight.Controls.Add(grpThongTin);
            panelRight.Controls.Add(lblTitle);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(628, 0);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(20);
            panelRight.Size = new Size(710, 640);
            panelRight.TabIndex = 1;
            // 
            // btnHoanThanh
            // 
            btnHoanThanh.BackColor = Color.OrangeRed;
            btnHoanThanh.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnHoanThanh.ForeColor = Color.White;
            btnHoanThanh.Location = new Point(400, 520);
            btnHoanThanh.Name = "btnHoanThanh";
            btnHoanThanh.Size = new Size(180, 50);
            btnHoanThanh.TabIndex = 4;
            btnHoanThanh.Text = "KẾT THÚC CA KHÁM";
            btnHoanThanh.UseVisualStyleBackColor = false;
            btnHoanThanh.Click += btnHoanThanh_Click;
            // 
            // btnLuuBenhAn
            // 
            btnLuuBenhAn.BackColor = Color.RoyalBlue;
            btnLuuBenhAn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLuuBenhAn.ForeColor = Color.White;
            btnLuuBenhAn.Location = new Point(190, 520);
            btnLuuBenhAn.Name = "btnLuuBenhAn";
            btnLuuBenhAn.Size = new Size(180, 50);
            btnLuuBenhAn.TabIndex = 3;
            btnLuuBenhAn.Text = "LƯU BỆNH ÁN";
            btnLuuBenhAn.UseVisualStyleBackColor = false;
            btnLuuBenhAn.Click += btnLuuBenhAn_Click;
            // 
            // grpKetQua
            // 
            grpKetQua.Controls.Add(txtChanDoan);
            grpKetQua.Controls.Add(label4);
            grpKetQua.Controls.Add(txtHuyetAp);
            grpKetQua.Controls.Add(label3);
            grpKetQua.Location = new Point(20, 229);
            grpKetQua.Name = "grpKetQua";
            grpKetQua.Size = new Size(580, 270);
            grpKetQua.TabIndex = 2;
            grpKetQua.TabStop = false;
            grpKetQua.Text = "Kết quả Khám lâm sàng";
            // 
            // txtChanDoan
            // 
            txtChanDoan.Location = new Point(130, 90);
            txtChanDoan.Multiline = true;
            txtChanDoan.Name = "txtChanDoan";
            txtChanDoan.Size = new Size(430, 160);
            txtChanDoan.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label4.Location = new Point(20, 90);
            label4.Name = "label4";
            label4.Size = new Size(113, 25);
            label4.TabIndex = 2;
            label4.Text = "Chẩn đoán:";
            // 
            // txtHuyetAp
            // 
            txtHuyetAp.Location = new Point(130, 40);
            txtHuyetAp.Name = "txtHuyetAp";
            txtHuyetAp.Size = new Size(200, 32);
            txtHuyetAp.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 43);
            label3.Name = "label3";
            label3.Size = new Size(91, 25);
            label3.TabIndex = 0;
            label3.Text = "Huyết áp:";
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(txtTrieuChung);
            grpThongTin.Controls.Add(label2);
            grpThongTin.Controls.Add(txtTenBN);
            grpThongTin.Controls.Add(label1);
            grpThongTin.Location = new Point(20, 64);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(580, 150);
            grpThongTin.TabIndex = 1;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin Bệnh nhân";
            // 
            // txtTrieuChung
            // 
            txtTrieuChung.Location = new Point(130, 80);
            txtTrieuChung.Multiline = true;
            txtTrieuChung.Name = "txtTrieuChung";
            txtTrieuChung.ReadOnly = true;
            txtTrieuChung.ScrollBars = ScrollBars.Vertical;
            txtTrieuChung.Size = new Size(430, 50);
            txtTrieuChung.TabIndex = 3;
            txtTrieuChung.TextChanged += txtTrieuChung_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 83);
            label2.Name = "label2";
            label2.Size = new Size(115, 25);
            label2.TabIndex = 2;
            label2.Text = "Triệu chứng:";
            // 
            // txtTenBN
            // 
            txtTenBN.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtTenBN.ForeColor = Color.DarkRed;
            txtTenBN.Location = new Point(130, 35);
            txtTenBN.Name = "txtTenBN";
            txtTenBN.ReadOnly = true;
            txtTenBN.Size = new Size(430, 34);
            txtTenBN.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 38);
            label1.Name = "label1";
            label1.Size = new Size(96, 25);
            label1.TabIndex = 0;
            label1.Text = "Họ và tên:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 122, 204);
            lblTitle.Location = new Point(20, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(290, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BÁC SĨ - KHÁM BỆNH";
            // 
            // FormBacSi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1338, 640);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Font = new Font("Segoe UI", 11F);
            Name = "FormBacSi";
            Text = "Bác Sĩ";
            Load += FormBacSi_Load;
            panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChoKham).EndInit();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            grpKetQua.ResumeLayout(false);
            grpKetQua.PerformLayout();
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.DataGridView dgvChoKham;
        private System.Windows.Forms.Label lblDanhSach;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.TextBox txtTrieuChung;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenBN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpKetQua;
        private System.Windows.Forms.TextBox txtChanDoan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHuyetAp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnHoanThanh;
        private System.Windows.Forms.Button btnLuuBenhAn;
    }
}