using System;
using System.Collections.Generic;
using System.Text;

namespace DemoGui
{
    class MSXml
    {
        public static string Defaultss
        {
            get
            {
                #region XSLT String
                return  " <!--                                                                                         \n" +
                        "  |                                                                                         \n" +
                        "  | XSLT REC Compliant Version of IE5 Default Stylesheet                                                                                         \n" +
                        "  |                                                                                         \n" +
                        "  | Original version by Jonathan Marsh (jmarsh@xxxxxxxxxxxxx)                                                                                         \n" +
                        "  | http://msdn.microsoft.com/xml/samples/defaultss/defaultss.xsl                                                                                         \n" +
                        "  |                                                                                         \n" +
                        "  | Conversion to XSLT 1.0 REC Syntax by Steve Muench (smuench@xxxxxxxxxx)                                                                                         \n" +
                        "  |                                                                                         \n" +
                        "  | Originally Downloaded from: http://www.peterprovost.org/archive/2004/01/30/1049.aspx                                                                                        \n" +                        
                        "  |                                                                                         \n" +
                        "  +-->                                                                                         \n" +
                        " <xsl:stylesheet version=\"1.0\" xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\">                                                                                         \n" +
                        "    <xsl:output indent=\"no\" method=\"html\"/>                                                                                         \n" +
                        "                                                                                          \n" +
                        "    <xsl:template match=\"/\">                                                                                         \n" +
                        "       <HTML>                                                                                         \n" +
                        "          <HEAD>                                                                                         \n" +
                        "             <SCRIPT>                                                                                         \n" +
                        "                <xsl:comment><![CDATA[                                                                                         \n" +
                        "                   function f(e){                                                                                         \n" +
                        "                      if (e.className==\"ci\") {                                                                                         \n" +
                        "                        if (e.children(0).innerText.indexOf(\"\\n\")>0) fix(e,\"cb\");                                                                                         \n" +
                        "                      }                                                                                         \n" +
                        "                      if (e.className==\"di\") {                                                                                         \n" +
                        "                        if (e.children(0).innerText.indexOf(\"\\n\")>0) fix(e,\"db\");                                                                                         \n" +
                        "                      } e.id=\"\";                                                                                         \n" +
                        "                   }                                                                                         \n" +
                        "                   function fix(e,cl){                                                                                         \n" +
                        "                     e.className=cl;                                                                                         \n" +
                        "                     e.style.display=\"block\";                                                                                         \n" +
                        "                     j=e.parentElement.children(0);                                                                                         \n" +
                        "                     j.className=\"c\";                                                                                         \n" +
                        "                     k=j.children(0);                                                                                         \n" +
                        "                     k.style.visibility=\"visible\";                                                                                         \n" +
                        "                     k.href=\"#\";                                                                                         \n" +
                        "                   }                                                                                         \n" +
                        "                   function ch(e) {                                                                                         \n" +
                        "                     mark=e.children(0).children(0);                                                                                         \n" +
                        "                     if (mark.innerText==\"+\") {                                                                                         \n" +
                        "                       mark.innerText=\"-\";                                                                                         \n" +
                        "                       for (var i=1;i<e.children.length;i++) {                                                                                         \n" +
                        "                         e.children(i).style.display=\"block\";                                                                                         \n" +
                        "                       }                                                                                         \n" +
                        "                     }                                                                                         \n" +
                        "                     else if (mark.innerText==\"-\") {                                                                                         \n" +
                        "                       mark.innerText=\"+\";                                                                                         \n" +
                        "                       for (var i=1;i<e.children.length;i++) {                                                                                         \n" +
                        "                         e.children(i).style.display=\"none\";                                                                                         \n" +
                        "                       }                                                                                         \n" +
                        "                     }                                                                                         \n" +
                        "                   }                                                                                         \n" +
                        "                   function ch2(e) {                                                                                         \n" +
                        "                     mark=e.children(0).children(0);                                                                                         \n" +
                        "                     contents=e.children(1);                                                                                         \n" +
                        "                     if (mark.innerText==\"+\") {                                                                                         \n" +
                        "                       mark.innerText=\"-\";                                                                                         \n" +
                        "                       if (contents.className==\"db\"||contents.className==\"cb\") {                                                                                         \n" +
                        "                         contents.style.display=\"block\";                                                                                         \n" +
                        "                       }                                                                                         \n" +
                        "                       else {                                                                                         \n" +
                        "                         contents.style.display=\"inline\";                                                                                         \n" +
                        "                       }                                                                                         \n" +
                        "                     }                                                                                         \n" +
                        "                     else if (mark.innerText==\"-\") {                                                                                         \n" +
                        "                       mark.innerText=\"+\";                                                                                         \n" +
                        "                       contents.style.display=\"none\";                                                                                         \n" +
                        "                     }                                                                                         \n" +
                        "                   }                                                                                         \n" +
                        "                   function cl() {                                                                                         \n" +
                        "                     e=window.event.srcElement;                                                                                         \n" +
                        "                     if (e.className!=\"c\") {                                                                                         \n" +
                        "                       e=e.parentElement;                                                                                         \n" +
                        "                       if (e.className!=\"c\") {                                                                                         \n" +
                        "                         return;                                                                                         \n" +
                        "                       }                                                                                         \n" +
                        "                     }                                                                                         \n" +
                        "                     e=e.parentElement;                                                                                         \n" +
                        "                     if (e.className==\"e\") {                                                                                         \n" +
                        "                       ch(e);                                                                                         \n" +
                        "                     }                                                                                         \n" +
                        "                     if (e.className==\"k\") {                                                                                         \n" +
                        "                       ch2(e);                                                                                         \n" +
                        "                     }                                                                                         \n" +
                        "                   }                                                                                         \n" +
                        "                   function ex(){}                                                                                         \n" +
                        "                   function h(){window.status=\" \";}                                                                                         \n" +
                        "                   document.onclick=cl;                                                                                         \n" +
                        "               ]]>                                                                                         \n" +
                        "               </xsl:comment>                                                                                         \n" +
                        "             </SCRIPT>                                                                                         \n" +
                        "             <STYLE>                                                                                         \n" +
                        "               BODY {font:x-small 'Verdana'; margin-right:1.5em}                                                                                         \n" +
                        "                 .c  {cursor:hand}                                                                                         \n" +
                        "                 .b  {color:red; font-family:'Courier New'; font-weight:bold;                                                                                         \n" +
                        "                      text-decoration:none}                                                                                         \n" +
                        "                 .e  {margin-left:1em; text-indent:-1em; margin-right:1em}                                                                                         \n" +
                        "                 .k  {margin-left:1em; text-indent:-1em; margin-right:1em}                                                                                         \n" +
                        "                 .t  {color:#990000}                                                                                         \n" +
                        "                 .xt {color:#990099}                                                                                         \n" +
                        "                 .ns {color:red}                                                                                         \n" +
                        "                 .dt {color:green}                                                                                         \n" +
                        "                 .m  {color:blue}                                                                                         \n" +
                        "                 .tx {font-weight:bold}                                                                                         \n" +
                        "                 .db {text-indent:0px; margin-left:1em; margin-top:0px;                                                                                         \n" +
                        "                      margin-bottom:0px;padding-left:.3em;                                                                                         \n" +
                        "                      border-left:1px solid #CCCCCC; font:small Courier}                                                                                         \n" +
                        "                 .di {font:small Courier}                                                                                         \n" +
                        "                 .d  {color:blue}                                                                                         \n" +
                        "                 .pi {color:blue}                                                                                         \n" +
                        "                 .cb {text-indent:0px; margin-left:1em; margin-top:0px;                                                                                         \n" +
                        "                      margin-bottom:0px;padding-left:.3em; font:small Courier;                                                                                         \n" +
                        "                      color:#888888}                                                                                         \n" +
                        "                 .ci {font:small Courier; color:#888888}                                                                                         \n" +
                        "                 PRE {margin:0px; display:inline}                                                                                         \n" +
                        "            </STYLE>                                                                                         \n" +
                        "          </HEAD>                                                                                         \n" +
                        "          <BODY class=\"st\">                                                                                         \n" +
                        "             <xsl:apply-templates/>                                                                                         \n" +
                        "          </BODY>                                                                                         \n" +
                        "       </HTML>                                                                                         \n" +
                        "    </xsl:template>                                                                                         \n" +
                        "                                                                                          \n" +
                        "    <xsl:template match=\"processing-instruction()\">                                                                                         \n" +
                        "       <DIV class=\"e\">                                                                                         \n" +
                        "          <SPAN class=\"b\">                                                                                         \n" +
                        "             <xsl:call-template name=\"entity-ref\">                                                                                         \n" +
                        "                <xsl:with-param name=\"name\">nbsp</xsl:with-param>                                                                                         \n" +
                        "             </xsl:call-template>                                                                                         \n" +
                        "          </SPAN>                                                                                         \n" +
                        "          <SPAN class=\"m\">                                                                                         \n" +
                        "             <xsl:text>&lt;?</xsl:text>                                                                                         \n" +
                        "          </SPAN>                                                                                         \n" +
                        "          <SPAN class=\"pi\">                                                                                         \n" +
                        "             <xsl:value-of select=\"name(.)\"/>                                                                                         \n" +
                        "             <xsl:value-of select=\".\"/>                                                                                         \n" +
                        "          </SPAN>                                                                                         \n" +
                        "          <SPAN class=\"m\">                                                                                         \n" +
                        "             <xsl:text>?></xsl:text>                                                                                         \n" +
                        "          </SPAN>                                                                                         \n" +
                        "       </DIV>                                                                                         \n" +
                        "    </xsl:template>                                                                                         \n" +
                        "                                                                                          \n" +
                        "    <xsl:template match=\"processing-instruction('xml')\">                                                                                         \n" +
                        "       <DIV class=\"e\">                                                                                         \n" +
                        "          <SPAN class=\"b\">                                                                                         \n" +
                        "             <xsl:call-template name=\"entity-ref\">                                                                                         \n" +
                        "                <xsl:with-param name=\"name\">nbsp</xsl:with-param>                                                                                         \n" +
                        "             </xsl:call-template>                                                                                         \n" +
                        "          </SPAN>                                                                                         \n" +
                        "          <SPAN class=\"m\">                                                                                         \n" +
                        "             <xsl:text>&lt;?</xsl:text>                                                                                         \n" +
                        "          </SPAN>                                                                                         \n" +
                        "          <SPAN class=\"pi\">                                                                                         \n" +
                        "             <xsl:text>xml </xsl:text>                                                                                         \n" +
                        "             <xsl:for-each select=\"@*\">                                                                                         \n" +
                        "                <xsl:value-of select=\"name(.)\"/>                                                                                         \n" +
                        "                <xsl:text>=\"</xsl:text>                                                                                         \n" +
                        "                <xsl:value-of select=\".\"/>                                                                                         \n" +
                        "                <xsl:text>\" </xsl:text>                                                                                         \n" +
                        "             </xsl:for-each>                                                                                         \n" +
                        "          </SPAN>                                                                                         \n" +
                        "          <SPAN class=\"m\">                                                                                         \n" +
                        "             <xsl:text>?></xsl:text>                                                                                         \n" +
                        "          </SPAN>                                                                                         \n" +
                        "       </DIV>                                                                                         \n" +
                        "    </xsl:template>                                                                                         \n" +
                        "                                                                                          \n" +
                        "    <xsl:template match=\"@*\">                                                                                         \n" +
                        "       <SPAN>                                                                                         \n" +
                        "          <xsl:attribute name=\"class\">                                                                                         \n" +
                        "             <xsl:if test=\"xsl:*/@*\">                                                                                         \n" +
                        "               <xsl:text>x</xsl:text>                                                                                         \n" +
                        "             </xsl:if>                                                                                         \n" +
                        "             <xsl:text>t</xsl:text>                                                                                         \n" +
                        "          </xsl:attribute>                                                                                         \n" +
                        "          <xsl:value-of select=\"name(.)\"/>                                                                                         \n" +
                        "       </SPAN>                                                                                         \n" +
                        "       <SPAN class=\"m\">=\"</SPAN>                                                                                         \n" +
                        "       <B>                                                                                         \n" +
                        "          <xsl:value-of select=\".\"/>                                                                                         \n" +
                        "       </B>                                                                                         \n" +
                        "       <SPAN class=\"m\">\"</SPAN>                                                                                         \n" +
                        "    </xsl:template>                                                                                         \n" +
                        "                                                                                          \n" +
                        "    <xsl:template match=\"text()\">                                                                                         \n" +
                        "       <DIV class=\"e\">                                                                                         \n" +
                        "          <SPAN class=\"b\"> </SPAN>                                                                                         \n" +
                        "          <SPAN class=\"tx\">                                                                                         \n" +
                        "             <xsl:value-of select=\".\"/>                                                                                         \n" +
                        "          </SPAN>                                                                                         \n" +
                        "       </DIV>                                                                                         \n" +
                        "    </xsl:template>                                                                                         \n" +
                        "                                                                                          \n" +
                        "    <xsl:template match=\"comment()\">                                                                                         \n" +
                        "       <DIV class=\"k\">                                                                                         \n" +
                        "          <SPAN>                                                                                         \n" +
                        "             <A STYLE=\"visibility:hidden\" class=\"b\" onclick=\"return false\"                                                                                          \n" +
                        "                onfocus=\"h()\">-</A>                                                                                         \n" +
                        "             <SPAN class=\"m\">                                                                                         \n" +
                        "                <xsl:text>&lt;!--</xsl:text>                                                                                         \n" +
                        "             </SPAN>                                                                                         \n" +
                        "          </SPAN>                                                                                         \n" +
                        "          <SPAN class=\"ci\" id=\"clean\">                                                                                         \n" +
                        "             <PRE>                                                                                         \n" +
                        "                <xsl:value-of select=\".\"/>                                                                                         \n" +
                        "             </PRE>                                                                                         \n" +
                        "          </SPAN>                                                                                         \n" +
                        "          <SPAN class=\"b\">                                                                                         \n" +
                        "             <xsl:call-template name=\"entity-ref\">                                                                                         \n" +
                        "                <xsl:with-param name=\"name\">nbsp</xsl:with-param>                                                                                         \n" +
                        "             </xsl:call-template>                                                                                         \n" +
                        "          </SPAN>                                                                                         \n" +
                        "          <SPAN class=\"m\">                                                                                         \n" +
                        "             <xsl:text>--></xsl:text>                                                                                         \n" +
                        "          </SPAN>                                                                                         \n" +
                        "          <SCRIPT>f(clean);</SCRIPT>                                                                                         \n" +
                        "       </DIV>                                                                                         \n" +
                        "    </xsl:template>                                                                                         \n" +
                        "                                                                                          \n" +
                        "    <xsl:template match=\"*\">                                                                                         \n" +
                        "       <DIV class=\"e\">                                                                                         \n" +
                        "          <DIV STYLE=\"margin-left:1em;text-indent:-2em\">                                                                                         \n" +
                        "             <SPAN class=\"b\">                                                                                         \n" +
                        "                <xsl:call-template name=\"entity-ref\">                                                                                         \n" +
                        "                   <xsl:with-param name=\"name\">nbsp</xsl:with-param>                                                                                         \n" +
                        "                </xsl:call-template>                                                                                         \n" +
                        "             </SPAN>                                                                                         \n" +
                        "             <SPAN class=\"m\">&lt;</SPAN>                                                                                         \n" +
                        "             <SPAN>                                                                                         \n" +
                        "                <xsl:attribute name=\"class\">                                                                                         \n" +
                        "                   <xsl:if test=\"xsl:*\">                                                                                         \n" +
                        "                      <xsl:text>x</xsl:text>                                                                                         \n" +
                        "                   </xsl:if>                                                                                         \n" +
                        "                   <xsl:text>t</xsl:text>                                                                                         \n" +
                        "                </xsl:attribute>                                                                                         \n" +
                        "                <xsl:value-of select=\"name(.)\"/>                                                                                         \n" +
                        "                <xsl:if test=\"@*\">                                                                                         \n" +
                        "                   <xsl:text> </xsl:text>                                                                                         \n" +
                        "                </xsl:if>                                                                                         \n" +
                        "             </SPAN>                                                                                         \n" +
                        "             <xsl:apply-templates select=\"@*\"/>                                                                                         \n" +
                        "             <SPAN class=\"m\">                                                                                         \n" +
                        "                <xsl:text>/></xsl:text>                                                                                         \n" +
                        "             </SPAN>                                                                                         \n" +
                        "          </DIV>                                                                                         \n" +
                        "       </DIV>                                                                                         \n" +
                        "    </xsl:template>                                                                                         \n" +
                        "                                                                                          \n" +
                        "    <xsl:template match=\"*[node()]\">                                                                                         \n" +
                        "       <DIV class=\"e\">                                                                                         \n" +
                        "          <DIV class=\"c\">                                                                                         \n" +
                        "             <A class=\"b\" href=\"#\" onclick=\"return false\" onfocus=\"h()\">-</A>                                                                                         \n" +
                        "             <SPAN class=\"m\">&lt;</SPAN>                                                                                         \n" +
                        "             <SPAN>                                                                                         \n" +
                        "                <xsl:attribute name=\"class\">                                                                                         \n" +
                        "                   <xsl:if test=\"xsl:*\">                                                                                         \n" +
                        "                      <xsl:text>x</xsl:text>                                                                                         \n" +
                        "                   </xsl:if>                                                                                         \n" +
                        "                   <xsl:text>t</xsl:text>                                                                                         \n" +
                        "                </xsl:attribute>                                                                                         \n" +
                        "                <xsl:value-of select=\"name(.)\"/>                                                                                         \n" +
                        "                <xsl:if test=\"@*\">                                                                                         \n" +
                        "                   <xsl:text> </xsl:text>                                                                                         \n" +
                        "                </xsl:if>                                                                                         \n" +
                        "             </SPAN>                                                                                         \n" +
                        "             <xsl:apply-templates select=\"@*\"/>                                                                                         \n" +
                        "             <SPAN class=\"m\">                                                                                         \n" +
                        "                <xsl:text>></xsl:text>                                                                                         \n" +
                        "             </SPAN>                                                                                         \n" +
                        "          </DIV>                                                                                         \n" +
                        "          <DIV>                                                                                         \n" +
                        "             <xsl:apply-templates/>                                                                                         \n" +
                        "             <DIV>                                                                                         \n" +
                        "                <SPAN class=\"b\">                                                                                         \n" +
                        "                   <xsl:call-template name=\"entity-ref\">                                                                                         \n" +
                        "                      <xsl:with-param name=\"name\">nbsp</xsl:with-param>                                                                                         \n" +
                        "                   </xsl:call-template>                                                                                         \n" +
                        "                </SPAN>                                                                                         \n" +
                        "                <SPAN class=\"m\">                                                                                         \n" +
                        "                   <xsl:text>&lt;/</xsl:text>                                                                                         \n" +
                        "                </SPAN>                                                                                         \n" +
                        "                <SPAN>                                                                                         \n" +
                        "                   <xsl:attribute name=\"class\">                                                                                         \n" +
                        "                      <xsl:if test=\"xsl:*\">                                                                                         \n" +
                        "                         <xsl:text>x</xsl:text>                                                                                         \n" +
                        "                      </xsl:if>                                                                                         \n" +
                        "                      <xsl:text>t</xsl:text>                                                                                         \n" +
                        "                   </xsl:attribute>                                                                                         \n" +
                        "                   <xsl:value-of select=\"name(.)\"/>                                                                                         \n" +
                        "                </SPAN>                                                                                         \n" +
                        "                <SPAN class=\"m\">                                                                                         \n" +
                        "                   <xsl:text>></xsl:text>                                                                                         \n" +
                        "                </SPAN>                                                                                         \n" +
                        "             </DIV>                                                                                         \n" +
                        "          </DIV>                                                                                         \n" +
                        "       </DIV>                                                                                         \n" +
                        "    </xsl:template>                                                                                         \n" +
                        "                                                                                          \n" +
                        "    <xsl:template match=\"*[text() and not (comment() or processing-instruction())]\">                                                                                         \n" +
                        "       <DIV class=\"e\">                                                                                         \n" +
                        "          <DIV STYLE=\"margin-left:1em;text-indent:-2em\">                                                                                         \n" +
                        "             <SPAN class=\"b\">                                                                                         \n" +
                        "                <xsl:call-template name=\"entity-ref\">                                                                                         \n" +
                        "                   <xsl:with-param name=\"name\">nbsp</xsl:with-param>                                                                                         \n" +
                        "                </xsl:call-template>                                                                                         \n" +
                        "             </SPAN>                                                                                         \n" +
                        "             <SPAN class=\"m\">                                                                                         \n" +
                        "                <xsl:text>&lt;</xsl:text>                                                                                         \n" +
                        "             </SPAN>                                                                                         \n" +
                        "             <SPAN>                                                                                         \n" +
                        "                <xsl:attribute name=\"class\">                                                                                         \n" +
                        "                   <xsl:if test=\"xsl:*\">                                                                                         \n" +
                        "                      <xsl:text>x</xsl:text>                                                                                         \n" +
                        "                   </xsl:if>                                                                                         \n" +
                        "                   <xsl:text>t</xsl:text>                                                                                         \n" +
                        "                </xsl:attribute>                                                                                         \n" +
                        "                <xsl:value-of select=\"name(.)\"/>                                                                                         \n" +
                        "                <xsl:if test=\"@*\">                                                                                         \n" +
                        "                   <xsl:text> </xsl:text>                                                                                         \n" +
                        "                </xsl:if>                                                                                         \n" +
                        "             </SPAN>                                                                                         \n" +
                        "             <xsl:apply-templates select=\"@*\"/>                                                                                         \n" +
                        "             <SPAN class=\"m\">                                                                                         \n" +
                        "                <xsl:text>></xsl:text>                                                                                         \n" +
                        "             </SPAN>                                                                                         \n" +
                        "             <SPAN class=\"tx\">                                                                                         \n" +
                        "                <xsl:value-of select=\".\"/>                                                                                         \n" +
                        "             </SPAN>                                                                                         \n" +
                        "             <SPAN class=\"m\">&lt;/</SPAN>                                                                                         \n" +
                        "             <SPAN>                                                                                         \n" +
                        "                <xsl:attribute name=\"class\">                                                                                         \n" +
                        "                   <xsl:if test=\"xsl:*\">                                                                                         \n" +
                        "                      <xsl:text>x</xsl:text>                                                                                         \n" +
                        "                   </xsl:if>                                                                                         \n" +
                        "                   <xsl:text>t</xsl:text>                                                                                         \n" +
                        "                </xsl:attribute>                                                                                         \n" +
                        "                <xsl:value-of select=\"name(.)\"/>                                                                                         \n" +
                        "             </SPAN>                                                                                         \n" +
                        "             <SPAN class=\"m\">                                                                                         \n" +
                        "                <xsl:text>></xsl:text>                                                                                         \n" +
                        "             </SPAN>                                                                                         \n" +
                        "          </DIV>                                                                                         \n" +
                        "       </DIV>                                                                                         \n" +
                        "    </xsl:template>                                                                                         \n" +
                        "                                                                                          \n" +
                        "    <xsl:template match=\"*[*]\" priority=\"20\">                                                                                         \n" +
                        "       <DIV class=\"e\">                                                                                         \n" +
                        "          <DIV STYLE=\"margin-left:1em;text-indent:-2em\" class=\"c\">                                                                                         \n" +
                        "             <A class=\"b\" href=\"#\" onclick=\"return false\" onfocus=\"h()\">-</A>                                                                                         \n" +
                        "             <SPAN class=\"m\">&lt;</SPAN>                                                                                         \n" +
                        "             <SPAN>                                                                                         \n" +
                        "                <xsl:attribute name=\"class\">                                                                                         \n" +
                        "                   <xsl:if test=\"xsl:*\">                                                                                         \n" +
                        "                      <xsl:text>x</xsl:text>                                                                                         \n" +
                        "                   </xsl:if>                                                                                         \n" +
                        "                   <xsl:text>t</xsl:text>                                                                                         \n" +
                        "                </xsl:attribute>                                                                                         \n" +
                        "                <xsl:value-of select=\"name(.)\"/>                                                                                         \n" +
                        "                <xsl:if test=\"@*\">                                                                                         \n" +
                        "                   <xsl:text> </xsl:text>                                                                                         \n" +
                        "                </xsl:if>                                                                                         \n" +
                        "             </SPAN>                                                                                         \n" +
                        "             <xsl:apply-templates select=\"@*\"/>                                                                                         \n" +
                        "             <SPAN class=\"m\">                                                                                         \n" +
                        "                <xsl:text>></xsl:text>                                                                                         \n" +
                        "             </SPAN>                                                                                         \n" +
                        "          </DIV>                                                                                         \n" +
                        "          <DIV>                                                                                         \n" +
                        "             <xsl:apply-templates/>                                                                                         \n" +
                        "             <DIV>                                                                                         \n" +
                        "                <SPAN class=\"b\">                                                                                         \n" +
                        "                   <xsl:call-template name=\"entity-ref\">                                                                                         \n" +
                        "                      <xsl:with-param name=\"name\">nbsp</xsl:with-param>                                                                                         \n" +
                        "                   </xsl:call-template>                                                                                         \n" +
                        "                </SPAN>                                                                                         \n" +
                        "                <SPAN class=\"m\">                                                                                         \n" +
                        "                   <xsl:text>&lt;/</xsl:text>                                                                                         \n" +
                        "                </SPAN>                                                                                         \n" +
                        "                <SPAN>                                                                                         \n" +
                        "                   <xsl:attribute name=\"class\">                                                                                         \n" +
                        "                      <xsl:if test=\"xsl:*\">                                                                                         \n" +
                        "                         <xsl:text>x</xsl:text>                                                                                         \n" +
                        "                      </xsl:if>                                                                                         \n" +
                        "                      <xsl:text>t</xsl:text>                                                                                         \n" +
                        "                   </xsl:attribute>                                                                                         \n" +
                        "                   <xsl:value-of select=\"name(.)\"/>                                                                                         \n" +
                        "                </SPAN>                                                                                         \n" +
                        "                <SPAN class=\"m\">                                                                                         \n" +
                        "                   <xsl:text>></xsl:text>                                                                                         \n" +
                        "                </SPAN>                                                                                         \n" +
                        "             </DIV>                                                                                         \n" +
                        "          </DIV>                                                                                         \n" +
                        "       </DIV>                                                                                         \n" +
                        "    </xsl:template>                                                                                         \n" +
                        "                                                                                          \n" +
                        "    <xsl:template name=\"entity-ref\">                                                                                         \n" +
                        "       <xsl:param name=\"name\"/>                                                                                         \n" +
                        "       <xsl:text disable-output-escaping=\"yes\">&amp;</xsl:text>                                                                                         \n" +
                        "       <xsl:value-of select=\"$name\"/>                                                                                         \n" +
                        "       <xsl:text>;</xsl:text>                                                                                         \n" +
                        "    </xsl:template>                                                                                         \n" +
                        "                                                                                          \n" +
                        " </xsl:stylesheet>                                                                                         \n";
                #endregion
            }
        }
    }
}
