using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MultiLevelTableView
{
	[MonoTouch.Foundation.Register("RootViewController")]
	public partial class RootViewController : UITableViewController
	{
		public List<string> RootData = new List<string> { "Group1", "Group2" };
		
		class DataSource : UITableViewDataSource
		{
			static NSString kCellIdentifier = new NSString ("MyIdentifier");
			RootViewController tvc;
			
			public DataSource (RootViewController tvc)
			{
				this.tvc = tvc;
			}
			
			public override int RowsInSection (UITableView tableView, int section)
			{
				return tvc.RootData.Count;
			}
	
			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (kCellIdentifier);
				
				if (cell == null)
				{
					cell = new UITableViewCell (UITableViewCellStyle.Default, kCellIdentifier);
				}
				
				cell.TextLabel.Text = tvc.RootData.ElementAt(indexPath.Row);
				cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
				return cell;
			}
		}
	
		class TableDelegate : UITableViewDelegate
		{
			RootViewController tvc;
			SubGroupViewController sgvc;
			
			public TableDelegate (RootViewController tvc)
			{
				this.tvc = tvc;
			}
			
			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				string selectedGroup = tvc.RootData.ElementAt(indexPath.Row);
				
				if(sgvc == null)
					sgvc = new SubGroupViewController(selectedGroup);
				
				tvc.NavigationController.PushViewController(sgvc,true);
			}
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			TableView.Delegate = new TableDelegate (this);
			TableView.DataSource = new DataSource (this);
		}
			
	}
}