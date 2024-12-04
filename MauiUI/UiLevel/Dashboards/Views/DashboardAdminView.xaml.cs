namespace MauiUI.UiLevel.Dashboards.Views;

public partial class DashboardAdminView : ContentView
{
	public DashboardAdminView()
	{
		InitializeComponent();
        //UpdateLayoutForOrientation();
        //DeviceDisplay.MainDisplayInfoChanged += OnDisplayInfoChanged; // Subscribe to display info changes

    }
    //private void OnDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
    //{
    //    UpdateLayoutForOrientation(); // Update layout on device orientation change
    //}

    //private void UpdateLayoutForOrientation()
    //{
    //    var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

    //    // Check if the device is in landscape or portrait
    //    bool isLandscape = mainDisplayInfo.Orientation is DisplayOrientation.Landscape;

    //    // Determine the span based on the device size and orientation
    //    int span;

    //    if (mainDisplayInfo.Height > mainDisplayInfo.Width) // Portrait
    //    {
    //        if (mainDisplayInfo.Density >= 2 && !isLandscape) // Likely a mobile device
    //        {
    //            span = 1; // Mobile Portrait
    //        }
    //        else // Assume a tablet
    //        {
    //            span = 2; // Tablet Portrait
    //        }
    //    }
    //    else // Landscape
    //    {
    //        if (mainDisplayInfo.Density >= 2 && isLandscape) // Mobile
    //        {
    //            span = 2; // Mobile Landscape
    //        }
    //        else // Tablet
    //        {
    //            span = 3; // Tablet Landscape
    //        }
    //    }

    //    // If the device is a low-density device, set span accordingly
    //    if (mainDisplayInfo.Density < 1.5) // Low-density devices
    //    {
    //        span = 5; // Reduce span for low-density devices
    //    }

    //    // Update the CollectionView layout
    //    //if (CollectionView.ItemsLayout is GridItemsLayout layout)
    //    //{
    //    //    layout.Span = span;
    //    //}
    //}

    //~DashboardAdminView()
    //{
    //    DeviceDisplay.MainDisplayInfoChanged -= OnDisplayInfoChanged; // Unsubscribe from display info changes
    //}

}