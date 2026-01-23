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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.dgvChoKham = new System.Windows.Forms.DataGridView();
            this.lblDanhSach = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnHoanThanh = new System.Windows.Forms.Button();
            this.btnLuuBenhAn = new System.Windows.Forms.Button();
            this.grpKetQua = new System.Windows.Forms.GroupBox();
            this.txtChanDoan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHuyetAp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.txtTrieuChung = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenBN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoKham)).BeginInit();
            this.panelRight.SuspendLayout();
            this.grpKetQua.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelLeft.Controls.Add(this.dgvChoKham);
            this.panelLeft.Controls.Add(this.lblDanhSach);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(350, 600);
            this.panelLeft.TabIndex = 0;
            // 
            // dgvChoKham
            // 
            this.dgvChoKham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChoKham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChoKham.Location = new System.Drawing.Point(0, 40);
            this.dgvChoKham.Name = "dgvChoKham";
            this.dgvChoKham.RowHeadersVisible = false;
            this.dgvChoKham.RowTemplate.Height = 25;
            this.dgvChoKham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChoKham.Size = new System.Drawing.Size(350, 560);
            this.dgvChoKham.TabIndex = 1;
            this.dgvChoKham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChoKham_CellClick);
            // 
            // lblDanhSach
            // 
            this.lblDanhSach.BackColor = System.Drawing.Color.LightGray;
            this.lblDanhSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDanhSach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDanhSach.Location = new System.Drawing.Point(0, 0);
            this.lblDanhSach.Name = "lblDanhSach";
            this.lblDanhSach.Size = new System.Drawing.Size(350, 40);
            this.lblDanhSach.TabIndex = 0;
            this.lblDanhSach.Text = "DANH SÁCH CHỜ KHÁM";
            this.lblDanhSach.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.btnHoanThanh);
            this.panelRight.Controls.Add(this.btnLuuBenhAn);
            this.panelRight.Controls.Add(this.grpKetQua);
            this.panelRight.Controls.Add(this.grpThongTin);
            this.panelRight.Controls.Add(this.lblTitle);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(350, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(20);
            this.panelRight.Size = new System.Drawing.Size(650, 600);
            this.panelRight.TabIndex = 1;
            // 
            // btnHoanThanh
            // 
            this.btnHoanThanh.BackColor = System.Drawing.Color.OrangeRed;
            this.btnHoanThanh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHoanThanh.ForeColor = System.Drawing.Color.White;
            this.btnHoanThanh.Location = new System.Drawing.Point(400, 520);
            this.btnHoanThanh.Name = "btnHoanThanh";
            this.btnHoanThanh.Size = new System.Drawing.Size(180, 50);
            this.btnHoanThanh.TabIndex = 4;
            this.btnHoanThanh.Text = "KẾT THÚC CA KHÁM";
            this.btnHoanThanh.UseVisualStyleBackColor = false;
            this.btnHoanThanh.Click += new System.EventHandler(this.btnHoanThanh_Click);
            // 
            // btnLuuBenhAn
            // 
            this.btnLuuBenhAn.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnLuuBenhAn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLuuBenhAn.ForeColor = System.Drawing.Color.White;
            this.btnLuuBenhAn.Location = new System.Drawing.Point(190, 520);
            this.btnLuuBenhAn.Name = "btnLuuBenhAn";
            this.btnLuuBenhAn.Size = new System.Drawing.Size(180, 50);
            this.btnLuuBenhAn.TabIndex = 3;
            this.btnLuuBenhAn.Text = "LƯU BỆNH ÁN";
            this.btnLuuBenhAn.UseVisualStyleBackColor = false;
            this.btnLuuBenhAn.Click += new System.EventHandler(this.btnLuuBenhAn_Click);
            // 
            // grpKetQua
            // 
            this.grpKetQua.Controls.Add(this.txtChanDoan);
            this.grpKetQua.Controls.Add(this.label4);
            this.grpKetQua.Controls.Add(this.txtHuyetAp);
            this.grpKetQua.Controls.Add(this.label3);
            this.grpKetQua.Location = new System.Drawing.Point(23, 230);
            this.grpKetQua.Name = "grpKetQua";
            this.grpKetQua.Size = new System.Drawing.Size(600, 270);
            this.grpKetQua.TabIndex = 2;
            this.grpKetQua.TabStop = false;
            this.grpKetQua.Text = "Kết quả Khám lâm sàng";
            // 
            // txtChanDoan
            // 
            this.txtChanDoan.Location = new System.Drawing.Point(130, 90);
            this.txtChanDoan.Multiline = true;
            this.txtChanDoan.Name = "txtChanDoan";
            this.txtChanDoan.Size = new System.Drawing.Size(450, 160);
            this.txtChanDoan.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(20, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Chẩn đoán:";
            // 
            // txtHuyetAp
            // 
            this.txtHuyetAp.Location = new System.Drawing.Point(130, 40);
            this.txtHuyetAp.Name = "txtHuyetAp";
            this.txtHuyetAp.Size = new System.Drawing.Size(200, 27);
            this.txtHuyetAp.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Huyết áp:";
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.txtTrieuChung);
            this.grpThongTin.Controls.Add(this.label2);
            this.grpThongTin.Controls.Add(this.txtTenBN);
            this.grpThongTin.Controls.Add(this.label1);
            this.grpThongTin.Location = new System.Drawing.Point(23, 60);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(600, 150);
            this.grpThongTin.TabIndex = 1;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin Bệnh nhân";
            // 
            // txtTrieuChung
            // 
            this.txtTrieuChung.Location = new System.Drawing.Point(130, 80);
            this.txtTrieuChung.Multiline = true;
            this.txtTrieuChung.Name = "txtTrieuChung";
            this.txtTrieuChung.ReadOnly = true;
            this.txtTrieuChung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTrieuChung.Size = new System.Drawing.Size(450, 50);
            this.txtTrieuChung.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Triệu chứng:";
            // 
            // txtTenBN
            // 
            this.txtTenBN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTenBN.ForeColor = System.Drawing.Color.DarkRed;
            this.txtTenBN.Location = new System.Drawing.Point(130, 35);
            this.txtTenBN.Name = "txtTenBN";
            this.txtTenBN.ReadOnly = true;
            this.txtTenBN.Size = new System.Drawing.Size(450, 29);
            this.txtTenBN.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ và tên:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(229, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÁC SĨ - KHÁM BỆNH";
            // 
            // FormBacSi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FormBacSi";
            this.Text = "Bác Sĩ";
            this.Load += new System.EventHandler(this.FormBacSi_Load);
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoKham)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.grpKetQua.ResumeLayout(false);
            this.grpKetQua.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.ResumeLayout(false);
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