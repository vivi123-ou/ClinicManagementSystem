using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ClinicManagementClient.Helpers
{
    // 1. Lưu thông tin người đang đăng nhập
    public static class UserSession
    {
        public static string Token { get; set; } = "";
        public static string MaNguoiDung { get; set; } = "";
        public static string HoTen { get; set; } = "";
        public static string VaiTro { get; set; } = ""; // "BacSi", "LeTan", "Admin"
    }

    // 2. Class dùng chung để gọi API
    public static class ApiClient
    {
        private static readonly HttpClient _client = new HttpClient();

        // ĐỔI CÁI NÀY THÀNH LINK API TRÊN RENDER CỦA BẠN (Hoặc Localhost nếu đang chạy thử)
        // Ví dụ: "https://clinic-api-final.onrender.com/api/";
        private static string BaseUrl = "https://clinic-api-final.onrender.com/api/";

        public static void SetToken(string token)
        {
            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        // Hàm GET (Lấy dữ liệu)
        public static async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _client.GetAsync(BaseUrl + endpoint);
            if (!response.IsSuccessStatusCode) return default;

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        // Hàm POST (Gửi dữ liệu - Thêm mới)
        public static async Task<T> PostAsync<T>(string endpoint, object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(BaseUrl + endpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Lỗi API ({response.StatusCode}): {error}");
            }

            var resultJson = await response.Content.ReadAsStringAsync();
            // Nếu API trả về rỗng (201 Created) thì trả về default
            if (string.IsNullOrEmpty(resultJson)) return default;

            return JsonConvert.DeserializeObject<T>(resultJson);
        }

        // Hàm PUT (Cập nhật)
        public static async Task PutAsync(string endpoint, object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(BaseUrl + endpoint, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Lỗi cập nhật: " + response.StatusCode);
            }
        }
    }
}