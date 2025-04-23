using Newtonsoft.Json;
using SmartPillMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SmartPillMauiApp.Services.Api
{
    public class UserAuthentication
    {

        private readonly HttpClient _httpClient;
        private const string BaseRoute = "api/UserAuthentication";


        public UserAuthentication(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<UserDto> AdminLoginAsync(string userPasswordOrEmail, string InfoType)
        {
            string url = $"{BaseRoute}/AdminLogin/{userPasswordOrEmail}/{InfoType}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserDto>(json);
            }

            return null; 
        }


    }
}
