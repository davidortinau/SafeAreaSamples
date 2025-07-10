namespace UnsafeSamples;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		
		// Register routes for navigation
		Routing.RegisterRoute(nameof(Pages.AirBnBPage), typeof(Pages.AirBnBPage));
		Routing.RegisterRoute(nameof(Pages.SpotifyPage), typeof(Pages.SpotifyPage));
	}
}
