using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using ICSharpCode.SharpDevelop.Gui;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.Core;

namespace SearchAndReplace
{
	/// <summary>
	/// Description of SearchFolderNode.
	/// </summary>
	public class SearchFolderNode : ExtFolderNode
	{
		List<SearchResult> results = new List<SearchResult>();
		string fileName;
		string occurences;
		Image icon;
		
		public List<SearchResult> Results { 
			get {
				return results;
			}
		}
		
		public SearchFolderNode(string fileName)
		{
			drawDefault = false;
			this.fileName = fileName;
			icon = IconService.GetBitmap(IconService.GetImageForFile(fileName));
			Nodes.Add(new TreeNode());
		}
		
		public void SetText()
		{
			if (results.Count == 1) {
				occurences = " (1 occurence)";
			} else {
				occurences = " (" + results.Count + " occurences)";
			}
			
			this.Text = fileName + occurences;
		}
		protected override int MeasureItemWidth(DrawTreeNodeEventArgs e)
		{
			Graphics g = e.Graphics;
			int x = MeasureTextWidth(g, fileName, Font);
			x += MeasureTextWidth(g, occurences, ItalicFont);
			if (icon != null) {
				x += icon.Width;
			}
			return x + 3;
		}
		protected override void DrawForeground(DrawTreeNodeEventArgs e)
		{
			Graphics g = e.Graphics;
			float x = e.Bounds.X;
			if (icon != null) {
				g.DrawImage(icon, x, e.Bounds.Y);
				x += icon.Width;
			}
			DrawText(g, fileName, Brushes.Black, Font, ref x, e.Bounds.Y);
			DrawText(g, occurences, Brushes.Gray,  ItalicFont, ref x, e.Bounds.Y);
		}
			
		protected override void Initialize()
		{
			Nodes.Clear();
			IDocument document = results[0].CreateDocument();
			if (document.HighlightingStrategy == null) {
				document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategyForFile(fileName);
			}
			foreach (SearchResult result in results) {
				TreeNode newResult = new SearchResultNode(document, result);
				Nodes.Add(newResult);
			}
		}
	}
}
