using ClinicManagementClient.Helpers;
using ClinicManagementSystem.GUI.Helpers;
using ClinicManagement.Common.DTOs; // Sử dụng DTO chung 

namespace ClinicManagementClient.Forms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Validate dữ liệu
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnLogin.Enabled = false;
                btnLogin.Text = "Đang xử lý...";

                // 2. Tạo gói tin Login
                var request = new LoginRequestDTO
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text
                };

                // 3. Gọi API đăng nhập
                // Lưu ý: Kết quả trả về là LoginResponseDTO
                var response = await ApiClient.PostAsync<LoginResponseDTO>("Auth/login", request);

                if (response != null)
                {
                    SessionData.JwtToken = response.Token;
                    // 4. Lưu thông tin vào Session
                    UserSession.Token = response.Token;
                    UserSession.MaNguoiDung = response.MaNguoiDung;
                    UserSession.HoTen = response.HoTen;
                    UserSession.VaiTro = response.VaiTro;

                    // Set token cho các request sau này
                    ApiClient.SetToken(response.Token);

                    MessageBox.Show($"Đăng nhập thành công!\nXin chào: {response.HoTen}", "Thông báo");

                    // 5. Mở Form Main và ẩn Form Login
                    var mainForm = new FormMain();
                    this.Hide();
                    mainForm.ShowDialog(); // Dùng ShowDialog để khi đóng Main thì Login cũng đóng
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đăng nhập thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "ĐĂNG NHẬP";
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Ẩn hiện mật khẩu
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
        }
    }
}