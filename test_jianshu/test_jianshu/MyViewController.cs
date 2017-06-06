using System;

using UIKit;

namespace test_jianshu
{
	public partial class MyViewController : UIViewController
	{
		public static UIImageView bigView;
		public MyViewController() : base("MyViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			bigView = new UIImageView(UIImage.FromBundle("guide1"));
			this.View.AddSubview(bigView);

			bigView.Layer.BorderColor = UIColor.Blue.CGColor;
			bigView.Layer.BorderWidth = 2.0f;

			UIButton btn = new UIButton(new CoreGraphics.CGRect(40,400,200,100));
			btn.SetTitle("check",UIControlState.Normal);
			btn.SetTitleColor(UIColor.Black, UIControlState.Normal);
			btn.TouchUpInside += checkFrame;
			this.View.AddSubview(btn);

			Console.WriteLine(bigView.Frame);

			Console.WriteLine(bigView.Layer.Bounds);

			// Perform any additional setup after loading the view, typically from a nib.
		}

		public void checkFrame(object sender, EventArgs e)
		{
			Console.WriteLine(bigView.Frame);

			Console.WriteLine(bigView.Layer.Bounds);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

