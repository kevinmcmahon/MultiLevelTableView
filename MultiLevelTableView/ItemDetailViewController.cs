using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MultiLevelTableView
{
	public class ItemDetailViewController : UIViewController
	{
		string ItemName;
		
		public ItemDetailViewController (string itemName)
		{
			this.ItemName = itemName;
		}
		
		public override void LoadView () 
		{ 
			RectangleF frame = UIScreen.MainScreen.ApplicationFrame; 
			UIView contentView = new UIView(frame)
									{
										BackgroundColor = UIColor.White
									};
			UILabel label = new UILabel( new RectangleF( 0f , 0f , 320f , 30f ));
			label.Text =  string.Format("{0} detail view", ItemName);
			label.Center = contentView.Center;
			label.BackgroundColor = UIColor.Clear;
			label.TextAlignment = UITextAlignment.Center;
			contentView.AddSubview(label);
			this.View = contentView;
		}
	}
}
