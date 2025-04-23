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
                Title = "����� �������";
            }
            else
            {
                Title = "����� ����� ����";
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
                    await AlertHelper.ShowToastAsync("�� ����� ������� �����");
                }
                else
                {
                    await _reminderService.AddReminderAsync(ReminderItem);
                    await AlertHelper.ShowToastAsync("��� ����� ������� �����");
                }

                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await AlertHelper.ShowToastAsync($"���: {ex.Message}");
            }
        }
    }
}
