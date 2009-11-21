using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MultiLevelTableView
{
	[Register ("AppController")]
    public class AppController : UIApplicationDelegate
    {
        UIWindow window;	
		MonoTouch.UIKit.UINavigationController navigationController;

        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
        {
            RootViewController rvc = new RootViewController();
			
			// navigation controller will manage the views displayed and provide navigation buttons
			navigationController = new UINavigationController();
			navigationController.PushViewController(rvc, false);
			navigationController.TopViewController.Title ="Root View";
			
            // Main window to which we add the navigation controller to
            window = new UIWindow (UIScreen.MainScreen.Bounds);
            window.AddSubview(navigationController.View);
            window.MakeKeyAndVisible ();
            return true;
        }

		public override void OnActivated (UIApplication application)
		{
		}
	}
}