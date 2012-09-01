using System;
using System.IO;
using System.Net;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace mono_bug.cs
{
    class Program
    {
        internal class AcceptAllCertificatePolicy : ICertificatePolicy
        {
            public bool CheckValidationResult(ServicePoint sPoint, X509Certificate cert, WebRequest wRequest, int certProb)
            {
                // Always accept
                return true;
            }
        }

        static string SendCimomRequest(string uri, NetworkCredential Credentials, string Message)
        {
            HttpWebRequest httpReq;
            HttpWebResponse httpResp;
            string nameSpaceValue;            
            Random rand = new Random();            

            httpReq = (HttpWebRequest)WebRequest.Create(uri);
            httpReq.Credentials = Credentials;
            httpReq.ContentLength = Message.Length;

            // The namespace needs a 2 digit number between 00 and 99
            nameSpaceValue = rand.Next(10).ToString() + rand.Next(10).ToString();

            // Setup the http request
            httpReq.PreAuthenticate = false;
            httpReq.ProtocolVersion = HttpVersion.Version11;
            httpReq.Method = "M-POST";
            httpReq.ContentType = "application/xml;charset=\"UTF-8\"";
            httpReq.Accept = "text/xml,application/xml";

            // Add the Http/CIM headers
            httpReq.Headers.Add("Man", "http://www.dmtf.org/cim/mapping/http/v1.0;ns=" + nameSpaceValue);
            httpReq.Headers.Add(nameSpaceValue.ToString() + "-CIMProtocolVersion", "1.0");
            httpReq.Headers.Add(nameSpaceValue + "-CIMOperation", "MethodCall");
            httpReq.Headers.Add(nameSpaceValue + "-CIMMethod", "GetClass");
            httpReq.Headers.Add(nameSpaceValue + "-CIMObject", "Smash");

            ServicePointManager.CertificatePolicy = new AcceptAllCertificatePolicy();
                                   
            // Put the message in the send buffer.
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] messageInBytes = utf8.GetBytes(Message);

            Stream requestStream = httpReq.GetRequestStream();
            requestStream.Write(messageInBytes, 0, messageInBytes.Length);
            requestStream.Close();

            httpResp = (HttpWebResponse)httpReq.GetResponse();            

            StreamReader streamRead = new StreamReader(httpResp.GetResponseStream(), System.Text.UTF8Encoding.UTF8);
            Message = streamRead.ReadToEnd();

            streamRead.Close();
            httpResp.Close();
            
            return Message;
        }
        static void Main(string[] args)
        {
            string xmlRequest = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"no\"?>"              +
                                "<CIM DTDVERSION=\"2.0\" CIMVERSION=\"2.0\">"                               +
                                "   <MESSAGE ID=\"1\" PROTOCOLVERSION=\"1.0\">"                             +
                                "       <SIMPLEREQ>"                                                        +
                                "           <IMETHODCALL NAME=\"GetClass\">"                                +
                                "               <LOCALNAMESPACEPATH>"                                       +
                                "                   <NAMESPACE NAME=\"smash\" />"                           +
                                "               </LOCALNAMESPACEPATH>"                                      +
                                "               <IPARAMVALUE NAME=\"IncludeClassOrigin\">"                  +
                                "                   <VALUE>FALSE</VALUE>"                                   +
                                "               </IPARAMVALUE>"                                             +
                                "               <IPARAMVALUE NAME=\"ClassName\">"                           +
                                "                   <CLASSNAME NAME=\"CIM_PhysicalAssetCapabilities\" />"   +
                                "               </IPARAMVALUE>"                                             +
                                "               <IPARAMVALUE NAME=\"IncludeQualifiers\">"                   +
                                "                   <VALUE>TRUE</VALUE>"                                    +
                                "               </IPARAMVALUE>"                                             +
                                "               <IPARAMVALUE NAME=\"LocalOnly\">"                           +
                                "                   <VALUE>TRUE</VALUE>"                                    +
                                "               </IPARAMVALUE>"                                             +
                                "           </IMETHODCALL>"                                                 +
                                "       </SIMPLEREQ>"                                                       +
                                "   </MESSAGE>"                                                             +
                                "</CIM>";


            string host = string.Empty; 
            string defaultHost = "151.155.188.102";

            Console.Write("Enter SLES 10 server hostname [" + defaultHost + "]: ");
            host = Console.ReadLine();

            host = host.Trim();
            if (host == string.Empty)
            {
                host = defaultHost;
            }

            Console.WriteLine(SendCimomRequest("https://" + host + ":5989/cimom",
                                               new NetworkCredential("root", "novell"), xmlRequest));
        }
    }
}

