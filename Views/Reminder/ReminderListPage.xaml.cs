using SmartPillMauiApp.Models;
using SmartPillMauiApp.Services.Api;
using SmartPillMauiApp.Helpers;

namespace SmartPillMauiApp.Views.Reminder
{
    public partial class ReminderListPage : ContentPage
    {
        private readonly ReminderService _reminderService;
        public List<ReminderDto> ReminderList { get; set; } = new List<ReminderDto>();

        public ReminderListPage(ReminderService reminderService)
        {
            InitializeComponent();
            _reminderService = reminderService;
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadReminders();
        }

        private async Task LoadReminders()
        {
            try
            {
                ReminderList = await _reminderService.GetAllRemindersAsync();
                OnPropertyChanged(nameof(ReminderList));
            }
            catch (Exception ex)
            {
                await AlertHelper.ShowToastAsync($"Œÿ√ √À‰«¡ «· Õ„Ì·: {ex.Message}");
            }
        }

        private async void AddReminderButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReminderAddEditPage(_reminderService));
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                var selectedReminder = e.CurrentSelection[0] as ReminderDto;
                if (selectedReminder != null)
                {
                    await Navigation.PushAsync(new ReminderAddEditPage(_reminderService, selectedReminder));
                }
                ((CollectionView)sender).SelectedItem = null;
            }
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var reminderId = (int)button.CommandParameter;

            bool confirm = await DisplayAlert(" √ﬂÌœ «·Õ–›",
                "Â· √‰  „ √ﬂœ √‰ﬂ  —Ìœ Õ–› Â–« «· ‰»ÌÂø", "‰⁄„", "·«");
            if (!confirm) return;

            try
            {
                await _reminderService.DeleteReminderAsync(reminderId);
                await AlertHelper.ShowToastAsync(" „ Õ–› «· ‰»ÌÂ »‰Ã«Õ");
                await LoadReminders();
            }
            catch (Exception ex)
            {
                await AlertHelper.ShowToastAsync($"Œÿ√ √À‰«¡ «·Õ–›: {ex.Message}");
            }
        }
    }
}
