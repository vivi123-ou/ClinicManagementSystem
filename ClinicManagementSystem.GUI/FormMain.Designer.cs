namespace ClinicManagementClient.Forms
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlMenu = new Panel();
            btnThuNgan = new Button();
            btnAdmin = new Button();
            btnDuoc = new Button();
            btnKhamBenh = new Button();
            btnTiepDon = new Button();
            pnlLogo = new Panel();
            lblAppName = new Label();
            pnlHeader = new Panel();
            btnDangXuat = new Button();
            lblUserInfo = new Label();
            pnlContent = new Panel();
            pnlMenu.SuspendLayout();
            pnlLogo.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(51, 51, 76);
            pnlMenu.Controls.Add(btnThuNgan);
            pnlMenu.Controls.Add(btnAdmin);
            pnlMenu.Controls.Add(btnDuoc);
            pnlMenu.Controls.Add(btnKhamBenh);
            pnlMenu.Controls.Add(btnTiepDon);
            pnlMenu.Controls.Add(pnlLogo);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Margin = new Padding(3, 4, 3, 4);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(251, 800);
            pnlMenu.TabIndex = 0;
            // 
            // btnThuNgan
            // 
            btnThuNgan.Dock = DockStyle.Top;
            btnThuNgan.FlatAppearance.BorderSize = 0;
            btnThuNgan.FlatStyle = FlatStyle.Flat;
            btnThuNgan.Font = new Font("Segoe UI", 10F);
            btnThuNgan.ForeColor = Color.Gainsboro;
            btnThuNgan.Location = new Point(0, 453);
            btnThuNgan.Margin = new Padding(3, 4, 3, 4);
            btnThuNgan.Name = "btnThuNgan";
            btnThuNgan.Padding = new Padding(14, 0, 0, 0);
            btnThuNgan.Size = new Size(251, 80);
            btnThuNgan.TabIndex = 5;
            btnThuNgan.Text = "   Thu Ngân";
            btnThuNgan.TextAlign = ContentAlignment.MiddleLeft;
            btnThuNgan.UseVisualStyleBackColor = true;
            btnThuNgan.Click += btnThuNgan_Click;
            // 
            // btnAdmin
            // 
            btnAdmin.Dock = DockStyle.Top;
            btnAdmin.FlatAppearance.BorderSize = 0;
            btnAdmin.FlatStyle = FlatStyle.Flat;
            btnAdmin.Font = new Font("Segoe UI", 10F);
            btnAdmin.ForeColor = Color.Gainsboro;
            btnAdmin.Location = new Point(0, 373);
            btnAdmin.Margin = new Padding(3, 4, 3, 4);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Padding = new Padding(14, 0, 0, 0);
            btnAdmin.Size = new Size(251, 80);
            btnAdmin.TabIndex = 4;
            btnAdmin.Text = "   Quản trị (Admin)";
            btnAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // btnDuoc
            // 
            btnDuoc.Dock = DockStyle.Top;
            btnDuoc.FlatAppearance.BorderSize = 0;
            btnDuoc.FlatStyle = FlatStyle.Flat;
            btnDuoc.Font = new Font("Segoe UI", 10F);
            btnDuoc.ForeColor = Color.Gainsboro;
            btnDuoc.Location = new Point(0, 280);
            btnDuoc.Margin = new Padding(3, 4, 3, 4);
            btnDuoc.Name = "btnDuoc";
            btnDuoc.Padding = new Padding(14, 0, 0, 0);
            btnDuoc.Size = new Size(251, 93);
            btnDuoc.TabIndex = 2;
            btnDuoc.Text = "   Kho Dược";
            btnDuoc.TextAlign = ContentAlignment.MiddleLeft;
            btnDuoc.UseVisualStyleBackColor = true;
            btnDuoc.Click += btnDuoc_Click;
            // 
            // btnKhamBenh
            // 
            btnKhamBenh.Dock = DockStyle.Top;
            btnKhamBenh.FlatAppearance.BorderSize = 0;
            btnKhamBenh.FlatStyle = FlatStyle.Flat;
            btnKhamBenh.Font = new Font("Segoe UI", 10F);
            btnKhamBenh.ForeColor = Color.Gainsboro;
            btnKhamBenh.Location = new Point(0, 187);
            btnKhamBenh.Margin = new Padding(3, 4, 3, 4);
            btnKhamBenh.Name = "btnKhamBenh";
            btnKhamBenh.Padding = new Padding(14, 0, 0, 0);
            btnKhamBenh.Size = new Size(251, 93);
            btnKhamBenh.TabIndex = 2;
            btnKhamBenh.Text = "   Khám bệnh (Bác sĩ)";
            btnKhamBenh.TextAlign = ContentAlignment.MiddleLeft;
            btnKhamBenh.UseVisualStyleBackColor = true;
            btnKhamBenh.Click += btnKhamBenh_Click;
            // 
            // btnTiepDon
            // 
            btnTiepDon.Dock = DockStyle.Top;
            btnTiepDon.FlatAppearance.BorderSize = 0;
            btnTiepDon.FlatStyle = FlatStyle.Flat;
            btnTiepDon.Font = new Font("Segoe UI", 10F);
            btnTiepDon.ForeColor = Color.Gainsboro;
            btnTiepDon.Location = new Point(0, 107);
            btnTiepDon.Margin = new Padding(3, 4, 3, 4);
            btnTiepDon.Name = "btnTiepDon";
            btnTiepDon.Padding = new Padding(14, 0, 0, 0);
            btnTiepDon.Size = new Size(251, 80);
            btnTiepDon.TabIndex = 1;
            btnTiepDon.Text = "   Tiếp đón (Lễ tân)";
            btnTiepDon.TextAlign = ContentAlignment.MiddleLeft;
            btnTiepDon.UseVisualStyleBackColor = true;
            btnTiepDon.Click += btnTiepDon_Click;
            // 
            // pnlLogo
            // 
            pnlLogo.BackColor = Color.FromArgb(39, 39, 58);
            pnlLogo.Controls.Add(lblAppName);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Margin = new Padding(3, 4, 3, 4);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(251, 107);
            pnlLogo.TabIndex = 0;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(34, 40);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(185, 28);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "PHÒNG KHÁM TƯ";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(0, 150, 136);
            pnlHeader.Controls.Add(btnDangXuat);
            pnlHeader.Controls.Add(lblUserInfo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(251, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(892, 107);
            pnlHeader.TabIndex = 1;
            // 
            // btnDangXuat
            // 
            btnDangXuat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDangXuat.BackColor = Color.Firebrick;
            btnDangXuat.FlatAppearance.BorderSize = 0;
            btnDangXuat.FlatStyle = FlatStyle.Flat;
            btnDangXuat.ForeColor = Color.White;
            btnDangXuat.Location = new Point(744, 33);
            btnDangXuat.Margin = new Padding(3, 4, 3, 4);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(114, 40);
            btnDangXuat.TabIndex = 1;
            btnDangXuat.Text = "Đăng xuất";
            btnDangXuat.UseVisualStyleBackColor = false;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // lblUserInfo
            // 
            lblUserInfo.AutoSize = true;
            lblUserInfo.Font = new Font("Segoe UI", 11F);
            lblUserInfo.ForeColor = Color.White;
            lblUserInfo.Location = new Point(34, 40);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(155, 25);
            lblUserInfo.TabIndex = 0;
            lblUserInfo.Text = "Xin chào: ADMIN";
            // 
            // pnlContent
            // 
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(251, 107);
            pnlContent.Margin = new Padding(3, 4, 3, 4);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(892, 693);
            pnlContent.TabIndex = 2;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 800);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Controls.Add(pnlMenu);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống Quản lý Phòng khám";
            Load += FormMain_Load;
            pnlMenu.ResumeLayout(false);
            pnlLogo.ResumeLayout(false);
            pnlLogo.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnDuoc;
        private System.Windows.Forms.Button btnKhamBenh;
        private System.Windows.Forms.Button btnTiepDon;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Panel pnlContent;
        private Button btnThuNgan;
    }
}