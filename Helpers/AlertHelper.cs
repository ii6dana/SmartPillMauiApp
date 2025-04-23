using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using System.Threading.Tasks;

namespace SmartPillMauiApp.Helpers
{ 
    public static class AlertHelper
    {
        public static async Task ShowToastAsync(string message, ToastDuration duration = ToastDuration.Long)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            double FontSize = 20;

            var toast = Toast.Make(message, duration, FontSize);

            await toast.Show(cancellationTokenSource.Token);
        }

    }

}
