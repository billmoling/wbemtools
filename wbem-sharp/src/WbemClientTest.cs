// WbemClientTest.cs created with MonoDevelop
// User: rhowell at 1:53 PM 3/8/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Net;
using NUnit.Framework;
using Wbem;

namespace WbemTests
{
	[TestFixture]
	public class WbemClientTest
	{
		WbemClient client = null;
		
		[SetUp]
		public void Setup()
		{
			Console.WriteLine("Test setup");
			client = WbemSharpTests.TestClient;
		}
		
		[TearDown]
		public void TearDown()
		{
			client = null;
		}
		
		[Test]
		public void CtorTest()
		{
			WbemClient c = new WbemClient("localhost","root","password","smash");
			
			Assert.IsTrue(c.IsSecure);
			Assert.AreEqual(c.Port,5989);
			
			c = new WbemClient("localhost",new NetworkCredential("user","password"),"root/cimv2");
			
		}
		
		
		[Test]
		public void GetClassTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		[Test]
		public void GetInstanceTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		[Test]
		public void DeleteClassTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		[Test]
		public void DeleteInstanceTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		[Test]
		public void CreateClassTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		[Test]
		public void CreateInstanceTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		[Test]
		public void ModifyClassTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		[Test]
		public void ModifyInstanceTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		//Enumerate tests
		[Test]
		public void EnumerateClassesTest()
		{
			
			try
			{			
				CimClassList list = client.EnumerateClasses();
				Console.WriteLine(list.Count);
				
				EnumerateClassesOpSettings op = new EnumerateClassesOpSettings();
				op.LocalOnly = false;
				
				CimClassList l2 = client.EnumerateClasses(op);
				Console.WriteLine(l2.Count);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.ToString());
			}
		}
		
		[Test]
		public void EnumerateClassesTest2()
		{
			
			Assert.IsNotNull(client);
			try
			{			
				
				EnumerateClassesOpSettings op = new EnumerateClassesOpSettings();
				op.LocalOnly = false;
				op.DeepInheritance = true;
				
				CimClassList list = client.EnumerateClasses(op);
				
				Console.WriteLine(list.Count);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.ToString());
			}
		}
		
		[Test]
		public void EnumerateClassNamesTest()
		{
			try
			{			
				CimNameList list = client.EnumerateClassNames();
				//DeepInheritance == false
				
				bool cim_log = false;
				foreach(CimName name in list)
				{
					if (name == "CIM_Log") cim_log = true; //Should NOT be found
					
				}
				Assert.IsFalse(cim_log);
				
				
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.ToString());
			}
		}
		
		[Test]
		public void EnumerateClassNamesTest2()
		{
			try
			{		
				EnumerateClassNamesOpSettings op = new EnumerateClassNamesOpSettings();
				op.DeepInheritance = true;
				
				CimNameList list = client.EnumerateClassNames(op);
				Console.WriteLine(list.Count);
				
				
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.ToString());
			}
		}
		
		[Test]
		public void EnumerateClassNamesTest3()
		{
			try
			{		
				
				//Should only get class names derived from this class
				EnumerateClassNamesOpSettings op = new EnumerateClassNamesOpSettings("CIM_FileSystem");
				op.DeepInheritance = true;
				
				CimNameList list = client.EnumerateClassNames(op);
				
				
				bool cim_nfs = false;
				bool cim_log = false;
				foreach(CimName name in list)
				{
					if (name == "CIM_NFS") cim_nfs = true; // Should be found
					if (name == "CIM_Log") cim_log = true; //Should NOT be found
					
				}
				Assert.IsTrue(cim_nfs);
				Assert.IsFalse(cim_log);				
				
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.ToString());
			}
		}
		
		[Test]
		public void EnumerateInstancesTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		[Test]
		public void EnumerateInstanceNamesTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		[Test]
		public void ExecQueryTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		[Test]
		public void AssociatorsTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		[Test]
		public void AssociatorNamesTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		[Test]
		public void ReferencesTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		[Test]
		public void ReferenceNamesTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		
		[Test]
		public void GetPropertyTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		[Test]
		public void SetPropertyTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		[Test]
		public void GetQualifierTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		[Test]
		public void SetQualifierTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		[Test]
		public void DeleteQualifierTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		[Test]
		public void EnumerateQualifiersTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		[Test]
		public void ExecuteQueryTest()
		{
			Assert.Ignore("NUnit test not yet implemented");
		}
		
		
#region Extra methods
		
		[Test]
		public void EnumerateNamespacesTest()
		{
			
			Assert.IsNotNull(client);
			try
			{			
				string []nss = client.EnumerateNamespaces();
				Console.WriteLine(nss.Length);
				foreach(string s in nss)
				{
					Console.WriteLine(s);
				}
			}
			catch
			{
				Assert.Fail();
			}
		}
#endregion
		
	}
}
