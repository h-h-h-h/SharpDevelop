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
	public class BlockStatementTests
	{
		#region C#
		[Test]
		public void CSharpBlockStatementTest()
		{
			BlockStatement blockStmt = (BlockStatement)ParseUtilCSharp.ParseStatment("{}", typeof(BlockStatement));
		}
		#endregion
		
		#region VB.NET
			// TODO
		#endregion
	}
}
