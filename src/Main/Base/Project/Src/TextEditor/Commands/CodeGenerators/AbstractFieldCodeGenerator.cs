// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Mike Krueger" email="mike@icsharpcode.net"/>
//     <version value="$version"/>
// </file>

using System;
using ICSharpCode.SharpDevelop.Dom;
using ICSharpCode.Core;

namespace ICSharpCode.SharpDevelop.DefaultEditor.Commands
{
	public abstract class AbstractFieldCodeGenerator : CodeGenerator
	{
		public AbstractFieldCodeGenerator(IClass currentClass) : base(currentClass)
		{
			foreach (IField field in currentClass.Fields) {
				Content.Add(new FieldWrapper(field));
			}
		}
		
		public class FieldWrapper
		{
			IField field;
			
			public IField Field {
				get {
					return field;
				}
			}
			
			public FieldWrapper(IField field)
			{
				this.field = field;
			}
			
			public override string ToString()
			{
				
				return AmbienceService.CurrentAmbience.Convert(field);
			}
		}
	}
}
