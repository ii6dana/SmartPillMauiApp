using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using SmartPillMauiApp.Helpers;

namespace SmartPillMauiApp.Services
{
    public class ImageService
    {
        //private readonly HttpClient _httpClient;
        //private const string UploadUrl = "https://10.0.2.2:7216/api/Images/Upload"; // غيّر الرابط حسب API الحقيقي

        //public ImageService()
        //{
        //   // _httpClient = HttpClientHandlerProvider.GetHttpClientHandler(); // تجاوز الشهادة لو كان محلي
        //}

        //public async Task<string> UploadImageAsync(FileResult file, string folderName)
        //{
        //    if (file == null)
        //        return null;

        //    using var content = new MultipartFormDataContent();
        //    using var fileStream = await file.OpenReadAsync();
        //    var streamContent = new StreamContent(fileStream);
        //    streamContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");

        //    content.Add(streamContent, "file", file.FileName);
        //    content.Add(new StringContent(folderName), "folderName");

        //    var response = await _httpClient.PostAsync(UploadUrl, content);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return await response.Content.ReadAsStringAsync(); // اسم الصورة أو رابطها
        //    }

        //    return null;
        //}
    }
}
