using SmartPillMauiApp.Models;
using Newtonsoft.Json;


namespace SmartPillMauiApp.Services.Api
{
    public class AdminAuthenticationService
    {

        private readonly HttpClient _httpClient;
        private const string BaseRoute = "api/AdminAuthentication";

       
        public AdminAuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        

        public async Task<AdminDto> AdminLoginAsync(string accountName, string password)
        {
            string url = $"{BaseRoute}/AdminLogin/{accountName}/{password}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AdminDto>(json);
            }

            return null; 
        }


    }
}
