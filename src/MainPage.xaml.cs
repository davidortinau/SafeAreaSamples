namespace UnsafeSamples;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnAirBnBPageClicked(object? sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(Pages.AirBnBPage));
	}

	private async void OnSpotifyPageClicked(object? sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(Pages.SpotifyPage));
	}

	private async void OnCameraPageClicked(object? sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(Pages.CameraPage));
	}
}
