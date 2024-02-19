<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">


<xsl:template match="/">
<html>
<body>
<xsl:for-each select="tags/tag">

<xsl:variable name="tempType">
	<xsl:choose>
	<xsl:when test="resourceLocator/data_type = 'unsignedShort'">u16</xsl:when>
	<xsl:when test="resourceLocator/data_type = 'float'">float</xsl:when>
	<xsl:otherwise>unknown</xsl:otherwise>
	</xsl:choose>
</xsl:variable>


      <xsl:value-of select="$tempType"/>_<xsl:value-of select="name"/>_RAM.description = nameof(<xsl:value-of select="$tempType"/>_<xsl:value-of select="name"/>_RAM);<br />
      <xsl:value-of select="$tempType"/>_<xsl:value-of select="name"/>_RAM.codelLocation = <xsl:value-of select="(resourceLocator/offset - 400000) * 2"/>;<br />
      <xsl:value-of select="$tempType"/>_<xsl:value-of select="name"/>_RAM.modbusRegister = <xsl:value-of select="resourceLocator/offset - 400000"/>;<br />
      <xsl:value-of select="$tempType"/>_<xsl:value-of select="name"/>_RAM.byteOffset = 0x001A;<br />
      <xsl:value-of select="$tempType"/>_<xsl:value-of select="name"/>_RAM.DataType = 
	<xsl:choose>
	<xsl:when test="resourceLocator/data_type = 'unsignedShort'">
	  MemoryItemType.u16;
	</xsl:when>
	<xsl:when test="resourceLocator/data_type = 'float'">
	  MemoryItemType.single;
	</xsl:when>
	<xsl:otherwise>
	  MemoryItemType.unknown;
	</xsl:otherwise>
	</xsl:choose>
	<br />

      <xsl:value-of select="$tempType"/>_<xsl:value-of select="name"/>_RAM.numBytes = 
	<xsl:choose>
	<xsl:when test="resourceLocator/data_type = 'unsignedShort'">
	  2;
	</xsl:when>
	<xsl:when test="resourceLocator/data_type = 'float'">
	  4;
	</xsl:when>
	<xsl:otherwise>
	  unknown;
	</xsl:otherwise>
	</xsl:choose>
	<br />

      <xsl:value-of select="$tempType"/>_<xsl:value-of select="name"/>_RAM.numRegisters = 
	<xsl:choose>
	<xsl:when test="resourceLocator/data_type = 'unsignedShort'">
	  2;
	</xsl:when>
	<xsl:when test="resourceLocator/data_type = 'float'">
	  4;
	</xsl:when>
	<xsl:otherwise>
	  unknown;
	</xsl:otherwise>
	</xsl:choose>
	<br />

      <xsl:value-of select="$tempType"/>_<xsl:value-of select="name"/>_RAM.multiplier = 1;<br />
      <xsl:value-of select="$tempType"/>_<xsl:value-of select="name"/>_RAM.minValue = 0;<br />
      <xsl:value-of select="$tempType"/>_<xsl:value-of select="name"/>_RAM.maxValue = 65535;<br />
      <xsl:value-of select="$tempType"/>_<xsl:value-of select="name"/>_RAM.units = "";<br />
      <xsl:value-of select="$tempType"/>_<xsl:value-of select="name"/>_RAM.currentConnectionType = Instrument_Type;<br />
      <xsl:value-of select="$tempType"/>_<xsl:value-of select="name"/>_RAM.absoluteaddress = (int)BASEADDRESS + <xsl:value-of select="$tempType"/>_<xsl:value-of select="name"/>_RAM.byteOffset;<br />

<br /><br />
</xsl:for-each>
</body>
</html>
</xsl:template>
</xsl:stylesheet>

