/*
 * Created by SharpDevelop.
 * User: Omnibrain
 * Date: 13.09.2004
 * Time: 19:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using NUnit.Framework;
using ICSharpCode.NRefactory.Parser;
using ICSharpCode.NRefactory.Parser.AST;

namespace ICSharpCode.NRefactory.Tests.AST
{
	[TestFixture]
	public class UsingStatementTests
	{
		#region C#
		[Test]
		public void CSharpUsingStatementTest()
		{
			UsingStatement usingStmt = (UsingStatement)ParseUtilCSharp.ParseStatment("using (MyVar var = new MyVar()) { } ", typeof(UsingStatement));
			// TODO : Extend test.
		}
		#endregion
		
		#region VB.NET
		[Test]
		public void VBNetUsingStatementTest()
		{
			string usingText = @"
Using nf As New System.Drawing.Font(""Arial"", 12.0F, FontStyle.Bold)
        c.Font = nf
        c.Text = ""This is 12-point Arial bold""
End Using";
			UsingStatement usingStmt = (UsingStatement)ParseUtilVBNet.ParseStatment(usingText, typeof(UsingStatement));
			// TODO : Extend test.
		}
		[Test]
		public void VBNetUsingStatementTest2()
		{
			string usingText = @"
Using nf As Font = New Font()
	Bla(nf)
End Using";
			UsingStatement usingStmt = (UsingStatement)ParseUtilVBNet.ParseStatment(usingText, typeof(UsingStatement));
			// TODO : Extend test.
		}
		#endregion
	}
}
