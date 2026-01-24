using ClinicManagementClient.Helpers;
using ClinicManagementSystem.GUI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementClient.Forms
{
    public partial class FormMain : Form
    {
        private Form? activeForm = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Hiển thị tên người dùng đang đăng nhập
            lblUserInfo.Text = $"Xin chào: {UserSession.HoTen} ({UserSession.VaiTro})";

            // Phân quyền: Ẩn/Hiện nút dựa trên vai trò
            ApplyAuthorization();
        }

        private void ApplyAuthorization()
        {
            // Mặc định ẩn hết để bảo mật
            btnAdmin.Visible = false;
            btnKhamBenh.Visible = false;
            btnTiepDon.Visible = false;
            btnDuoc.Visible = false;

            // Bật lên tùy theo vai trò
            string role = UserSession.VaiTro;

            if (role == "Admin")
            {
                btnAdmin.Visible = true;
                btnKhamBenh.Visible = true;
                btnTiepDon.Visible = true;
                btnDuoc.Visible = true;
            }
            else if (role == "BacSi")
            {
                btnKhamBenh.Visible = true;
                // Bác sĩ có thể cần xem thuốc
                btnDuoc.Visible = true;
            }
            else if (role == "LeTan")
            {
                btnTiepDon.Visible = true;
            }
            else if (role == "DuocSi" || role == "ThuNgan")
            {
                btnDuoc.Visible = true;
            }
        }

        // Hàm dùng chung để mở Form con (MDI style nhưng dùng Panel)
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // --- XỬ LÝ SỰ KIỆN CLICK MENU ---

        private void btnTiepDon_Click(object sender, EventArgs e)
        {
            // Mở Form Lễ tân
            OpenChildForm(new FormLeTan());
            HighlightButton(btnTiepDon);
        }

        private void btnKhamBenh_Click(object sender, EventArgs e)
        {
            // Mở Form Bác sĩ
            OpenChildForm(new FormBacSi());
            HighlightButton(btnKhamBenh);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            // Xóa thông tin Session
            UserSession.Token = "";
            UserSession.MaNguoiDung = "";

            // Đóng Form Main -> Quay về Login (Do Login gọi ShowDialog hoặc Main gọi)
            this.Close();
        }

        // Hiệu ứng làm nổi bật nút đang chọn
        private void HighlightButton(Button btn)
        {
            // Reset màu các nút khác (về màu gốc của menu)
            btnAdmin.BackColor = Color.FromArgb(51, 51, 76);
            btnDuoc.BackColor = Color.FromArgb(51, 51, 76);
            btnKhamBenh.BackColor = Color.FromArgb(51, 51, 76);
            btnTiepDon.BackColor = Color.FromArgb(51, 51, 76);

            // Đổi màu nút được chọn
            btn.BackColor = Color.FromArgb(0, 150, 136);
        }

        private void btnDuoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormKhoDuoc());
            HighlightButton(btnKhamBenh);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAdmin());
            HighlightButton(btnKhamBenh);
        }

        private void btnThuNgan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormThuNgan());
            HighlightButton(btnKhamBenh);
        }
    }
}