using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManagementClient.Helpers; // dùng UserSession + ApiClient

namespace ClinicManagementClient.Forms
{
    public partial class FormThuNgan : Form
    {
        private readonly string baseUrl = "HoaDon"; // chỉ cần endpoint, ApiClient sẽ tự thêm base URL

        public FormThuNgan()
        {
            InitializeComponent();
            // Đảm bảo token đã được set sau khi login
            ApiClient.SetToken(UserSession.Token);
        }

        // ============================
        // 1. TẠO HÓA ĐƠN MỚI
        // ============================
        private async void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaBenhNhan.Text) || nudTongTien.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập Mã Bệnh Nhân và Tổng Tiền (lớn hơn 0)!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnTaoHoaDon.Enabled = false;
            btnTaoHoaDon.Text = "Đang xử lý...";

            var requestData = new
            {
                maBenhNhan = txtMaBenhNhan.Text,
                tongTien = nudTongTien.Value,
                ghiChu = txtGhiChu.Text,
                trangThai = "ChuaThanhToan",
                ngayLap = DateTime.Now
            };

            try
            {
                // Gọi API tạo hóa đơn
                var response = await ApiClient.PostAsync($"{baseUrl}/create", requestData);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Tạo hóa đơn thành công!", "Thông báo");
                    txtMaBenhNhan.Clear();
                    nudTongTien.Value = 0;
                    txtGhiChu.Clear();
                }
                else
                {
                    MessageBox.Show($"Tạo hóa đơn thất bại. Lỗi: {response.StatusCode}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối tới Server: " + ex.Message, "Lỗi kết nối",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnTaoHoaDon.Enabled = true;
                btnTaoHoaDon.Text = "Tạo Hóa Đơn";
            }
        }

        // ============================
        // 2. THANH TOÁN HÓA ĐƠN
        // ============================
        private async void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHoaDon.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Hóa Đơn cần thanh toán!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xác nhận thu tiền hóa đơn: {txtMaHoaDon.Text}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            btnThanhToan.Enabled = false;
            btnThanhToan.Text = "Đang thanh toán...";

            try
            {
                var response = await ApiClient.PostAsync($"{baseUrl}/{txtMaHoaDon.Text}/pay", new { });

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thanh toán thành công! Trạng thái hóa đơn đã chuyển sang Đã Thanh Toán.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaHoaDon.Clear();
                }
                else
                {
                    MessageBox.Show($"Thanh toán thất bại! Hóa đơn không tồn tại hoặc đã thanh toán.\nMã lỗi: {response.StatusCode}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối tới Server: " + ex.Message, "Lỗi kết nối",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnThanhToan.Enabled = true;
                btnThanhToan.Text = "Xác Nhận Đã Thu Tiền";
            }
        }
    }
}