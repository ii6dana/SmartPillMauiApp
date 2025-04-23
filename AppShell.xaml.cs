using SmartPillMauiApp.Views;
using SmartPillMauiApp.Views.Admin;
using SmartPillMauiApp.Views.Caregiver;
using SmartPillMauiApp.Views.Login;
using SmartPillMauiApp.Views.Reminder;
using SmartPillMauiApp.Views.User;

namespace SmartPillMauiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // نسجل الصفحات عشان نقدر نروح لها بـ GoToAsync
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            //Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            //Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(AdminLoginPage), typeof(AdminLoginPage));
            Routing.RegisterRoute(nameof(AdminListPage), typeof(AdminListPage));
            Routing.RegisterRoute(nameof(UserListPage), typeof(UserListPage));
            Routing.RegisterRoute(nameof(ReminderAddEditPage), typeof(ReminderAddEditPage));
            Routing.RegisterRoute(nameof(ReminderListPage), typeof(ReminderListPage));
            Routing.RegisterRoute(nameof(CaregiverListPage), typeof(CaregiverListPage));

            Items.Add(new ShellContent
            {
                Content = new MainPage()
            });


        }
    }
}
