using System.Net.Http;

namespace SmartPillMauiApp.Helpers
{
    public class HttpClientHandlerProvider
    {

        public static HttpClientHandler GetHttpClientHandler()
        {
            var handler = new HttpClientHandler();
            // تخطي الشهادة:
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            return handler;
        }


    }
}
