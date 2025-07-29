using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace UnsafeSamples;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.UseMauiCommunityToolkitCamera()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

// #if IOS
// 		// Override ScrollView handler on iOS to disable automatic content inset adjustment
// 		builder.ConfigureMauiHandlers(handlers =>
// 		{
// 			handlers.AddHandler<ScrollView, UnsafeSamples.Platforms.iOS.CustomScrollViewHandler>();
// 		});
// #endif

		return builder.Build();
	}
}
