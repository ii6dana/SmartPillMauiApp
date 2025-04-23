using SmartPillMauiApp.Models;
using SmartPillMauiApp.Services.Api;
using SmartPillMauiApp.Helpers;

namespace SmartPillMauiApp.Views.Reminder
{
    public partial class ReminderAddEditPage : ContentPage
    {
        private readonly ReminderService _reminderService;
        public ReminderDto ReminderItem { get; set; } = new ReminderDto();
        private bool _isEdit = false;

        public ReminderAddEditPage(ReminderService reminderService, ReminderDto existingReminder = null)
        {
            InitializeComponent();
            _reminderService = reminderService;

            if (existingReminder != null)
            {
                ReminderItem = existingReminder;
                _isEdit = true;
                Title = " ⁄œÌ· «· ‰»ÌÂ";
            }
            else
            {
                Title = "≈÷«›…  ‰»ÌÂ ÃœÌœ";
            }

            BindingContext = this;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (_isEdit)
                {
                    await _reminderService.UpdateReminderAsync(ReminderItem);
                    await AlertHelper.ShowToastAsync(" „  ⁄œÌ· «· ‰»ÌÂ »‰Ã«Õ");
                }
                else
                {
                    await _reminderService.AddReminderAsync(ReminderItem);
                    await AlertHelper.ShowToastAsync(" „  ≈÷«›… «· ‰»ÌÂ »‰Ã«Õ");
                }

                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await AlertHelper.ShowToastAsync($"Œÿ√: {ex.Message}");
            }
        }
    }
}
