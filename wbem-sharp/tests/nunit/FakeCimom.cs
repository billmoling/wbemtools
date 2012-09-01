using System;
using System.Collections.Generic;
using System.Text;

namespace WbemTests
{
    public class FakeCimom
    {
        const string GetClassReq = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"no\"?>\r\n<CIM DTDVERSION=\"2.0\" CIMVERSION=\"2.0\">\r\n  <MESSAGE ID=\"1\" PROTOCOLVERSION=\"1.0\">\r\n    <SIMPLEREQ>\r\n      <IMETHODCALL NAME=\"GetClass\">\r\n        <LOCALNAMESPACEPATH>\r\n          <NAMESPACE NAME=\"namespace\" />\r\n        </LOCALNAMESPACEPATH>\r\n        <IPARAMVALUE NAME=\"IncludeClassOrigin\">\r\n          <VALUE>FALSE</VALUE>\r\n        </IPARAMVALUE>\r\n        <IPARAMVALUE NAME=\"ClassName\">\r\n          <CLASSNAME NAME=\"CIM_Component\" />\r\n        </IPARAMVALUE>\r\n        <IPARAMVALUE NAME=\"IncludeQualifiers\">\r\n          <VALUE>TRUE</VALUE>\r\n        </IPARAMVALUE>\r\n        <IPARAMVALUE NAME=\"LocalOnly\">\r\n          <VALUE>TRUE</VALUE>\r\n        </IPARAMVALUE>\r\n      </IMETHODCALL>\r\n    </SIMPLEREQ>\r\n  </MESSAGE>\r\n</CIM>";
        const string GetClassResp = "<?xml version=\"1.0\" ?><CIM CIMVERSION=\"2.0\" DTDVERSION=\"2.0\"><MESSAGE ID=\"1\" PROTOCOLVERSION=\"1.0\"><SIMPLERSP><IMETHODRESPONSE NAME=\"GetClass\"><IRETURNVALUE><CLASS NAME=\"CIM_Component\"><QUALIFIER NAME=\"Association\" TYPE=\"boolean\" OVERRIDABLE=\"false\" ><VALUE>true</VALUE></QUALIFIER><QUALIFIER NAME=\"Abstract\" TYPE=\"boolean\" TOSUBCLASS=\"false\" ><VALUE>true</VALUE></QUALIFIER><QUALIFIER NAME=\"Aggregation\" TYPE=\"boolean\" OVERRIDABLE=\"false\" ><VALUE>true</VALUE></QUALIFIER><QUALIFIER NAME=\"Version\" TYPE=\"string\" TOSUBCLASS=\"false\" TRANSLATABLE=\"true\" ><VALUE>2.7.0</VALUE></QUALIFIER><QUALIFIER NAME=\"Description\" TYPE=\"string\" TRANSLATABLE=\"true\" ><VALUE>CIM_Component is a generic association used to establish &apos;part of&apos; relationships between Managed Elements. For example, it could be used to define the components or parts of a System.</VALUE></QUALIFIER><PROPERTY.REFERENCE NAME=\"GroupComponent\" REFERENCECLASS=\"CIM_ManagedElement\" ><QUALIFIER NAME=\"Key\" TYPE=\"boolean\" OVERRIDABLE=\"false\" ><VALUE>true</VALUE></QUALIFIER><QUALIFIER NAME=\"Aggregate\" TYPE=\"boolean\" OVERRIDABLE=\"false\" ><VALUE>true</VALUE></QUALIFIER><QUALIFIER NAME=\"Description\" TYPE=\"string\" TRANSLATABLE=\"true\" ><VALUE>The parent element in the association.</VALUE></QUALIFIER></PROPERTY.REFERENCE><PROPERTY.REFERENCE NAME=\"PartComponent\" REFERENCECLASS=\"CIM_ManagedElement\" ><QUALIFIER NAME=\"Key\" TYPE=\"boolean\" OVERRIDABLE=\"false\" ><VALUE>true</VALUE></QUALIFIER><QUALIFIER NAME=\"Description\" TYPE=\"string\" TRANSLATABLE=\"true\" ><VALUE>The child element in the association.</VALUE></QUALIFIER></PROPERTY.REFERENCE></CLASS></IRETURNVALUE></IMETHODRESPONSE></SIMPLERSP></MESSAGE></CIM>\r\n";
                
        public static string GetResponse(string request)
        {
            switch (SetMessageIdToOne(request))
            {
                case FakeCimom.GetClassReq:
                    return GetClassResp;

                default:
                    throw (new ApplicationException("Unknown Request was made to the fake cimom"));
            }
        }

        private static string SetMessageIdToOne(string request)
        {
            string resp = request.Substring(0, 112);
            resp += "1";

            int startPos = 113;
            while (request[startPos] != '"')
            {
                startPos++;
            }

            resp += request.Substring(startPos);

            return resp;
        }
    }
}
