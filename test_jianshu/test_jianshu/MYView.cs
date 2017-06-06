using System;
using UIKit;
using Foundation;
using System.Collections.Generic;
using CoreGraphics;
using System.Threading.Tasks;


namespace test_jianshu
{
	public class MYView : UIView	
	{
		public static string correctPassWord { get; set; }

		private List<UIButton> buttonArray;

		private List<UIButton> lineArray;

		private CGPoint currentPoint;

		private bool change;

		public MYView()
		{
			buttonArray = new List<UIButton>();
			lineArray = new List<UIButton>();

			for (int i = 0; i < 9; i++)
			{
				UIButton button = new UIButton();
				button.Tag = i;
				button.SetBackgroundImage(UIImage.FromBundle("gesture_node_normal"), UIControlState.Normal);
				button.SetBackgroundImage(UIImage.FromBundle("gesture_node_highlighted"), UIControlState.Selected);

				button.UserInteractionEnabled = false;

				this.AddSubview(button);
				buttonArray.Add(button);
			}
		}

		public override void LayoutSubviews()
		{
			nfloat width = 74;
			nfloat height = 74;
			nfloat margin = (this.Frame.Size.Width - 3 * width) / 4;



			for (int i = 0; i < buttonArray.Count; i++)
			{
				nfloat x = (i % 3) * (margin + width) + margin;
				nfloat y = (i / 3) * (margin + height) + margin;

				buttonArray[i].Frame = new CoreGraphics.CGRect(x,y,width,height);
    		}
		}

		public override void Draw(CoreGraphics.CGRect rect)
		{
			if (lineArray.Count == 0)
				return;
			UIBezierPath path = new UIBezierPath();

			for (int i = 0; i < lineArray.Count; i++)
			{
				UIButton button = lineArray[i];
				if (i == 0)
					path.MoveTo(button.Center);
				else
				{
					path.AddLineTo(button.Center);
        		}		
			}
			path.AddLineTo(currentPoint);
			path.LineWidth = 10;
			path.LineJoinStyle = CoreGraphics.CGLineJoin.Round;
			path.LineCapStyle = CoreGraphics.CGLineCap.Round;
			UIColor.White.SetStroke();
			if (change)
				UIColor.Red.SetStroke();
			path.Stroke();

		}


		public override void TouchesBegan(NSSet touches, UIEvent evt)
		{
			UITouch t = (UITouch)touches.AnyObject;

			CGPoint p =  t.LocationInView(t.View);

			for (int i = 0; i < buttonArray.Count; i++)
			{
				UIButton button =buttonArray[i];

				if (button.Frame.Contains(p))
				{
					button.Selected = true;

					lineArray.Add(button);
        
       		 	}

			}

		}

		public override void TouchesMoved(NSSet touches, UIEvent evt)
		{
			UITouch t = (UITouch)touches.AnyObject;

			CGPoint p = t.LocationInView(t.View);

			currentPoint = p;

			for (int i = 0; i < buttonArray.Count; i++)
			{
				UIButton button = buttonArray[i];

				if (button.Frame.Contains(p))
				{
					button.Selected = true;

					if (!lineArray.Contains(button))
					{

						lineArray.Add(button);
					}
				}
        
    		}
			SetNeedsDisplay();
		}

		public override void TouchesEnded(NSSet touches, UIEvent evt)
		{
			if (lineArray.Count == 0)
				return;
			currentPoint = lineArray[lineArray.Count - 1].Center;

			SetNeedsDisplay();

			this.UserInteractionEnabled = false;

			string passwrod = "";
			for (int i = 0; i < lineArray.Count; i++)
			{
				UIButton button = lineArray[i];

				passwrod = passwrod + button.Tag;

			}
			if (passwrod == correctPassWord)
				Console.WriteLine("correct");
			else {
				Console.WriteLine("error");
				change = true;
				SetNeedsDisplay();
			}

			Task.Delay(2000).ContinueWith((t) =>
			{
				BeginInvokeOnMainThread(() =>
				{
					this.UserInteractionEnabled = true;
					clearView();
					change = false;
				 });
				});
		}

		public void clearView()
		{
			for (int i = 0; i < buttonArray.Count; i++)
			{
				UIButton button = buttonArray[i];
				button.Selected = false;

			}
			lineArray.RemoveRange(0,lineArray.Count);
			SetNeedsDisplay();

		}


	}
}
