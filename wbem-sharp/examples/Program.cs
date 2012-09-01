using System;

namespace WbemExamples
{
    class Program
    {
        static string[] AuthInfo = null;

        static void BasicMenu()
        {
            string response = string.Empty;

            do
            {
                Console.WriteLine("\n\n\nBasic Examples Menu");
                Console.WriteLine("------------------");
                Console.WriteLine("1. EnumerateNamespaces");
                Console.WriteLine("2. GetClass");
                Console.WriteLine("3. EnumerateClassNames");
                Console.WriteLine("4. EnumerateClasses");
                Console.WriteLine("5. BasicGetInstance");                
                Console.WriteLine("6. BasicEnumerateInstanceNames");                
                Console.WriteLine("7. BasicEnumerateInstances");                
                Console.WriteLine("Q. Quit to Main Menu");
                Console.Write("\n> ");
                response = Console.ReadLine();

                Console.WriteLine("\n\n\n");

                switch (response)
                {
                    case "1":
                        BasicEnumerateNamespaces.Main(AuthInfo);
                        break;

                    case "2":
                        BasicGetClass.Main(AuthInfo);
                        break;

                    case "3":
                        BasicEnumerateClassNames.Main(AuthInfo);
                        break;

                    case "4":
                        BasicEnumerateClasses.Main(AuthInfo);
                        break;

                    case "5":
                        BasicGetInstance.Main(AuthInfo);
                        break;

                    case "6":
                        BasicEnumerateInstanceNames.Main(AuthInfo);
                        break;

                    case "7":
                        BasicEnumerateInstances.Main(AuthInfo);
                        break;
                }

            } while (response.ToUpper() != "Q");
        }

        static void MediumMenu()
        {
            string response = string.Empty;

            do
            {
                Console.WriteLine("\n\n\nMedium Examples Menu");
                Console.WriteLine(      "-------------------");                
                Console.WriteLine("Q. Quit to Main Menu");
                Console.Write("\n> ");
                response = Console.ReadLine();

                Console.WriteLine("\n\n\n");

                switch (response)
                {
                    case "1":                        
                        break;
                }

            } while (response.ToUpper() != "Q");
        }

        static void AdvancedMenu()
        {
            string response = string.Empty;

            do
            {
                Console.WriteLine("\n\n\nAdvanced Examples Menu");
                Console.WriteLine(      "---------------------");
                Console.WriteLine("1. CreateClass");
                Console.WriteLine("2. ModifyClass");
                Console.WriteLine("3. DeleteClass");
                Console.WriteLine("4. CreateInstance");
                Console.WriteLine("5. ModifyInstance");
                Console.WriteLine("6. DeleteInstance");
                Console.WriteLine("7. Batch");
                Console.WriteLine("Q. Quit to Main Menu");
                Console.Write("\n> ");
                response = Console.ReadLine();

                Console.WriteLine("\n\n\n");

                switch (response)
                {
                    case "1":
                        AdvancedCreateClass.Main(AuthInfo);
                        break;
                    case "2":
                        AdvancedModifyClass.Main(AuthInfo);
                        break;
                    case "3":
                        AdvancedDeleteClass.Main(AuthInfo);
                        break;
                    case "4":
                        AdvancedCreateInstance.Main(AuthInfo);
                        break;
                    case "5":
                        AdvancedModifyInstance.Main(AuthInfo);
                        break;
                    case "6":
                        AdvancedDeleteInstance.Main(AuthInfo);
                        break;
                    case "7":
                        AdvancedBatch.Main(AuthInfo);
                        break;
                }

            } while (response.ToUpper() != "Q");
        }

        static void GetAuthInfo()
        {
            string response = string.Empty;
            if (AuthInfo == null)
                AuthInfo = new string[4];

            Console.Write("Enter Hostname [" + AuthInfo[0] + "]: ");
            response = Console.ReadLine();
            if (response != string.Empty)
                AuthInfo[0] = response;

            Console.Write("Enter Username [" + AuthInfo[1] + "]: ");
            response = Console.ReadLine();
            if (response != string.Empty)
                AuthInfo[1] = response;

            Console.Write("Enter Password [" + AuthInfo[2] + "]: ");
            response = Console.ReadLine();
            if (response != string.Empty)
                AuthInfo[2] = response;

            Console.Write("Enter Namespace [" + AuthInfo[3] + "]: ");
            response = Console.ReadLine();
            if (response != string.Empty)
                AuthInfo[3] = response;

            Console.WriteLine("\n\n\n");
        }


        public static void Main(string[] args)
        {
            string response = string.Empty;
            AuthInfo = new IniReader("examples.ini").ToWbemAuth();

            if (AuthInfo == null)
            {
                GetAuthInfo();
            }

            do
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("---------");
                Console.WriteLine("1. Basic Examples");
                Console.WriteLine("2. Medium Examples");
                Console.WriteLine("3. Advanced Examples");
                Console.WriteLine("4. Change Auth Settings");
                Console.WriteLine("Q. Quit");

                Console.Write("\n> ");
                response = Console.ReadLine();
                
                switch (response)
                {
                    case "1":
                        BasicMenu();
                        break;

                    case "2":
                        MediumMenu();
                        break;

                    case "3":
                        AdvancedMenu();
                        break;

                    case "4":
                        GetAuthInfo();
                        break;
                }
            }
            while (response.ToUpper() != "Q");            
        }
    }
}
