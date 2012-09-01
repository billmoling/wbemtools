<?xml version="1.0" encoding="ISO-8859-1"?>
<!-- ================================================================================ -->
<!-- Amend, distribute, spindle and mutilate as desired, but don't remove this header -->
<!-- A simple XML Documentation to basic HTML transformation stylesheet -->
<!-- (c)2005 by Emma Burrows -->

<!-- Seriously modified by Rusty Howell -->

<!-- ================================================================================ -->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<!-- DOCUMENT TEMPLATE -->
<!-- Format the whole document as a valid HTML document -->
<xsl:template match="/">
<HTML>
<head>
	<title>OmcWbem</title>
	<link rel="stylesheet" href="style.css" type="text/css" media="screen"/>
</head>
  <BODY>
    <xsl:apply-templates select="//assembly"/>
  </BODY>
</HTML>
</xsl:template>

<!-- ASSEMBLY TEMPLATE -->
<!-- For each Assembly, display its name and then its member types -->
<xsl:template match="assembly">
	<xsl:variable name="AssemblyName" select="name"/>
		<H2><xsl:value-of select="$AssemblyName"/></H2>
  <xsl:apply-templates select="//member[contains(@name,'T:')]"/>
</xsl:template>

<!-- TYPE TEMPLATE -->
<!-- Loop through member types and display their properties and methods -->

<xsl:template match="//member[contains(@name,'T:')]">
	<!-- Two variables to make code easier to read -->
	<!-- A variable for the name of this type  
	<member name="T:Omc.Wbem.WbemClient">
	-->
	
	<xsl:variable name="tmp" select="substring-after(@name, 'T:')"/>
	<!--  Omc.Wbem.WbemClient  -->
	<xsl:variable name="NamespaceName" select="substring-after($tmp, '.')"/>
	<!--  Wbem.WbemClient  -->
	<xsl:variable name="ClassName" select="substring-after($NamespaceName, '.')"/>
	<!--  <member name="T:Omc.Wbem.WbemClient">  -->

	<!-- Get the type's fully qualified name without the T: prefix -->
	<xsl:variable name="FullMemberName"
				 select="substring-after(@name, ':')"/>
	
	<hr/>
	<!-- Display the type's name and information -->
	<div class="classTitle"><xsl:value-of select="$ClassName"/> Members</div>
	<xsl:apply-templates/>

<table style="vertical-align:top">
	<tr class="secHeader">
		<td style="width:50px">Type</td>
		<td style="width:300px;">Name</td>
		<td style="width:500px;">Summary</td>
	</tr>

<!-- *************************************************** -->
	<!-- If this type has public FIELDS, display them -->
	<xsl:if test="//member[contains(@name,concat('F:',$FullMemberName))]">   
		<xsl:for-each select="//member[contains(@name,concat('F:',$FullMemberName))]">	  
		<tr>
			<td style="vertical-align:top;text-align:center"><img src="images/Property.PNG"/></td>
			<td style="vertical-align:top;text-align:left">
			<xsl:value-of select="substring-after(@name, concat('F:',$FullMemberName,'.'))"/></td>
			<td><xsl:apply-templates/></td>
		</tr>
		</xsl:for-each>
	</xsl:if>

<!-- *************************************************** -->
	<!-- If this type has PROPERTIES, display them  -->
	<xsl:if test="//member[contains(@name,concat('P:',$FullMemberName))]">
		<xsl:for-each select="//member[contains(@name,concat('P:',$FullMemberName))]">
		<xsl:variable name="MemberName" select="substring-after(@name, concat($ClassName,'.'))"/>
		<tr>
		<td style="vertical-align:top;text-align:center"><img src="images/Property.PNG"/></td>
			<td style="vertical-align:top;text-align:left">
			<xsl:value-of select="$MemberName"/>
			</td>
			<td><xsl:apply-templates/></td>
		</tr>
		</xsl:for-each>
	</xsl:if>
   
<!-- *************************************************** -->
<!-- If this type has METHODS, display them  -->
<xsl:if test="//member[contains(@name,concat('M:',$FullMemberName))]">
	<xsl:for-each select="//member[contains(@name,concat('M:',$FullMemberName))]">
		<xsl:variable name="MemberName" select="substring-after(substring-before(@name, '('), concat($ClassName,'.'))"/>
		
		<tr>
		<td style="vertical-align:top;text-align:center"><img src="images/Method.PNG"/></td>
			<td style="vertical-align:top;text-align:left">
			<xsl:choose>
			
				<xsl:when test="contains(@name, '#ctor')">
					Constructor: 
					<xsl:value-of select="$MemberName"/>
					<xsl:value-of select="substring-after(@name, '#ctor')"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:value-of select="substring-after(@name, concat('M:',$FullMemberName,'.'))"/>
				</xsl:otherwise>
			
			</xsl:choose>
			</td>
			<td><xsl:apply-templates select="summary"/></td>
		</tr>
	</xsl:for-each>
</xsl:if>

<!-- *************************************************** -->
</table>
</xsl:template>

<!-- *************************************************** -->
  <!-- OTHER TEMPLATES -->
  <!-- Templates for other tags -->
  <xsl:template match="c">
    <CODE>
      <xsl:apply-templates />
    </CODE>
  </xsl:template>

  <xsl:template match="code">
    <PRE>
      <xsl:apply-templates />
    </PRE>
  </xsl:template>

  <xsl:template match="example">
    <P>
      <STRONG>Example: </STRONG>
      <xsl:apply-templates />
    </P>
  </xsl:template>

  <xsl:template match="exception">
    <P>
      <STRONG>
        <xsl:value-of select="substring-after(@cref,'T:')"/>:
      </STRONG>
      <xsl:apply-templates />
    </P>
  </xsl:template>

  <xsl:template match="include">
    <A HREF="{@file}">External file</A>
  </xsl:template>

  <xsl:template match="para">
    <P>
      <xsl:apply-templates />
    </P>
  </xsl:template>

  <xsl:template match="param">
    <br/>
      <STRONG>
        <xsl:value-of select="@name"/>:
      </STRONG>
      <xsl:apply-templates />
  </xsl:template>

  <xsl:template match="paramref">
    <EM>
      <xsl:value-of select="@name" />
    </EM>
  </xsl:template>

  <xsl:template match="permission">
    <P>
      <STRONG>Permission: </STRONG>
      <EM>
        <xsl:value-of select="@cref" />
      </EM>
      <xsl:apply-templates />
    </P>
  </xsl:template>

  <xsl:template match="remarks">
    <P>
      <xsl:apply-templates />
    </P>
  </xsl:template>

  <xsl:template match="returns">
    <br/>
      <STRONG>Return Value: </STRONG>
      <xsl:apply-templates />
  </xsl:template>

  <xsl:template match="see">
    <EM>
      See: <xsl:value-of select="@cref" />
    </EM>
  </xsl:template>

  <xsl:template match="seealso">
    <EM>
      See also: <xsl:value-of select="@cref" />
    </EM>
  </xsl:template>

  <xsl:template match="summary">
      <xsl:apply-templates />
  </xsl:template>

  <xsl:template match="list">
    <xsl:choose>
      <xsl:when test="@type='bullet'">
        <UL>
          <xsl:for-each select="listheader">
            <LI>
              <strong>
                <xsl:value-of select="term"/>:
              </strong>
              <xsl:value-of select="definition"/>
            </LI>
          </xsl:for-each>
          <xsl:for-each select="list">
            <LI>
              <strong>
                <xsl:value-of select="term"/>:
              </strong>
              <xsl:value-of select="definition"/>
            </LI>
          </xsl:for-each>
        </UL>
      </xsl:when>
      <xsl:when test="@type='number'">
        <OL>
          <xsl:for-each select="listheader">
            <LI>
              <strong>
                <xsl:value-of select="term"/>:
              </strong>
              <xsl:value-of select="definition"/>
            </LI>
          </xsl:for-each>
          <xsl:for-each select="list">
            <LI>
              <strong>
                <xsl:value-of select="term"/>:
              </strong>
              <xsl:value-of select="definition"/>
            </LI>
          </xsl:for-each>
        </OL>
      </xsl:when>
      <xsl:when test="@type='table'">
        <TABLE>
          <xsl:for-each select="listheader">
            <TH>
              <TD>
                <xsl:value-of select="term"/>
              </TD>
              <TD>
                <xsl:value-of select="definition"/>
              </TD>
            </TH>
          </xsl:for-each>
          <xsl:for-each select="list">
            <TR>
              <TD>
                <strong>
                  <xsl:value-of select="term"/>:
                </strong>
              </TD>
              <TD>
                <xsl:value-of select="definition"/>
              </TD>
            </TR>
          </xsl:for-each>
        </TABLE>
      </xsl:when>
    </xsl:choose>
  </xsl:template>

</xsl:stylesheet>