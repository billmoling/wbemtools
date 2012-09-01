// WbemSharpTests.cs created with MonoDevelop
// User: rhowell at 3:32 PM 3/8/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using NUnit.Framework;
using Wbem;
using System.IO;

namespace WbemTests
{
	
	//This class is for all subsequest tests to use to read connection settings from file.
	// See README-NUNIT
	
	//The test cases just have to get the WbemClient from WbemSharpTests.TestClient
	
	[SetUpFixture]
	public class WbemSharpTests
	{
		private static WbemClient _clientTest = null;
		public static WbemClient TestClient
		{
			get 
			{
				if (_clientTest == null)
					_clientTest = readConfig();
				return _clientTest;
			}
		}
		
		public WbemSharpTests()
		{
			
		}
		
		private static WbemClient readConfig()
		{
			StreamReader reader = new StreamReader("wbemsharptests.conf");
			string line = reader.ReadLine();
			string [] args = line.Split(' ');
			
			WbemClient client = new WbemClient(args[0],args[1],args[2],args[3]);
			
			
			return client;
		}
		
		[SetUp]
		public void Setup()
		{
			Console.WriteLine("Fixture Setup");
			//clientTest = new WbemClient("151.155.188.116","root","novell","root/cimv2");
		}
		
		[TearDown]
		public void TearDown()
		{
			Console.WriteLine("Fixture TearDown");
			//clientTest = null;
		}
	}
}
