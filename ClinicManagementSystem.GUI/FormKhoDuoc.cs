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
    public partial class FormKhoDuoc : Form
    {
        private readonly string apiUrl = "https://clinic-api-final.onrender.com/api/thuoc";
        private readonly HttpClient client;

        public FormKhoDuoc()
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
                MessageBox.Show("Không có token xác thực. Vui lòng đăng nhập lại!", "Lỗi xác thực");
            }
        }

        private async void FormKhoDuoc_Load(object sender, EventArgs e)
        {
            await LoadDataGrid();
        }

        private async Task LoadDataGrid()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var danhSachThuoc = JsonConvert.DeserializeObject<List<ThuocModel>>(json);
                    dgvThuoc.DataSource = danhSachThuoc;
                }
                else
                {
                    MessageBox.Show("Không thể tải dữ liệu: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối API: " + ex.Message);
            }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaThuoc.Text) || string.IsNullOrWhiteSpace(txtTenThuoc.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã thuốc và Tên thuốc!", "Cảnh báo");
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
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm thuốc thành công!");
                    await LoadDataGrid();
                    LamMoiInput();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại. Mã lỗi: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaThuoc.Text))
            {
                MessageBox.Show("Vui lòng chọn thuốc cần xóa từ danh sách!");
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn xóa thuốc [{txtTenThuoc.Text}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string deleteUrl = $"{apiUrl}/{txtMaThuoc.Text}";
                    HttpResponseMessage response = await client.DeleteAsync(deleteUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đã xóa thành công!");
                        await LoadDataGrid();
                        LamMoiInput();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại. Mã lỗi: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiInput();
        }

        private void LamMoiInput()
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
            txtMaThuoc.Enabled = true;
        }

        private void dgvThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThuoc.Rows[e.RowIndex];
                txtMaThuoc.Text = row.Cells["MaThuoc"].Value?.ToString();
                txtTenThuoc.Text = row.Cells["TenThuoc"].Value?.ToString();
                txtHoatChat.Text = row.Cells["HoatChat"].Value?.ToString();
                txtDonVi.Text = row.Cells["DonVi"].Value?.ToString();

                if (decimal.TryParse(row.Cells["DonGia"].Value?.ToString(), out decimal donGia))
                    nudDonGia.Value = donGia;

                if (int.TryParse(row.Cells["SoLuongTon"].Value?.ToString(), out int sl))
                    nudSoLuongTon.Value = sl;

                if (DateTime.TryParse(row.Cells["HanSuDung"].Value?.ToString(), out DateTime hsd))
                    dtpHanSuDung.Value = hsd;

                txtNhaSanXuat.Text = row.Cells["NhaSanXuat"].Value?.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();

                txtMaThuoc.Enabled = false;
            }
        }
    }
}