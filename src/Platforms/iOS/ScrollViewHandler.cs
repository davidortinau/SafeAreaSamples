using Microsoft.Maui.Handlers;
using UIKit;

namespace UnsafeSamples.Platforms.iOS;

public class CustomScrollViewHandler : ScrollViewHandler
{
    protected override void ConnectHandler(UIScrollView platformView)
    {
        base.ConnectHandler(platformView);
        
        // Disable automatic content inset adjustment
        // This prevents iOS from automatically adding safe area insets
        if (platformView != null)
        {
            platformView.ContentInsetAdjustmentBehavior = UIScrollViewContentInsetAdjustmentBehavior.Never;
        }
    }
}
