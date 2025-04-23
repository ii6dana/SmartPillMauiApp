using System.Net.Http;
using System.Threading.Tasks;

namespace SmartPillMauiApp.Services.Api
{
    public class OTPService
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "https://10.0.2.2:5001/api/SendOtpToPhone/send";

        public OTPService(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> SendOtpToPhoneAsync(string phoneNumber)
        {
            var response = await _client.GetAsync($"{BaseUrl}?phoneNumber={phoneNumber}");
            response.EnsureSuccessStatusCode();

            var code = await response.Content.ReadAsStringAsync();
            return code;
        }
    }
}
