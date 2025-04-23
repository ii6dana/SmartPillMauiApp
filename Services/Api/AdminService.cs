using System.Net.Http;
using System.Net.Http.Json;
using SmartPillMauiApp.Models;

namespace SmartPillMauiApp.Services.Api
{
    public class AdminService
    {
        private readonly HttpClient _client;
        private const string BaseRoute = "api/Admin";

        public AdminService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<AdminDto>> GetAllAdminsAsync()
        {
            var response = await _client.GetAsync($"{BaseRoute}/GetAll");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<AdminDto>>();
        }

        public async Task<AdminDto> GetAdminByIdAsync(int adminId)
        {
            var response = await _client.GetAsync($"{BaseRoute}/Get/{adminId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<AdminDto>();
        }

        public async Task AddAdminAsync(AdminDto admin)
        {
            var response = await _client.PostAsJsonAsync($"{BaseRoute}/Add", admin);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAdminAsync(AdminDto admin)
        {
            var response = await _client.PutAsJsonAsync($"{BaseRoute}/Update", admin);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAdminAsync(int adminId)
        {
            var response = await _client.DeleteAsync($"{BaseRoute}/Delete/{adminId}");
            response.EnsureSuccessStatusCode();
        }
    }
}
