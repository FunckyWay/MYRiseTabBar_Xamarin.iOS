using Foundation;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using System;

namespace test_jianshu
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations

		public override UIWindow Window
		{
			get;
			set;
		}

		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method

			Window = new UIWindow(UIScreen.MainScreen.Bounds);
			Window.BackgroundColor = UIColor.White;


			UICollectionViewFlowLayout layout = new UICollectionViewFlowLayout();
			layout.ItemSize = new CGSize(UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height);
			layout.MinimumLineSpacing = 0;
			layout.ScrollDirection = UICollectionViewScrollDirection.Horizontal;
			UICollectionViewController guideVC = new ViewController(layout);

			MyViewController vc = new MyViewController();
			Slide sc = new Slide();

			UITabBarController tabbar = new UITabBarController();
			tabbar.ViewControllers = new UIViewController[] {vc, sc,guideVC,vc,sc};
			UITabBar.Appearance.BackgroundImage = new UIImage();
			UITabBar.Appearance.ShadowImage = new UIImage();

			MYTabBar tab = new MYTabBar(tabbar.TabBar.Bounds);
			if (MYTabBarItem.kLLTabBarItemAttributeTitle != null)
			{
				var key1 = MYTabBarItem.kLLTabBarItemAttributeTitle;
				var key2 = MYTabBarItem.kLLTabBarItemAttributeType;
				var key3 = MYTabBarItem.kLLTabBarItemAttributeNormalImageName;
				var key4 = MYTabBarItem.kLLTabBarItemAttributeSelectedImageName;



				var value2 = LLTabBarItemType.Normal;
				var value1 = LLTabBarItemType.Rise;


				var dict1 = new Dictionary<string, object>();
				dict1.Add(key1,"首页");
				dict1.Add(key2, value2);
				dict1.Add(key3, "home_normal");
				dict1.Add(key4, "home_highlight");
				//var dict1 = new NSDictionary(MYTabBarItem.kLLTabBarItemAttributeTitle, "首页", MYTabBarItem.kLLTabBarItemAttributeNormalImageName, "home_normal",MYTabBarItem.kLLTabBarItemAttributeSelectedImageName,"home_highlight",MYTabBarItem.kLLTabBarItemAttributeType,LLTabBarItemType.Normal);
				Console.WriteLine(dict1);

				var dict2 = new Dictionary<string, object>();
				dict2.Add(key1, "同城");
				dict2.Add(key2, value2);
				dict2.Add(key3, "mycity_normal");
				dict2.Add(key4, "mycity_highlight");

				var dict3 = new Dictionary<string, object>();
				dict3.Add(key1, "发布");
				dict3.Add(key2, value1);
				dict3.Add(key3, "post_normal");
				dict3.Add(key4, "post_highlight");

				var dict4 = new Dictionary<string, object>();
				dict4.Add(key1, "消息");
				dict4.Add(key2, value2);
				dict4.Add(key3, "message_normal");
				dict4.Add(key4, "message_highlight");

				var dict5 = new Dictionary<string, object>();
				dict5.Add(key1, "我的");
				dict5.Add(key2, value2);
				dict5.Add(key3, "account_normal");
				dict5.Add(key4, "account_highlight");

				//var dict3 = new NSDictionary(MYTabBarItem.kLLTabBarItemAttributeTitle, "发布", MYTabBarItem.kLLTabBarItemAttributeNormalImageName, "post_normal", MYTabBarItem.kLLTabBarItemAttributeSelectedImageName, "post_normal", MYTabBarItem.kLLTabBarItemAttributeType, LLTabBarItemType.Rise);
				Console.WriteLine(dict3);
				//var dict4 = new NSDictionary(MYTabBarItem.kLLTabBarItemAttributeTitle, "消息", MYTabBarItem.kLLTabBarItemAttributeNormalImageName, "message_normal", MYTabBarItem.kLLTabBarItemAttributeSelectedImageName, "message_highlight", MYTabBarItem.kLLTabBarItemAttributeType, LLTabBarItemType.Normal);
				Console.WriteLine(dict4);
				//var dict5 = new NSDictionary(MYTabBarItem.kLLTabBarItemAttributeTitle, "我的", MYTabBarItem.kLLTabBarItemAttributeNormalImageName, "account_normal", MYTabBarItem.kLLTabBarItemAttributeSelectedImageName, "account_highlight", MYTabBarItem.kLLTabBarItemAttributeType, LLTabBarItemType.Normal);
				Console.WriteLine(dict5);
				tab.tabBarItemAttributes = new List<Dictionary<string, object>>() {dict1,dict2,dict3,dict4,dict5 } ;
			}

			tabbar.TabBar.AddSubview(tab);
			Window.RootViewController = tabbar;
			Window.MakeKeyAndVisible();


			return true;
		}

		public override void OnResignActivation(UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground(UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground(UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated(UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate(UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}
	}
}

