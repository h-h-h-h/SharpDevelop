using System;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.Resources;

namespace ICSharpCode.SharpDevelop
{	
	public class SplashScreenForm : Form
	{
		static SplashScreenForm splashScreen = new SplashScreenForm();
		static ArrayList requestedFileList = new ArrayList();
		static ArrayList parameterList = new ArrayList();
		Bitmap bitmap;
		
		public static SplashScreenForm SplashScreen {
			get {
				return splashScreen;
			}
		}		
		
		public SplashScreenForm()
		{
#if !DEBUG
			TopMost         = true;
#endif
			FormBorderStyle = FormBorderStyle.None;
			StartPosition   = FormStartPosition.CenterScreen;
			ShowInTaskbar   = false;
			bitmap = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Resources.SplashScreen.jpg"));
			Size            = bitmap.Size;
			BackgroundImage = bitmap;
		}
		
		protected override void Dispose(bool disposing) 
		{
			if (disposing) {
				if (bitmap != null) {
					bitmap.Dispose();
					bitmap = null;
				}
			}
			base.Dispose(disposing);
		}
		
		public static string[] GetParameterList()
		{
			return GetStringArray(parameterList);
		}
		
		public static string[] GetRequestedFileList()
		{
			return GetStringArray(requestedFileList);
		}
		
		static string[] GetStringArray(ArrayList list)
		{
			return (string[])list.ToArray(typeof(string));
		}
		
		public static void SetCommandLineArgs(string[] args)
		{
			requestedFileList.Clear();
			parameterList.Clear();
			
			foreach (string arg in args) {
				if (arg[0] == '-' || arg[0] == '/') {
					int markerLength = 1;
					
					if (arg.Length >= 2 && arg[0] == '-' && arg[1] == '-') {
						markerLength = 2;
					}
					
					parameterList.Add(arg.Substring(markerLength));
				} else {
					requestedFileList.Add(arg);
				}
			}
		}
	}
}
