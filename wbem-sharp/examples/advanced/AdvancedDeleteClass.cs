using System;
using Wbem;

namespace WbemExamples
{
    class AdvancedDeleteClass
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

            // Connect to the cimom and create the CIM_Dummy class
            Console.Write("Deleteing Class: CIM_Dummy... ");

            client.DeleteClass("CIM_Dummy");            

            Console.WriteLine("Done.\n");
        }
    }
}
