using System;
using Wbem;

namespace WbemExamples
{
    class BasicEnumerateInstanceNames
    {
        public static void Main(string[] args)
        {
            // This first part is to simply setup the connection to the Cimom
            string progName = System.AppDomain.CurrentDomain.FriendlyName;
            if (args.Length != 4)
            {
                Console.WriteLine("Usage: " + progName + " <server name> <username> <password> <namespace>");
                return;
            }
            string host = args[0];
            string user = args[1];
            string pwd = args[2];
            string defaultNamespace = args[3];

            // This is the line that defines our wbem client. No connection is made
            // to the Cimom until a call is made.
            WbemClient client = new WbemClient(host, user, pwd, defaultNamespace);

            // Connect to the cimom and request the CIM_Capabilities class
            Console.Write("Enumerating Instance Names of Class: CIM_Capabilities... ");
            CimInstanceNameList items = client.EnumerateInstanceNames("CIM_Capabilities");
            Console.WriteLine("Done.\n");

            // Display the Instance Names that were retrieved
            Console.WriteLine("Instance Names");
            Console.WriteLine("--------------");
            foreach (CimInstanceName curItem in items)
            {
                Console.WriteLine(curItem);
            }
        }
    }
}