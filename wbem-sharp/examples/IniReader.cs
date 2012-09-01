using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace WbemExamples
{
    class IniReader
    {
        Dictionary<string, Dictionary<string, string>> ini = null;

        public IniReader(string propertiesFile)
        {
            if (File.Exists(propertiesFile))
            {
                try
                {
                    ini = new Dictionary<string, Dictionary<string, string>>();
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
                catch
                {
                    throw(new ApplicationException(propertiesFile + " is not a valid ini file."));
                }
            }
        }

        public string[] ToWbemAuth()
        {
            if (ini == null)
                return null; // empty string array

            List<string> retVal = new List<string>(4);
            retVal.Add(ini["[Auth]"]["host"]);
            retVal.Add(ini["[Auth]"]["username"]);
            retVal.Add(ini["[Auth]"]["password"]);
            retVal.Add(ini["[Auth]"]["namespace"]);

            return retVal.ToArray();
        }
    }
}
