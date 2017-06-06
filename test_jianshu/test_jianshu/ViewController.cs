using System;
using CoreGraphics;
using UIKit;
using Foundation;

namespace test_jianshu
{
	public partial class ViewController : UICollectionViewController
	{
		UIImageView bigView;
		UIImageView largeTxtView;
		UIImageView smallTxtView;
		float pageNumber;
		static NSString reuseIdentifier = new NSString("GuideCell");
		public ViewController() 
		{
		}
		public ViewController(UICollectionViewFlowLayout layout) : base(layout)
		{
		}
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.CollectionView.RegisterClassForCell(typeof(MYGuideViewCell),reuseIdentifier);
			//设置分页样式
			this.CollectionView.PagingEnabled = true;
			//取消水平滚动条
			this.CollectionView.ShowsHorizontalScrollIndicator = false;
			//取消弹性效果
			this.CollectionView.Bounces = false;


			UIImageView blView = new UIImageView(UIImage.FromBundle("guideLine"));
			CGRect rectbl =  blView.Frame;
			rectbl.X = -200;
			blView.Frame = rectbl;
			Console.WriteLine(blView.Frame);
			this.CollectionView.AddSubview(blView);

			bigView = new UIImageView(UIImage.FromBundle("guide1"));
			Console.WriteLine(bigView.ContentMode);
			Console.WriteLine(bigView.Frame);
			this.CollectionView.AddSubview(bigView);

			largeTxtView = new UIImageView(UIImage.FromBundle("guideLargeText1"));
			CGRect rectlarge = largeTxtView.Frame;
			rectlarge.X = 27.5f;
			rectlarge.Y = (System.nfloat)(this.CollectionView.Frame.Height * 0.7);
			largeTxtView.Frame = rectlarge;
			this.CollectionView.AddSubview(largeTxtView);

			smallTxtView = new UIImageView(UIImage.FromBundle("guideSmallText1"));
			CGRect rectsmall = smallTxtView.Frame;
			rectsmall.X = 27.5f;
			rectsmall.Y = (System.nfloat)(this.CollectionView.Frame.Height * 0.8);
			smallTxtView.Frame = rectsmall;
			this.CollectionView.AddSubview(smallTxtView);

			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DecelerationEnded(UIScrollView scrollView)
		{
			nfloat offsetX = scrollView.ContentOffset.X;

			int page = (int)(offsetX / UIScreen.MainScreen.Bounds.Width);

			if (pageNumber < page)
			{
				//向左滑动
				CGRect rectbl = bigView.Frame;
				rectbl.X = offsetX + this.CollectionView.Frame.Width;
				bigView.Frame = rectbl;

				CGRect rectlarge = largeTxtView.Frame;
				rectlarge.X = offsetX + this.CollectionView.Frame.Width;
				largeTxtView.Frame = rectlarge;

				CGRect rectsmall = smallTxtView.Frame;
				rectsmall.X = offsetX + this.CollectionView.Frame.Width;
				smallTxtView.Frame = rectsmall;

				//bigView.x = offsetX + this.CollectionView.Frame.Width;
				//largeTxtView.x = offsetX + this.CollectionView.Frame.Width;
				//smallTxtView.x = offsetX + this.CollectionView.Frame.Width;
			}
			else
			{
				//向右滑动

				CGRect rectbl = bigView.Frame;
				rectbl.X = offsetX - this.CollectionView.Frame.Width;
				bigView.Frame = rectbl;

				CGRect rectlarge = largeTxtView.Frame;
				rectlarge.X = offsetX - this.CollectionView.Frame.Width;
				largeTxtView.Frame = rectlarge;

				CGRect rectsmall = smallTxtView.Frame;
				rectsmall.X = offsetX - this.CollectionView.Frame.Width;
				smallTxtView.Frame = rectsmall;

				//self.bigView.x = offsetX - self.collectionView.width;
				//self.largeTxtView.x = offsetX - self.collectionView.width;
				//self.smallTxtView.x = offsetX - self.collectionView.width;
			}

			string bigImageName = string.Format("guide{0}", page + 1);
			string largeImageName = string.Format("guideLargeText{0}", page + 1);
			string smallImageName = string.Format("guideSmallText{0}", page + 1);

			bigView.Image = UIImage.FromBundle(bigImageName);
			largeTxtView.Image = UIImage.FromBundle(largeImageName);
			smallTxtView.Image = UIImage.FromBundle(smallImageName);

			UIView.Animate(0.25, () => {
				
				CGRect rectbl = bigView.Frame;
				rectbl.X = offsetX ;
				bigView.Frame = rectbl;

				CGRect rectlarge = largeTxtView.Frame;
				rectlarge.X = 27.5f+offsetX ;
				largeTxtView.Frame = rectlarge;

				CGRect rectsmall = smallTxtView.Frame;
				rectsmall.X = 27.5f + offsetX ;
				smallTxtView.Frame = rectsmall;
			});

			pageNumber = page;

		}


		public override nint NumberOfSections(UICollectionView collectionView)
		{
			return 1;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return 4;
		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
			MYGuideViewCell cell = (MYGuideViewCell)collectionView.DequeueReusableCell(reuseIdentifier,indexPath);

			string imageName = string.Format("guide{0}Background568h", indexPath.Row + 1);

			//NSString imageName = NSString.LocalizedFormat("guide%zdBackground", indexPath.Row + 1);

			cell.Image = UIImage.FromBundle(imageName);

			//cell.BackgroundColor = UIColor.Red;

			return cell;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
