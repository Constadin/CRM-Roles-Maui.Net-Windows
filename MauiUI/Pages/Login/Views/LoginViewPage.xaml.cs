using Microsoft.Maui.Controls;

namespace MauiUI.Pages.Login.Views;

public partial class LoginViewPage : ContentPage
{
    public LoginViewPage()
    {
        InitializeComponent();
        this.SizeChanged += OnPageSizeChanged;
    }

    private void OnPageSizeChanged(object sender, EventArgs e)
    {
        if (this.Width > this.Height && !(DeviceInfo.Platform == DevicePlatform.WinUI))
        {
            // Landscape orientation
            frame.Margin = new Thickness(230, 30, 230, 10);
        }
        else
        {
            // Portrait orientation - reset to platform-specific default
            UpdateMarginForPlatform();
        }
    }

    private void UpdateMarginForPlatform()
    {
        // Setting margin based on the platform at runtime
        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            frame.Margin = new Thickness(70, 50, 70, 0);
        }
        else if (DeviceInfo.Platform == DevicePlatform.iOS)
        {
            frame.Margin = new Thickness(70, 50, 70, 0);
        }
        else if (DeviceInfo.Platform == DevicePlatform.WinUI)
        {
            frame.Margin = new Thickness(400, 70, 400, 0);
        }
    }
}