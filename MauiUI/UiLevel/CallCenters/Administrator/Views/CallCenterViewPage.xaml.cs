namespace MauiUI.UiLevel.CallCenters.Administrator.Views;

public partial class CallCenterViewPage : ContentPage
{
	public CallCenterViewPage()
	{
		InitializeComponent();
       
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        SetNavigationBarColor(); // Call the method when the page appears
    }
    public void SetNavigationBarColor()
    {
        if (this.Parent is NavigationPage navigationPage)
        {

            navigationPage.BarTextColor = Color.FromRgb(255,255,255);
            navigationPage.BarBackgroundColor = Color.FromRgb(0, 204, 102);
        }
    }
}