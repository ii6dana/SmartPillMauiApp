using SmartPillMauiApp.Helpers;
using SmartPillMauiApp.Services.Api;
using SmartPillMauiApp.Views.Login;
using SmartPillMauiApp.Views.UserInterfaces;

namespace SmartPillMauiApp.Views.Login
{
    public partial class LoginPage : ContentPage
    {
        private readonly OTPService _otpService;
        private readonly UserService _userService;


        private string _lastOtpCode;

        public LoginPage()
        {
            InitializeComponent();

            // ”Õ» «·Œœ„«  „‰ «·‹ DI (Dependency Injection)
            _otpService = App.Current.Handler.MauiContext.Services.GetService<OTPService>();
            _userService = App.Current.Handler.MauiContext.Services.GetService<UserService>();
        }

        private async void SendOtpButton_Clicked(object sender, EventArgs e)
        {
            var phone = PhoneNumberEntry.Text?.Trim();

            if (string.IsNullOrEmpty(phone))
            {
                await AlertHelper.ShowToastAsync("«·—Ã«¡ ≈œŒ«· —ﬁ„ «·ÃÊ«·");
                return;
            }

            try
            {
                _lastOtpCode = await _otpService.SendOtpToPhoneAsync(phone);
                await AlertHelper.ShowToastAsync($"ﬂÊœ «· Õﬁﬁ: {_lastOtpCode}");
            }
            catch (Exception ex)
            {
                await AlertHelper.ShowToastAsync($"Œÿ√: {ex.Message}");
            }
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            var enteredCode = OtpCodeEntry.Text?.Trim();

            if (string.IsNullOrEmpty(enteredCode))
            {
                await AlertHelper.ShowToastAsync("«·—Ã«¡ ≈œŒ«· ﬂÊœ «· Õﬁﬁ");
                return;
            }

            if (enteredCode?.Trim() == _lastOtpCode?.Trim())
            {
                await AlertHelper.ShowToastAsync(" „  ”ÃÌ· «·œŒÊ· »‰Ã«Õ!");

                

                Application.Current.MainPage = new NavigationPage(new UserShell());


            }



            else
            {
                await AlertHelper.ShowToastAsync("ﬂÊœ «· Õﬁﬁ €Ì— ’ÕÌÕ");
            }

        }

        private async void AdminLabel_Tapped(object sender, TappedEventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AdminLoginPage));
        }

        private void CnvertLoginByEmail(object sender, EventArgs e)
        {

        }
    }
}
