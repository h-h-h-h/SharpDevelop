using System;
using System.Xml;

using ICSharpCode.SharpDevelop.Gui;

namespace ICSharpCode.Core
{
	public class DebuggerSupportsAuswerter : IAuswerter
	{
		public bool IsValid(object caller, Condition condition)
		{
			IDebugger debugger = DebuggerService.CurrentDebugger as IDebugger;
			if (debugger != null) {
				switch (condition.Properties["debuggersupports"]) {
					case "StartStop":
						return debugger.SupportsStartStop;
					case "ExecutionControl":
						return debugger.SupportsExecutionControl;
					case "Stepping":
						return debugger.SupportsStepping;
					default:
						throw new ArgumentException("Unknown debugger support for : >" + condition.Properties["debuggersupports"] + "< please fix addin file.", "debuggersupports");
				}
			}
			return false;
		}
	}
}
