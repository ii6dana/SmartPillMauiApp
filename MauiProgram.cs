using SmartPillMauiApp.Helpers;
using SmartPillMauiApp.Services.Api;
using SmartPillMauiApp.Views.Admin;
using SmartPillMauiApp.Views;
using SmartPillMauiApp.Views.Login;
using CommunityToolkit.Maui;
using Microsoft.Maui.Controls;

namespace SmartPillMauiApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Alexandria-SemiBold.ttf", "AlexandriaSemiBold");
                });

            // تخطي الشهادة - الحصول على HttpClientHandler من Helper
            var handler = HttpClientHandlerProvider.GetHttpClientHandler();
            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://10.0.2.2:5001/") // أو أي عنوان API آخر
            };

            // سجل HttpClient كـ Singleton
            builder.Services.AddSingleton(httpClient);

            // سجل الخدمات الأخرى
            builder.Services.AddSingleton<AdminService>();
            builder.Services.AddSingleton<UserService>();
            builder.Services.AddSingleton<ReminderService>();
            builder.Services.AddSingleton<CaregiverService>();
            builder.Services.AddSingleton<OTPService>();
           

            // سجل الصفحات إذا كنت تريد التنقل بواسطة DI
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<AdminLoginPage>();
           


            return builder.Build();
        }
    }
}
