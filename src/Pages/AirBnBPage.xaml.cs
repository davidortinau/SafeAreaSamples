namespace UnsafeSamples.Pages;

public partial class AirBnBPage : ContentPage
{
    public AirBnBPage()
    {
        InitializeComponent();
    }

    private async void OnBackClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
