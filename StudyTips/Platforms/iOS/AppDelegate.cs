using Foundation;
using UIKit;

namespace StudyTips;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    //protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    protected override MauiApp CreateMauiApp()
    {
        UIDevice.CurrentDevice.SetValueForKey(NSNumber.FromNInt((int)(UIInterfaceOrientation.Portrait)), new NSString("orientation"));

        return MauiProgram.CreateMauiApp();
    }
}
