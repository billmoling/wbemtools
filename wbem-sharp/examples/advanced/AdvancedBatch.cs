using System;
using Wbem;
using System.Collections.Generic;
using Wbem.Batch;

namespace WbemExamples
{
    class AdvancedBatch
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

            GetClassOpSettings gcos = new GetClassOpSettings("CIM_NFS");
            EnumerateClassNamesOpSettings ecnos = new EnumerateClassNamesOpSettings();

            GetClassOpSettings gcos2 = new GetClassOpSettings("CIM_Component");

            BatchRequest batch = new BatchRequest("root/cimv2");
            batch.Add(gcos);
            batch.Add(ecnos);
            batch.Add(gcos2);

            BatchResponse response = client.ExecuteBatchRequest(batch);

               
            
           

        }
    }
}
