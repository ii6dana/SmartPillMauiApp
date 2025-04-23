using SmartPillMauiApp.Models;
using SmartPillMauiApp.Services.Api;
using SmartPillMauiApp.Helpers;

namespace SmartPillMauiApp.Views.User
{
    public partial class UserAddEditPage : ContentPage
    {

        public UserAddEditPage(UserService userService, UserDto existingUser = null)
        {
            InitializeComponent();

        }

    }
}
