using System;

namespace WbemTests
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string[] args2 = { System.Environment.CurrentDirectory + "\\wbem-tests.exe" };
            NUnit.Gui.AppEntry.Main(args2);
        }
    }
}
