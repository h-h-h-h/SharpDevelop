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
	public class TryCatchStatementTests
	{
		#region C#
		[Test]
		public void CSharpSimpleTryCatchStatementTest()
		{
			TryCatchStatement tryCatchStatement = (TryCatchStatement)ParseUtilCSharp.ParseStatment("try { } catch { } ", typeof(TryCatchStatement));
			// TODO : Extend test.
		}
		
		[Test]
		public void CSharpSimpleTryCatchStatementTest2()
		{
			TryCatchStatement tryCatchStatement = (TryCatchStatement)ParseUtilCSharp.ParseStatment("try { } catch (Exception e) { } ", typeof(TryCatchStatement));
			// TODO : Extend test.
		}
		
		[Test]
		public void CSharpSimpleTryCatchFinallyStatementTest()
		{
			TryCatchStatement tryCatchStatement = (TryCatchStatement)ParseUtilCSharp.ParseStatment("try { } catch (Exception) { } finally { } ", typeof(TryCatchStatement));
			// TODO : Extend test.
		}
		#endregion
		
		#region VB.NET
			// TODO
		#endregion 
	}
}
