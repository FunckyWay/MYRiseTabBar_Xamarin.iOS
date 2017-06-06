using System;
using Foundation;
using UIKit;

namespace test_jianshu
{
	public partial class Slide : UIViewController
	{
		public Slide() : base("Slide", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			this.View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromBundle("Home_refresh_bg"));

			MYView view = new MYView();
			view.Frame = new CoreGraphics.CGRect(30, 221.5, 314, 335.5);
			view.BackgroundColor = UIColor.Clear;

			MYView.correctPassWord = "012";
			this.View.AddSubview(view);


			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public override UIStatusBarStyle PreferredStatusBarStyle()
		{
			return UIStatusBarStyle.LightContent;
		}
	}
}

