using System;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using Foundation;

namespace test_jianshu
{
	public class MYTabBar : UIView
	{
		private List<MYTabBarItem> tabBarItems ;
		public List<Dictionary<string,object>> tabBarItemAttributes
		{
			get
			{
				return _tabBarItemAttributes;
			}
			set
			{
				_tabBarItemAttributes = value;
				nfloat normalItemWidth = (UIScreen.MainScreen.Bounds.Width * 3 / 4) / (_tabBarItemAttributes.Count - 1);
				nfloat tabBarHeight = this.Frame.Height;
				nfloat publishItemWidth = (UIScreen.MainScreen.Bounds.Width / 4);

				int itemTag = 0;
				bool passedRiseItem = false;
				tabBarItems = new List<MYTabBarItem>();

				foreach (var item in _tabBarItemAttributes)
				{
					if (item is Dictionary<string, object>)
					{
						Dictionary<string, object> itemDic = (Dictionary<string, object>)item;
						var type = (object)itemDic[MYTabBarItem.kLLTabBarItemAttributeType];
						CGRect frame = new CGRect(itemTag * normalItemWidth + (passedRiseItem ? publishItemWidth : 0), 0, (type == (object)LLTabBarItemType.Rise ? publishItemWidth : normalItemWidth), tabBarHeight);

						MYTabBarItem tabBarItem = tabbarItemWithProperty(frame,
						                                                 itemDic[MYTabBarItem.kLLTabBarItemAttributeTitle].ToString(),
						                                                 itemDic[MYTabBarItem.kLLTabBarItemAttributeNormalImageName].ToString(),
						                                                 itemDic[MYTabBarItem.kLLTabBarItemAttributeSelectedImageName].ToString(),
						                                                 (LLTabBarItemType)type);
						
						if (itemTag == 0)
						{
							tabBarItem.Selected = true;
						}

						tabBarItem.TouchUpInside += (object sender, EventArgs e) =>
						{
							if (((MYTabBarItem)sender).tabBarItemType != LLTabBarItemType.Rise)
							{
								setSelectedIndex((int)((MYTabBarItem)sender).Tag);
							}
							else
							{

							}
						};
						if (tabBarItem.tabBarItemType != LLTabBarItemType.Rise)
						{
							tabBarItem.Tag = itemTag;
							itemTag++;
						}
						else {
							passedRiseItem = true;
						}
						tabBarItems.Add(tabBarItem);
						this.AddSubview(tabBarItem);

					}
				}
			}
		}

		private List<Dictionary<string, object>> _tabBarItemAttributes;
		public MYTabBar()
		{
		}

		public MYTabBar(CGRect frame) : base(frame)
		{
			
		}

		private MYTabBarItem tabbarItemWithProperty(CGRect frame ,string title,string normalImageName,string selectedImageName,LLTabBarItemType tabBarItemType)
		{
			MYTabBarItem item = new MYTabBarItem(frame);
			item.SetTitle(title, UIControlState.Normal);
			item.SetTitle(title, UIControlState.Selected);
			item.TitleLabel.Font = UIFont.SystemFontOfSize(8);
			UIImage normalImage = UIImage.FromBundle(normalImageName);
			UIImage selectedImage = UIImage.FromBundle(selectedImageName);
			item.SetImage(normalImage , UIControlState.Normal);
			item.SetImage(selectedImage , UIControlState.Selected);
			item.SetTitleColor(UIColor.FromWhiteAlpha(51/255,1), UIControlState.Normal);
			item.SetTitleColor(UIColor.FromWhiteAlpha(51 / 255, 1), UIControlState.Selected);
			item.tabBarItemType = tabBarItemType;
			return item;
		}

		private void setSelectedIndex(int index)
		{ 
			foreach(MYTabBarItem item in tabBarItems)
			{
				if (item.Tag == index)
				{
					item.Selected = true;
				}
				else {
					item.Selected = false;
				}
			}

			UIWindow keyWindow = UIApplication.SharedApplication.Delegate.GetWindow();
			UITabBarController tabBarController = (UITabBarController)keyWindow.RootViewController;
			if (tabBarController!=null)
			{
				tabBarController.SelectedIndex = index;
			}
		}

	}
}
