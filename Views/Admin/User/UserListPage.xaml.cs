using SmartPillMauiApp.Models;
using SmartPillMauiApp.Services.Api;
using SmartPillMauiApp.Helpers;

namespace SmartPillMauiApp.Views.User
{
    public partial class UserListPage : ContentPage
    {
        
        public UserListPage(UserService userService)
        {
            InitializeComponent();
           
        }

    }
}
