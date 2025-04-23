using SmartPillMauiApp.Models;
using SmartPillMauiApp.Services.Api;
using SmartPillMauiApp.Helpers;

namespace SmartPillMauiApp.Views.Caregiver
{
    public partial class CaregiverAddEditPage : ContentPage
    {
        
        public CaregiverAddEditPage(CaregiverService caregiverService, CaregiverDto existingCaregiver = null)
        {
            InitializeComponent();
           
        }

       
    }
}
