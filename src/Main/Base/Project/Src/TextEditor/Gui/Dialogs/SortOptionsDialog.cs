// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version value="$version"/>
// </file>

using System;
using System.Drawing;
using System.DirectoryServices; // for SortDirection
using System.ComponentModel;
using System.Windows.Forms;

using ICSharpCode.SharpDevelop.Gui;
using ICSharpCode.SharpDevelop.DefaultEditor.Gui.Editor;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.Core;

using ICSharpCode.SharpDevelop.Gui.XmlForms;
using ICSharpCode.TextEditor;


namespace ICSharpCode.SharpDevelop.Gui
{
	public class SortOptionsDialog : BaseSharpDevelopForm
	{
		public static readonly string removeDupesOption       = "ICSharpCode.SharpDevelop.Gui.SortOptionsDialog.RemoveDuplicateLines";
		public static readonly string caseSensitiveOption     = "ICSharpCode.SharpDevelop.Gui.SortOptionsDialog.CaseSensitive";
		public static readonly string ignoreWhiteSpacesOption = "ICSharpCode.SharpDevelop.Gui.SortOptionsDialog.IgnoreWhitespaces";
		public static readonly string sortDirectionOption     = "ICSharpCode.SharpDevelop.Gui.SortOptionsDialog.SortDirection";
		
		public SortOptionsDialog()
		{
			SetupFromXmlStream(this.GetType().Assembly.GetManifestResourceStream("Resources.SortOptionsDialog.xfrm"));
			
			AcceptButton = (Button)ControlDictionary["okButton"];
			CancelButton = (Button)ControlDictionary["cancelButton"];
			((CheckBox)ControlDictionary["removeDupesCheckBox"]).Checked = PropertyService.Get(removeDupesOption, false);
			((CheckBox)ControlDictionary["caseSensitiveCheckBox"]).Checked = PropertyService.Get(caseSensitiveOption, true);
			((CheckBox)ControlDictionary["ignoreWhiteSpacesCheckBox"]).Checked = PropertyService.Get(ignoreWhiteSpacesOption, false);
			
			((RadioButton)ControlDictionary["ascendingRadioButton"]).Checked = ((SortDirection)PropertyService.Get(sortDirectionOption, SortDirection.Ascending)) == SortDirection.Ascending;
			((RadioButton)ControlDictionary["descendingRadioButton"]).Checked = ((SortDirection)PropertyService.Get(sortDirectionOption, SortDirection.Ascending)) == SortDirection.Descending;
			
			// insert event handlers
			ControlDictionary["okButton"].Click  += new EventHandler(OkEvent);
		}
		
		void OkEvent(object sender, EventArgs e)
		{
			PropertyService.Set(removeDupesOption, ((CheckBox)ControlDictionary["removeDupesCheckBox"]).Checked);
			PropertyService.Set(caseSensitiveOption, ((CheckBox)ControlDictionary["caseSensitiveCheckBox"]).Checked);
			PropertyService.Set(ignoreWhiteSpacesOption, ((CheckBox)ControlDictionary["ignoreWhiteSpacesCheckBox"]).Checked);
			if (((RadioButton)ControlDictionary["ascendingRadioButton"]).Checked) {
				PropertyService.Set(sortDirectionOption, SortDirection.Ascending);
			} else {
				PropertyService.Set(sortDirectionOption, SortDirection.Descending);
			}
		}
	}
}
