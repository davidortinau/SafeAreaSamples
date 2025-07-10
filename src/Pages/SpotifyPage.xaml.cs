using Microsoft.Maui.Controls;

namespace UnsafeSamples.Pages;

public partial class SpotifyPage : ContentPage
{
    private bool isCompactPlayerVisible = false;
    private const double CompactPlayerThreshold = 400; // Scroll position to show compact player
    private const double SafeAreaOverlayThreshold = 100; // Scroll position to show safe area overlay

    public SpotifyPage()
    {
        InitializeComponent();
    }

    private async void OnScrollViewScrolled(object sender, ScrolledEventArgs e)
    {
        var scrollY = e.ScrollY;
        
        // Handle SafeArea overlay opacity based on scroll position
        await HandleSafeAreaOverlay(scrollY);
        
        // Handle compact player visibility
        await HandleCompactPlayer(scrollY);
        
        // Handle top title visibility
        await HandleTopTitle(scrollY);
    }

    private async Task HandleSafeAreaOverlay(double scrollY)
    {
        // Show overlay gradually as user scrolls
        var overlayOpacity = Math.Min(scrollY / SafeAreaOverlayThreshold, 0.8);
        
        if (SafeAreaOverlay.Opacity != overlayOpacity)
        {
            await SafeAreaOverlay.FadeTo(overlayOpacity, 50, Easing.Linear);
        }
    }

    private async Task HandleCompactPlayer(double scrollY)
    {
        var shouldShowCompactPlayer = scrollY > CompactPlayerThreshold;
        
        if (shouldShowCompactPlayer && !isCompactPlayerVisible)
        {
            isCompactPlayerVisible = true;
            
            // Animate compact player in
            CompactPlayer.TranslationY = -100;
            CompactPlayer.Opacity = 0;
            
            var animationTasks = new[]
            {
                CompactPlayer.FadeTo(1, 250, Easing.CubicOut),
                CompactPlayer.TranslateTo(0, 0, 250, Easing.CubicOut)
            };
            
            await Task.WhenAll(animationTasks);
        }
        else if (!shouldShowCompactPlayer && isCompactPlayerVisible)
        {
            isCompactPlayerVisible = false;
            
            // Animate compact player out
            var animationTasks = new[]
            {
                CompactPlayer.FadeTo(0, 200, Easing.CubicIn),
                CompactPlayer.TranslateTo(0, -100, 200, Easing.CubicIn)
            };
            
            await Task.WhenAll(animationTasks);
        }
    }

    private async Task HandleTopTitle(double scrollY)
    {
        // Show title in top navigation when scrolled past hero section
        var titleOpacity = scrollY > 300 ? 1.0 : 0.0;
        
        if (Math.Abs(TopTitle.Opacity - titleOpacity) > 0.1)
        {
            await TopTitle.FadeTo(titleOpacity, 150, Easing.CubicOut);
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
