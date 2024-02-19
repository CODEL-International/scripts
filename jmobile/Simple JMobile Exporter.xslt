<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">


<xsl:template match="/">
  <html>
  <body>
    <h2>Tags</h2>
    <table border="1">
      <tr bgcolor="#9acd32">
        <th>Name</th>
	<th>Type</th>
        <th>Modbus Address</th>
      </tr>
      <xsl:for-each select="tags/tag">
        <tr>
          <td><xsl:value-of select="name"/></td>
	  <td><xsl:value-of select="resourceLocator/data_type"/></td>
          <td><xsl:value-of select="resourceLocator/offset - 400000"/></td>
        </tr>
      </xsl:for-each>
    </table>
  </body>
  </html>
</xsl:template>

</xsl:stylesheet>

