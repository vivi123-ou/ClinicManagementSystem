using ClinicManagement.Common.DTOs;
using ClinicManagementClient.Helpers;
using System.Windows.Forms;

namespace ClinicManagementClient.Forms
{
    public partial class FormLeTan : Form
    {
        private BenhNhanDTO? _currentBenhNhan; // Lưu bệnh nhân đang chọn

        public FormLeTan()
        {
            InitializeComponent();
        }

        private void FormLeTan_Load(object sender, EventArgs e)
        {
            LoadDanhSachBacSi(); // Tự viết hàm load combobox giả hoặc gọi API User
        }

        // 1. Tìm kiếm bệnh nhân [Theo quy trình file Word 1683]
        private async void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                var keyword = txtTimKiem.Text.Trim();
                // Gọi API tìm kiếm
                var results = await ApiClient.GetAsync<List<BenhNhanDTO>>($"BenhNhan/search?keyword={keyword}");

                if (results != null && results.Count > 0)
                {
                    _currentBenhNhan = results[0]; // Lấy người đầu tiên tìm thấy
                    FillData(_currentBenhNhan);
                    MessageBox.Show("Đã tìm thấy bệnh nhân cũ!");
                }
                else
                {
                    _currentBenhNhan = null;
                    ClearData();
                    MessageBox.Show("Không tìm thấy. Vui lòng nhập thông tin mới.");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // 2. Nút Tạo Phiếu Khám [Theo quy trình file Word 1696]
        private async void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                // Bước A: Nếu là bệnh nhân mới -> Gọi API tạo bệnh nhân trước
                if (_currentBenhNhan == null)
                {
                    var newBN = new BenhNhanDTO
                    {
                        HoTen = txtHoTen.Text,
                        SoDienThoai = txtSDT.Text,
                        DiaChi = txtDiaChi.Text,
                        // Thêm các trường khác...
                    };
                    // Gọi API POST BenhNhan
                    _currentBenhNhan = await ApiClient.PostAsync<BenhNhanDTO>("BenhNhan", newBN);
                }

                // Bước B: Tạo phiếu khám
                var phieuKhamDTO = new PhieuKhamCreateDTO
                {
                    MaBenhNhan = _currentBenhNhan.MaBenhNhan,
                    MaBacSi = cboBacSi.SelectedValue.ToString(), // ID Bác sĩ chọn từ combo
                    TrieuChung = "Đăng ký khám ban đầu"
                };

                // Gọi API POST PhieuKham
                await ApiClient.PostAsync<object>("PhieuKham", phieuKhamDTO);

                MessageBox.Show($"Đã tạo phiếu chờ cho BN: {_currentBenhNhan.HoTen}");
                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo phiếu: " + ex.Message);
            }
        }

        // --- Các hàm phụ trợ ---
        private void FillData(BenhNhanDTO bn) { txtHoTen.Text = bn.HoTen; txtSDT.Text = bn.SoDienThoai; }
        private void ClearData() { txtHoTen.Clear(); txtSDT.Clear(); txtDiaChi.Clear(); _currentBenhNhan = null; }
        private void LoadDanhSachBacSi()
        {
            // Tạm thời add cứng để test, sau này gọi API lấy list bác sĩ
            // 👇 SỬA LẠI DÒNG NÀY (Thêm dấu cách sau chữ new)
            var listBS = new List<dynamic> { new { Id = "ND002", Name = "Bác sĩ Minh" } };

            cboBacSi.DataSource = listBS;
            cboBacSi.DisplayMember = "Name";
            cboBacSi.ValueMember = "Id";
        }
    }
}