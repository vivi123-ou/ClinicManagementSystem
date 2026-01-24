using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementClient.Helpers
{
    public static class UserSession
    {
        public static string Token { get; set; } = "";
        public static string MaNguoiDung { get; set; } = "";
        public static string HoTen { get; set; } = "";
        public static string VaiTro { get; set; } = ""; // "BacSi", "LeTan", "Admin"
    }

    public static class ApiClient
    {
        private static readonly HttpClient _client = new HttpClient();
        private static string BaseUrl = "https://clinic-api-final.onrender.com/api/";

        public static void SetToken(string token)
        {
            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        public static async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _client.GetAsync(BaseUrl + endpoint);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Lỗi API ({response.StatusCode}): {error}");
            }

            var json = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(json))
            {
                throw new Exception("API trả về dữ liệu trống");
            }
            
            var result = JsonConvert.DeserializeObject<T>(json);
            if (result == null)
            {
                throw new Exception("Không thể phân tích dữ liệu từ API");
            }
            return result;
        }

        // POST trả về HttpResponseMessage (dùng cho Form Thu Ngân)
        public static async Task<HttpResponseMessage> PostAsync(string endpoint, object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PostAsync(BaseUrl + endpoint, content);
        }

        // POST trả về dữ liệu kiểu T (dùng khi cần lấy kết quả từ API)
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
            if (string.IsNullOrEmpty(resultJson))
            {
                throw new Exception("API trả về dữ liệu trống");
            }

            var result = JsonConvert.DeserializeObject<T>(resultJson);
            if (result == null)
            {
                throw new Exception("Không thể phân tích dữ liệu từ API");
            }
            return result;
        }

        public static async Task PutAsync(string endpoint, object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(BaseUrl + endpoint, content);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Lỗi cập nhật ({response.StatusCode}): {error}");
            }
        }
    }
}