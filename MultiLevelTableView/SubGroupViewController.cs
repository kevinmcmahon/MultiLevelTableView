using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MultiLevelTableView
{
	[MonoTouch.Foundation.Register("SubGroupViewController")]
	public partial class SubGroupViewController : UITableViewController
	{
		List<string> SubGroupData = new List<string> { "Item1", "Item2", "Item3" };
		string SelectedGroup;
		
		public SubGroupViewController (string selectedGroup) : base ()
		{
			this.SelectedGroup = selectedGroup;	
		}
		
		class DataSource : UITableViewDataSource
		{
			SubGroupViewController tvc;
			static NSString kCellIdentifier = new NSString ("MyIdentifier");
	
			public DataSource (SubGroupViewController tvc)
			{
				this.tvc = tvc;
			}
			
			public override int RowsInSection (UITableView tableView, int section)
			{
				return tvc.SubGroupData.Count;
			}
	
			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (kCellIdentifier);
				if (cell == null)
				{
					cell = new UITableViewCell (UITableViewCellStyle.Default, kCellIdentifier);
				}
			
				cell.TextLabel.Text = tvc.SubGroupData.ElementAt(indexPath.Row);
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				return cell;
			}
		}
	
		class TableDelegate : UITableViewDelegate
		{
			SubGroupViewController tvc;
			ItemDetailViewController idvc;
			
			public TableDelegate (SubGroupViewController tvc)
			{
				this.tvc = tvc;
			}
			
			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				string itemName = tvc.SubGroupData.ElementAt(indexPath.Row);
				
				idvc = new ItemDetailViewController(itemName);
				
				tvc.NavigationController.PushViewController(idvc, true);
			}
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			this.Title = SelectedGroup; //SelectedGroup set via ctor
			
			TableView.Delegate = new TableDelegate (this);
			TableView.DataSource = new DataSource (this);
		}
			
	}
}