using ClinicManagementClient.Helpers;
using ClinicManagement.Common.DTOs;

namespace ClinicManagementClient.Forms
{
    public partial class FormBacSi : Form
    {
        private string? _maPhieuKhamHienTai;

        public FormBacSi()
        {
            InitializeComponent();
        }

        private async void FormBacSi_Load(object sender, EventArgs e)
        {
            // Lấy mã bác sĩ từ Session đăng nhập
            string maBacSi = UserSession.MaNguoiDung;
            await LoadDanhSachChoKham(maBacSi);
        }

        // 1. Lấy danh sách chờ [Theo quy trình file Word 1733]
        private async Task LoadDanhSachChoKham(string maBacSi)
        {
            try
            {
                // Gọi API bạn vừa viết xong: GET /api/PhieuKham/bac-si/{id}
                var list = await ApiClient.GetAsync<List<PhieuKhamDetailDTO>>($"PhieuKham/bac-si/{maBacSi}");
                dgvChoKham.DataSource = list;

                // Ẩn cột không cần thiết
                dgvChoKham.Columns["MaPhieuKham"].Visible = false;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh sách: " + ex.Message); }
        }

        // 2. Khi chọn bệnh nhân từ lưới
        private void dgvChoKham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvChoKham.Rows[e.RowIndex];
            _maPhieuKhamHienTai = row.Cells["MaPhieuKham"].Value.ToString();

            // Hiện thông tin lên các ô nhập
            txtTenBN.Text = row.Cells["TenBenhNhan"].Value.ToString();
            txtTrieuChung.Text = row.Cells["TrieuChung"].Value?.ToString();
        }

        // 3. Lưu Chẩn Đoán (Quan trọng) [Theo quy trình file Word 1738]
        private async void btnLuuBenhAn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maPhieuKhamHienTai)) return;

            try
            {
                var chanDoanDTO = new ChanDoanDTO
                {
                    ChanDoan = txtChanDoan.Text,
                    HuyetAp = txtHuyetAp.Text,
                    // Các chỉ số khác...
                };

                // Gọi API PUT /api/PhieuKham/{id}/chan-doan
                await ApiClient.PutAsync($"PhieuKham/{_maPhieuKhamHienTai}/chan-doan", chanDoanDTO);

                MessageBox.Show("Đã lưu bệnh án thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu bệnh án: " + ex.Message);
            }
        }

        // 4. Hoàn thành khám [Theo quy trình file Word 1741]
        private async void btnHoanThanh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maPhieuKhamHienTai)) return;

            try
            {
                // Gọi API chuyển trạng thái thành "Đã khám xong"
                await ApiClient.PostAsync<object>($"PhieuKham/{_maPhieuKhamHienTai}/complete", null);

                MessageBox.Show("Ca khám hoàn tất. Mời bệnh nhân tiếp theo.");

                // Refresh lại danh sách
                await LoadDanhSachChoKham(UserSession.MaNguoiDung);
                ClearForm();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void ClearForm()
        {
            txtTenBN.Clear();
            txtTrieuChung.Clear();
            txtChanDoan.Clear();
            txtHuyetAp.Clear();
            _maPhieuKhamHienTai = null;
        }
    }
}