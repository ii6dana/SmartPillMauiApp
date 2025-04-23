using System.Net.Http;
using System.Net.Http.Json;
using SmartPillMauiApp.Models;
using SmartPillMauiApp.Helpers;

namespace SmartPillMauiApp.Services.Api
{
    public class ReminderService
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "https://localhost:5001/api/Reminder";

        public ReminderService()
        {
            var handler = HttpClientHandlerProvider.GetHttpClientHandler();
            _client = new HttpClient(handler);
            _client.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<List<ReminderDto>> GetAllRemindersAsync()
        {
            var response = await _client.GetAsync("GetAll");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<ReminderDto>>();
        }

        public async Task<ReminderDto> GetReminderByIdAsync(int reminderId)
        {
            var response = await _client.GetAsync($"Get/{reminderId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ReminderDto>();
        }

        public async Task AddReminderAsync(ReminderDto reminder)
        {
            var response = await _client.PostAsJsonAsync("Add", reminder);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateReminderAsync(ReminderDto reminder)
        {
            var response = await _client.PutAsJsonAsync("Update", reminder);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteReminderAsync(int reminderId)
        {
            var response = await _client.DeleteAsync($"Delete/{reminderId}");
            response.EnsureSuccessStatusCode();
        }
    }
}
