using SmartPillMauiApp.Models;

namespace SmartPillMauiApp.Helpers
{
    public static class SessionHelper
    {
        public static AdminDto CurrentAdmin { get; private set; }
        public static UserDto CurrentUser { get; private set; }

        public static void SetCurrentAdmin(AdminDto admin)
        {
            CurrentAdmin = admin;
        }

        public static void SetCurrentUser(UserDto user)
        {
            CurrentUser = user;
        }

        public static void LogoutAdmin()
        {
            CurrentAdmin = null;
        }

        public static void LogoutUser()
        {
            CurrentUser = null;
        }
    }
}
