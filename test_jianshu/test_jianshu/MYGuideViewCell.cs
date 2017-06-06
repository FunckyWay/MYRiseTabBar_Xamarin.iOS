using System;
using UIKit;
namespace test_jianshu
{
	public class MYGuideViewCell : UICollectionViewCell
	{
		private UIImage image;
		private UIImageView imageView;
		public UIImage Image 
		{ 
			get 
			{
				return image;
			}

			set
			{
				this.ImageView.Image = value;
				image = value;
			}
		}

		private UIImageView ImageView
		{
			get
			{
				if (imageView == null)
				{
					imageView = new UIImageView();
					imageView.Frame = new CoreGraphics.CGRect(UIScreen.MainScreen.Bounds.Location,UIScreen.MainScreen.Bounds.Size);
					this.AddSubview(imageView);
				}

				return imageView;
			}

			set
			{
				imageView = value;
			}
		}


		protected MYGuideViewCell(IntPtr handle) : base(handle)
		{
			
		}

	}
}
