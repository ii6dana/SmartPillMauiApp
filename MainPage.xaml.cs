using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using SmartPillMauiApp.Views;
using SmartPillMauiApp.Services.Api;
using SmartPillMauiApp.Views.Login;

namespace SmartPillMauiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigateToLogin();
        }

        private async void NavigateToLogin()
        {
            await Task.Delay(3000); // 3 ثواني
            Application.Current.MainPage = new NavigationPage(new LoginPage());




        }
    }

}
