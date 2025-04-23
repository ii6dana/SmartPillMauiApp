using System.Net.Http;
using System.Net.Http.Json;
using SmartPillMauiApp.Models;
using SmartPillMauiApp.Helpers;

namespace SmartPillMauiApp.Services.Api
{
    public class UserService
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "https://localhost:5001/api/Users";

        public UserService()
        {
            var handler = HttpClientHandlerProvider.GetHttpClientHandler();
            _client = new HttpClient(handler);
            _client.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var response = await _client.GetAsync("GetAll");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<UserDto>>();
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            var response = await _client.GetAsync($"Get/{userId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserDto>();
        }

        public async Task AddUserAsync(UserDto user)
        {
            var response = await _client.PostAsJsonAsync("Add", user);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateUserAsync(UserDto user)
        {
            var response = await _client.PutAsJsonAsync("Update", user);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var response = await _client.DeleteAsync($"Delete/{userId}");
            response.EnsureSuccessStatusCode();
        }
    }
}
