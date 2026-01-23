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
                // 1. Gọi API lấy danh sách
                var list = await ApiClient.GetAsync<List<PhieuKhamDetailDTO>>("PhieuKham/my-patients");

                // 2. QUAN TRỌNG: Nếu API trả về null (lỗi hoặc không có dữ liệu), ta gán bằng List rỗng để tránh lỗi
                if (list == null)
                {
                    list = new List<PhieuKhamDetailDTO>();
                }

                // 3. Gán dữ liệu vào lưới
                if (dgvChoKham != null)
                {
                    dgvChoKham.DataSource = list;

                    // 4. Kiểm tra cột có tồn tại không rồi mới ẩn (Code an toàn)
                    if (dgvChoKham.Columns.Contains("MaPhieuKham"))
                    {
                        dgvChoKham.Columns["MaPhieuKham"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message);
            }
        }
        // 2. Khi chọn bệnh nhân từ lưới
        private void dgvChoKham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Nếu click vào tiêu đề cột thì bỏ qua
            if (e.RowIndex < 0) return;

            try
            {
                // 2. Lấy dòng hiện tại
                var row = dgvChoKham.Rows[e.RowIndex];

                // 3. Lấy cục dữ liệu gốc (DTO) của dòng đó
                // (Cách này an toàn hơn dùng row.Cells["TenCot"])
                var item = row.DataBoundItem as PhieuKhamDetailDTO;

                if (item != null)
                {
                    _maPhieuKhamHienTai = item.MaPhieuKham;

                    // 4. Gán thông tin lên màn hình
                    // Mẹo: Gõ "item." rồi chờ gợi ý xem nó là .HoTen hay .TenBenhNhan
                    txtTenBN.Text = item.TenBenhNhan;  // <--- Nếu báo lỗi đỏ, hãy sửa thành item.HoTen
                    txtTrieuChung.Text = item.TrieuChung;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn dòng: " + ex.Message);
            }
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
                await ApiClient.PutAsync($"PhieuKham/{_maPhieuKhamHienTai}/diagnosis", chanDoanDTO);

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

        private void txtTrieuChung_TextChanged(object sender, EventArgs e)
        {

        }
    }
}