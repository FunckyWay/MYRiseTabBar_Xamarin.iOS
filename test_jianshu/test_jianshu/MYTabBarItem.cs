using System;
using UIKit;
using Foundation;
using CoreGraphics;


namespace test_jianshu
{
	public enum LLTabBarItemType
	{
		Normal = 0,
		Rise,
	}

	public class MYTabBarItem : UIButton
	{
		static public string kLLTabBarItemAttributeType = "MYTabBarItemAttributeType";
		static public string kLLTabBarItemAttributeTitle = "MYTabBarItemAttributeTitle";
		static public string kLLTabBarItemAttributeNormalImageName = "LLTabBarItemAttributeNormalImageName";
		static public string kLLTabBarItemAttributeSelectedImageName = "LLTabBarItemAttributeSelectedImageName";

		public LLTabBarItemType tabBarItemType{get;set;}

		public MYTabBarItem(CGRect frame) : base(frame)
		{
			if(this != null)
				config();
		}

		//public MYTabBarItem(NSCoder coder) : base(coder)
		//{
		//	if (this != null)
		//		config();
		//}

		public MYTabBarItem()
		{
			if (this != null)
				config();
		}

		private void config()
		{ 
			this.AdjustsImageWhenHighlighted = true;
			this.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			this.TitleLabel.SizeToFit();
			this.ImageView.SizeToFit();
			CGSize titleSize = this.TitleLabel.Frame.Size;
			UIImage image = this.ImageForState(UIControlState.Normal);
			CGSize imageSize;
			if (image == null)
			{
				imageSize = new CGSize(0,0);
			}
			else
			{
				imageSize = this.ImageForState(UIControlState.Normal).Size;
			}

			if (imageSize.Width != 0 && imageSize.Height != 0)
			{
				nfloat imageViewCenterY = this.Frame.Height - 3 - titleSize.Height - imageSize.Height / 2 - 5;
				this.ImageView.Center = new CGPoint(this.Frame.Width / 2, imageViewCenterY);
			}
			else
			{
				CGPoint imageViewCenter = this.ImageView.Center;
				imageViewCenter.X = this.Frame.Width / 2;
				imageViewCenter.Y = (this.Frame.Height - titleSize.Height) / 2;
				this.ImageView.Center = imageViewCenter;
			}

			CGPoint labelCenter = new CGPoint(this.Frame.Width / 2 ,this.Frame.Height -3 - titleSize.Height/2 );
			this.TitleLabel.Center = labelCenter;

			//Console.WriteLine(this.ImageView.Frame);

		}


	}
}
