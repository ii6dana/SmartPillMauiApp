using System.Net.Http;
using System.Net.Http.Json;
using SmartPillMauiApp.Models;
using SmartPillMauiApp.Helpers;

namespace SmartPillMauiApp.Services.Api
{
    public class CaregiverService
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "https://localhost:5001/api/Caregivers";

        public CaregiverService()
        {
            var handler = HttpClientHandlerProvider.GetHttpClientHandler();
            _client = new HttpClient(handler);
            _client.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<List<CaregiverDto>> GetAllCaregiversAsync()
        {
            var response = await _client.GetAsync("GetAll");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<CaregiverDto>>();
        }

        public async Task<CaregiverDto> GetCaregiverByIdAsync(int caregiverId)
        {
            var response = await _client.GetAsync($"Get/{caregiverId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CaregiverDto>();
        }

        public async Task AddCaregiverAsync(CaregiverDto caregiver)
        {
            var response = await _client.PostAsJsonAsync("Add", caregiver);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateCaregiverAsync(CaregiverDto caregiver)
        {
            var response = await _client.PutAsJsonAsync("Update", caregiver);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCaregiverAsync(int caregiverId)
        {
            var response = await _client.DeleteAsync($"Delete/{caregiverId}");
            response.EnsureSuccessStatusCode();
        }

        // جلب مزودي الرعاية حسب معرف المستخدم الذي يتلقى الرعاية
        public async Task<List<CaregiverDto>> GetProvidersByUserReceivesCareIDAsync(int userReceivesCareID)
        {
            var response = await _client.GetAsync($"ByUserReceivesCare/{userReceivesCareID}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<CaregiverDto>>();
        }

        // جلب المستخدمين الذين يتلقون الرعاية حسب معرف مزود الرعاية
        public async Task<List<CaregiverDto>> GetUserReceivesCareByProviderIDAsync(int providerID)
        {
            var response = await _client.GetAsync($"ByProviderID/{providerID}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<CaregiverDto>>();
        }
    }
}
