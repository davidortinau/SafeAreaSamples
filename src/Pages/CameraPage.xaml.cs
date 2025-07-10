namespace UnsafeSamples.Pages;

public partial class CameraPage : ContentPage
{
    private bool _isFlashOn = false;
    private bool _isLivePhotoOn = false;
    private bool _isFilterOn = false;
    private double _currentZoom = 1.0;
    private bool _isRearCamera = true;

    public CameraPage()
    {
        InitializeComponent();
        
        // Initialize camera when page appears
        Loaded += OnPageLoaded;
    }

    private async void OnPageLoaded(object? sender, EventArgs e)
    {
        try
        {
            // Start camera preview
            await CameraView.StartCameraPreview(CancellationToken.None);
        }
        catch
        {
            await DisplayAlert("Camera Error", "Unable to access camera. Please check permissions.", "OK");
        }
    }

    protected override void OnDisappearing()
    {
        try
        {
            // Stop camera preview when leaving the page
            CameraView.StopCameraPreview();
        }
        catch
        {
            // Handle error
        }
        
        base.OnDisappearing();
    }

    private void OnFlashClicked(object sender, EventArgs e)
    {
        _isFlashOn = !_isFlashOn;
        
        // Update flash button appearance
        if (_isFlashOn)
        {
            FlashButton.TextColor = Colors.Yellow;
            FlashButton.BackgroundColor = Color.FromRgba(0, 0, 0, 0.25); // Semi-transparent background
        }
        else
        {
            FlashButton.TextColor = Colors.White;
            FlashButton.BackgroundColor = Colors.Transparent;
        }
    }

    private void OnLivePhotoClicked(object sender, EventArgs e)
    {
        _isLivePhotoOn = !_isLivePhotoOn;
        
        // Update live photo button appearance
        if (_isLivePhotoOn)
        {
            LivePhotoButton.TextColor = Colors.Yellow;
            LivePhotoButton.BackgroundColor = Color.FromRgba(0, 0, 0, 0.25);
        }
        else
        {
            LivePhotoButton.TextColor = Colors.White;
            LivePhotoButton.BackgroundColor = Colors.Transparent;
        }
    }

    private void OnFilterClicked(object sender, EventArgs e)
    {
        _isFilterOn = !_isFilterOn;
        
        // Update filter button appearance
        if (_isFilterOn)
        {
            FilterButton.TextColor = Colors.Yellow;
            FilterButton.BackgroundColor = Color.FromRgba(0, 0, 0, 0.25);
        }
        else
        {
            FilterButton.TextColor = Colors.White;
            FilterButton.BackgroundColor = Colors.Transparent;
        }
    }

    private void OnZoom05Clicked(object sender, EventArgs e)
    {
        SetZoomLevel(0.5, Zoom05Button);
    }

    private void OnZoom1Clicked(object sender, EventArgs e)
    {
        SetZoomLevel(1.0, Zoom1Button);
    }

    private void OnZoom2Clicked(object sender, EventArgs e)
    {
        SetZoomLevel(2.0, Zoom2Button);
    }

    private void OnZoom3Clicked(object sender, EventArgs e)
    {
        SetZoomLevel(3.0, Zoom3Button);
    }

    private void SetZoomLevel(double zoomLevel, Button selectedButton)
    {
        _currentZoom = zoomLevel;
        CameraView.ZoomFactor = (float)zoomLevel;

        // Reset all zoom buttons
        ResetZoomButtonStyles();

        // Highlight selected button
        selectedButton.BackgroundColor = Color.FromRgb(224, 224, 224);
        selectedButton.TextColor = Colors.Black;
    }

    private void ResetZoomButtonStyles()
    {
        var buttons = new[] { Zoom05Button, Zoom1Button, Zoom2Button, Zoom3Button };
        foreach (var button in buttons)
        {
            button.BackgroundColor = Colors.Transparent;
            button.TextColor = Colors.White;
        }
    }

    private async void OnCaptureClicked(object sender, EventArgs e)
    {
        try
        {
            // Add capture animation
            await AnimateCaptureButton();
            
            // Capture the image
            await CameraView.CaptureImage(CancellationToken.None);
        }
        catch
        {
            await DisplayAlert("Capture Error", "Failed to capture image", "OK");
        }
    }

    private async Task AnimateCaptureButton()
    {
        // Scale animation for capture feedback
        await CaptureButton.ScaleTo(0.8, 50);
        await CaptureButton.ScaleTo(1.0, 50);
    }

    private async Task StartTimerCountdown()
    {
        // Simple countdown display
        var countdownLabel = new Label
        {
            Text = "3",
            FontSize = 72,
            FontAttributes = FontAttributes.Bold,
            TextColor = Colors.White,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        // Add countdown to the grid temporarily
        ((Grid)Content).Children.Add(countdownLabel);

        for (int i = 3; i > 0; i--)
        {
            countdownLabel.Text = i.ToString();
            await countdownLabel.ScaleTo(1.5, 200);
            await countdownLabel.ScaleTo(1.0, 200);
            await Task.Delay(600);
        }

        // Remove countdown
        ((Grid)Content).Children.Remove(countdownLabel);
    }

    private async void OnFlipCameraClicked(object sender, EventArgs e)
    {
        try
        {
            _isRearCamera = !_isRearCamera;
            
            // Add flip animation
            var flipButton = sender as Button;
            if (flipButton != null)
            {
                await flipButton.RotateTo(180, 300);
                await flipButton.RotateTo(0, 100);
            }
        }
        catch
        {
            // Handle error
        }
    }

    private async void OnPhotoLibraryClicked(object sender, EventArgs e)
    {
        try
        {
            // Navigate to photo library or show recent photos
            await DisplayAlert("Photo Library", "Opening photo library...", "OK");
        }
        catch
        {
            // Handle error
        }
    }

    private async void OnCloseClicked(object sender, EventArgs e)
    {
        try
        {
            // Navigate back to previous page
            await Shell.Current.GoToAsync("..");
        }
        catch
        {
            // Handle error
        }
    }

    private async void OnMediaCaptured(object sender, EventArgs e)
    {
        try
        {
            // Handle the captured media
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await DisplayAlert("Success", "Photo captured successfully!", "OK");
            });
        }
        catch
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await DisplayAlert("Error", "Failed to save photo", "OK");
            });
        }
    }

    // Property for zoom binding (if needed for MVVM)
    public double ZoomLevel => _currentZoom;
}
