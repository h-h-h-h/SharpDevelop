// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version value="$version"/>
// </file>

using System;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using System.Xml;
using System.CodeDom.Compiler;
using System.Threading;

using ICSharpCode.SharpDevelop.Internal.Project;
using ICSharpCode.SharpDevelop.Internal.Templates;
using ICSharpCode.SharpDevelop.Gui;

namespace ICSharpCode.WixBinding
{
	public class WixLanguageBinding : ILanguageBinding
	{
		public const string LanguageName = "WIX";
		
		WixExecutionManager executionManager = new WixExecutionManager();
		WixCompilerManager  compilerManager  = new WixCompilerManager();
		
		public string Language {
			get {
				return LanguageName;
			}
		}
		
		public void Execute(string filename, bool debug)
		{
			Debug.Assert(executionManager != null);
			executionManager.Execute(filename, debug);
		}
		
		public void Execute(IProject project, bool debug)
		{
			Debug.Assert(executionManager != null);
			executionManager.Execute(project, debug);
		}
		
		public string GetCompiledOutputName(string fileName)
		{
			Debug.Assert(compilerManager != null);
			return compilerManager.GetCompiledOutputName(fileName);
		}
		
		public string GetCompiledOutputName(IProject project)
		{
			Debug.Assert(compilerManager != null);
			return compilerManager.GetCompiledOutputName(project);
		}
		
		public bool CanCompile(string fileName)
		{
			Debug.Assert(compilerManager != null);
			return compilerManager.CanCompile(fileName);
		}
		
		public ICompilerResult CompileFile(string fileName)
		{
			Debug.Assert(compilerManager != null);
			WixCompilerParameters param = new WixCompilerParameters();
			param.OutputAssembly = Path.ChangeExtension(fileName, ".msi");
			return compilerManager.CompileFile(fileName, param);
		}
		
		public ICompilerResult CompileProject(IProject project)
		{
			Debug.Assert(compilerManager != null);
			return compilerManager.CompileProject(project);
		}
		
		public ICompilerResult RecompileProject(IProject project)
		{
			return CompileProject(project);
		}
		
		public IProject CreateProject(ProjectCreateInformation info, XmlElement projectOptions)
		{
			return new WixProject(info, projectOptions);
		}
	}
}
