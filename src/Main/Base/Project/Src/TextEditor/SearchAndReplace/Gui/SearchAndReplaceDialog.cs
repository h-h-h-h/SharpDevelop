using System;
using System.Drawing;
using System.Windows.Forms;

using ICSharpCode.Core;
using ICSharpCode.SharpDevelop.Gui;

namespace SearchAndReplace
{
	public enum SearchAndReplaceMode {
		Search,
		Replace
	}
	
	public class SearchAndReplaceDialog : Form
	{
		public static string SearchPattern  = "";
		public static string ReplacePattern = "";
		
		ToolStripButton searchButton = new ToolStripButton();
		ToolStripButton replaceButton = new ToolStripButton();
		
		SearchAndReplacePanel searchAndReplacePanel;
		
		public SearchAndReplaceDialog(SearchAndReplaceMode searchAndReplaceMode)
		{
			this.Owner           = WorkbenchSingleton.MainForm;
			this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			this.ShowInTaskbar   = false;
			this.TopMost         = false;
			this.Text            = "Search and Replace";
			this.StartPosition   = FormStartPosition.CenterParent;
			
			searchAndReplacePanel = new SearchAndReplacePanel();
			searchAndReplacePanel.Dock = DockStyle.Fill;
			Controls.Add(searchAndReplacePanel);
			
			ToolStrip toolStrip = new ToolStrip();
			toolStrip.Dock = DockStyle.Top;
			toolStrip.Stretch   = true;
			toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			
			searchButton.Text = "&Search";
			searchButton.Image = IconService.GetBitmap("Icons.16x16.FindIcon");
			searchButton.Checked = searchAndReplaceMode == SearchAndReplaceMode.Search;
			searchButton.Click += new EventHandler(SearchButtonClick);
			toolStrip.Items.Add(searchButton);
			
			replaceButton.Text = "&Replace";
			replaceButton.Image = IconService.GetBitmap("Icons.16x16.ReplaceIcon");
			replaceButton.Checked = searchAndReplaceMode == SearchAndReplaceMode.Replace;
			replaceButton.Click += new EventHandler(ReplaceButtonClick);
			toolStrip.Items.Add(replaceButton);
			
			Controls.Add(toolStrip);
			SetSearchAndReplaceMode();
		}
		
		void SearchButtonClick(object sender, EventArgs e)
		{
			if (!searchButton.Checked) {
				searchButton.Checked = true;
				replaceButton.Checked = false;
				SetSearchAndReplaceMode();
				Focus();
			}
		}
		
		void ReplaceButtonClick(object sender, EventArgs e)
		{
			if (!replaceButton.Checked) {
				replaceButton.Checked = true;
				searchButton.Checked = false;
				SetSearchAndReplaceMode();
				Focus();
			}
		}
		
		void SetSearchAndReplaceMode()
		{
			searchAndReplacePanel.SearchAndReplaceMode = searchButton.Checked ? SearchAndReplaceMode.Search : SearchAndReplaceMode.Replace;
			if (searchButton.Checked) { 
				this.ClientSize      = new Size(430, 335);
			} else {
				this.ClientSize      = new Size(430, 385);
			}
		}
		
	}
}
