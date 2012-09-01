using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Wbem;
using System.IO;

namespace DemoGui
{
    static class Program
    {
        static string propertiesFile = "DemoGui.ini";
        static Dictionary<string, Dictionary<string, string>> ini = new Dictionary<string, Dictionary<string, string>>();

        static void ReadIniFile()
        {
            if (File.Exists(propertiesFile))
            {               
                try
                {
                    StreamReader props = new StreamReader(propertiesFile);
                    
                    string curSection = "[Global]";     // Default Section
                    ini.Add(curSection, new Dictionary<string, string>());

                    string line = props.ReadLine();
                    while ((line != null) && (line != string.Empty))
                    {
                        line = line.Trim();

                        if (line[0] != ';') // Ini file comment
                        {
                            // This should probably be changed over to a regex at some point
                            if ((line[0] == '[') && (line[line.Length - 1] == ']'))
                            {
                                // change the current section
                                ini.Add(line, new Dictionary<string, string>());
                                curSection = line;
                            }
                            else
                            {
                                string[] values = line.Split('=');
                                ini[curSection].Add(values[0].ToLower().Trim(), values[1].Trim());
                            }
                        }

                        line = props.ReadLine();  
                    }
                    props.Close();
                }
                catch(Exception ex)
                {
					Console.WriteLine(ex.ToString());
                    MessageBox.Show(propertiesFile + " is not valid.");
                    return;
                }
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ReadIniFile();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AuthForm authFrm = null;

            if (ini.ContainsKey("[Auth]"))
                authFrm = new AuthForm(ini["[Auth]"]);
            else
                authFrm = new AuthForm(null);

            DialogResult result = authFrm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Form1 form1 = new Form1(authFrm, ini);
                authFrm.Close();
                authFrm = null;     // It's ready for the GC when the mainFrm is done.
                Application.Run(form1);
            }
        }
    }
}