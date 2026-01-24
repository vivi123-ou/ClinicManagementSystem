using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using ClinicManagementSystem.GUI.Helpers; // để dùng SessionData

namespace ClinicManagementSystem.GUI
{
    public partial class FormAdmin : Form
    {
        private readonly string apiUserUrl = "https://clinic-api-final.onrender.com/api/Auth/register";
        private readonly string apiThuocUrl = "https://clinic-api-final.onrender.com/api/thuoc";
        private readonly HttpClient client;

        public FormAdmin()
        {
            InitializeComponent();
            client = new HttpClient();

            if (!string.IsNullOrEmpty(SessionData.JwtToken))
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", SessionData.JwtToken);
            }
            else
            {
                MessageBox.Show("Bạn chưa đăng nhập hoặc token hết hạn!", "Lỗi xác thực");
            }
        }

        // ============================
        // 1. TẠO TÀI KHOẢN NHÂN VIÊN
        // ============================
        private async void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            var newUser = new
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                HoTen = txtHoTen.Text,
                VaiTro = cboVaiTro.SelectedItem?.ToString()
            };

            string json = JsonConvert.SerializeObject(newUser);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync(apiUserUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Tạo tài khoản thành công!");
                    LamMoiUserInput();
                }
                else
                {
                    MessageBox.Show("Tạo tài khoản thất bại. Lỗi: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối API: " + ex.Message);
            }
        }

        private void LamMoiUserInput()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtHoTen.Clear();
            cboVaiTro.SelectedIndex = -1;
        }

        // ============================
        // 2. QUẢN LÝ DANH SÁCH THUỐC
        // ============================
        private async void FormAdmin_Load(object sender, EventArgs e)
        {
            await LoadThuoc();
        }

        private async Task LoadThuoc()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiThuocUrl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var danhSachThuoc = JsonConvert.DeserializeObject<List<ThuocModel>>(json);
                    dgvThuoc.DataSource = danhSachThuoc;
                }
                else
                {
                    MessageBox.Show("Không thể tải danh sách thuốc. Lỗi: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối API: " + ex.Message);
            }
        }

        private async void btnThemThuoc_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtMaThuoc.Text))
            {
                MessageBox.Show("Vui lòng nhập mã thuốc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenThuoc.Text))
            {
                MessageBox.Show("Vui lòng nhập tên thuốc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newThuoc = new ThuocModel
            {
                MaThuoc = txtMaThuoc.Text,
                TenThuoc = txtTenThuoc.Text,
                HoatChat = txtHoatChat.Text,
                DonVi = txtDonVi.Text,
                DonGia = nudDonGia.Value,
                SoLuongTon = (int)nudSoLuongTon.Value,
                HanSuDung = dtpHanSuDung.Value.ToUniversalTime(),
                NhaSanXuat = txtNhaSanXuat.Text,
                GhiChu = txtGhiChu.Text
            };

            string json = JsonConvert.SerializeObject(newThuoc);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync(apiThuocUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm thuốc thành công!");
                    await LoadThuoc();
                    LamMoiThuocInput();
                }
                else
                {
                    MessageBox.Show("Thêm thuốc thất bại. Lỗi: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private async void btnXoaThuoc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaThuoc.Text))
            {
                MessageBox.Show("Vui lòng chọn thuốc cần xóa!");
                return;
            }

            string deleteUrl = $"{apiThuocUrl}/{txtMaThuoc.Text}";
            HttpResponseMessage response = await client.DeleteAsync(deleteUrl);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Xóa thuốc thành công!");
                await LoadThuoc();
                LamMoiThuocInput();
            }
            else
            {
                MessageBox.Show("Xóa thất bại. Lỗi: " + response.StatusCode);
            }
        }

        private void LamMoiThuocInput()
        {
            txtMaThuoc.Clear();
            txtTenThuoc.Clear();
            txtHoatChat.Clear();
            txtDonVi.Clear();
            nudDonGia.Value = 0;
            nudSoLuongTon.Value = 0;
            dtpHanSuDung.Value = DateTime.Now;
            txtNhaSanXuat.Clear();
            txtGhiChu.Clear();
        }
    }

    // Model thuốc
    public class ThuocModel
    {
        public required string MaThuoc { get; set; }
        public required string TenThuoc { get; set; }
        public required string HoatChat { get; set; }
        public required string DonVi { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuongTon { get; set; }
        public DateTime HanSuDung { get; set; }
        public required string NhaSanXuat { get; set; }
        public required string GhiChu { get; set; }
    }
}