// CimClassTest.cs created with MonoDevelop
// User: rhowell at 2:24 PM 3/8/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Wbem;
using NUnit.Framework;

namespace WbemTests
{
	
	[TestFixture]
	public class CimClassTest
	{
		[Test]
		public void CtorTest()
		{
			CimClass a = new CimClass();
			Assert.AreEqual(a.ClassName,new CimName(null));
			Assert.AreEqual(a.SuperClass,new CimName(null));
			
			CimClass b = new CimClass("myclass");
			Assert.AreEqual(b.ClassName,new CimName("myclass"));
			Assert.AreEqual(b.SuperClass,new CimName(null));
			
			CimClass c = new CimClass("myclass","CIM_NFS");
			Assert.AreEqual(c.SuperClass,new CimName("CIM_NFS"));
			Assert.AreNotEqual(c.SuperClass,new CimName("xCIM_NFS"));
			
			
		}
	}
}
