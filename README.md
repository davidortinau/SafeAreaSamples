# UnsafeSamples - .NET MAUI SafeArea API Testing

This project demonstrates the upcoming SafeArea APIs in .NET MAUI, designed to help developers handle device-specific safe areas like notches, home indicators, and status bars more effectively.

## Features

### 🏠 AirBnB-Style Detail Page
- **Hero Image**: Full-screen image that extends to the top of the device
- **Scrollable Content**: Detailed property information with AirBnB-style layout
- **SafeArea Handling**: Proper consideration for status bars and home indicators
- **Modern Layout**: Uses new `VerticalStackLayout` and `HorizontalStackLayout` controls
- **Material Design Elements**: `Border` controls with rounded corners and shadows

### 🎨 Modern Layout Controls
- **VerticalStackLayout**: Replaces traditional `StackLayout` for vertical arrangements
- **HorizontalStackLayout**: Replaces `StackLayout` with `Orientation="Horizontal"`
- **Border**: Replaces `Frame` with better performance and styling options

## SafeArea API Integration

This project is prepared for the new SafeArea APIs currently in development:

### Planned API Usage
```xaml
<!-- Hero image that ignores all safe areas -->
<Grid SafeAreaGuides.IgnoreSafeArea="All">
    <Image Source="hero.jpg" Aspect="AspectFill" />
</Grid>

<!-- Back button that respects top safe area only -->
<Button SafeAreaGuides.IgnoreSafeArea="None,All,None,None" 
        Text="← Back" />

<!-- Bottom content that respects bottom safe area -->
<Grid SafeAreaGuides.IgnoreSafeArea="None,None,None,All">
    <!-- Reserve button and pricing -->
</Grid>
```

### Current Fallback Implementation
Since the SafeArea APIs are still in development, the project currently uses:
- Platform-specific margin adjustments: `Margin="{OnPlatform iOS=60, Android=60, Default=20}"`
- Manual safe area calculations for status bars and home indicators
- TODO comments indicating where SafeArea APIs will be implemented

## Project Structure

```
UnsafeSamples/
├── Pages/
│   └── AirBnBPage.xaml          # AirBnB-style detail page
├── MainPage.xaml                 # Navigation hub for sample pages
├── AppShell.xaml                 # Shell navigation setup
└── README.md                     # This documentation
```

## SafeArea API Specification

Based on the [.NET MAUI SafeArea Epic #28986](https://github.com/dotnet/maui/issues/28986), the new APIs will include:

### SafeAreaGuides.IgnoreSafeArea Attached Property
- **One Value**: Applies to all edges (`SafeAreaGuides.IgnoreSafeArea="All"`)
- **Two Values**: Left/Right, Top/Bottom (`SafeAreaGuides.IgnoreSafeArea="All,None"`)
- **Four Values**: Left, Top, Right, Bottom (`SafeAreaGuides.IgnoreSafeArea="All,None,All,None"`)

### SafeAreaGroup Enum
- `None`: Apply platform inset (default behavior)
- `All`: Ignore all insets for this edge
- `Keyboard`: (Future) Ignore keyboard insets

## Building and Running

1. **Prerequisites**: .NET 9.0 with MAUI workload installed
2. **Build**: `dotnet build`
3. **Run**: Open in Visual Studio or use `dotnet run`

## Testing SafeArea Behavior

1. **iOS Simulator**: Test with devices that have notches (iPhone X and newer)
2. **Android Emulator**: Test with devices that have display cutouts
3. **Physical Devices**: Best testing experience with real hardware

## Future Enhancements

As the SafeArea APIs become available, this project will be updated to:
- Replace manual margin calculations with `SafeAreaGuides.IgnoreSafeArea`
- Add more complex scenarios (keyboard handling, orientation changes)
- Demonstrate responsive design with safe area triggers
- Add additional sample pages showcasing different SafeArea use cases

## Contributing

This is a testing project for the upcoming SafeArea APIs. When the APIs are released:
1. Update the TODOs in the XAML files
2. Replace manual platform-specific margins
3. Test thoroughly on devices with various safe area configurations

## References

- [SafeArea Epic #28986](https://github.com/dotnet/maui/issues/28986)
- [SafeArea PR #30337](https://github.com/dotnet/maui/pull/30337)
- [.NET MAUI Documentation](https://docs.microsoft.com/dotnet/maui/)
