<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="3.0">
	<xsl:output method="xhtml" version="1.0" encoding="UTF-8" indent="yes"
	doctype-public= "-//W3C//DTD XHTML 1.0 Strict//EN"
   doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"/>
   
	<xsl:template match="/">
		<html xmlns="http://www.w3.org/1999/xhtml">
			<head>
				<title>FAKTURA</title>
			</head>
			<body>
				<h2>Lista zakupów</h2>
				<table border="1">
					<tr>
						<th>Tytuł gry</th>
						<th>Twórcy</th>
						<th>Wydawca</th>
						<th>Cena</th>
						<th>Waluta</th>
					</tr>
				<xsl:for-each select="dokument/kolekcja/ulubione/gra">
					<xsl:sort select="tytuł"/>
					<xsl:if test="rok_produkcji>2015">
						<tr>
							<td><xsl:value-of select="tytuł"/></td>
							<td><xsl:value-of select="twórcy"/></td>
							<td><xsl:value-of select="wydawca"/></td>
							<td><xsl:value-of select="cena"/></td>
							<td><xsl:value-of select="cena/@waluta"/></td>
						</tr>
					</xsl:if>
				</xsl:for-each>
				</table>
				<table border="2">
					<tr>
						<th>Ilość zakupionych gier</th>
						<th>Cena końcowa</th>
						<th>Waluta</th>
					</tr>
					<tr>
						<td><xsl:value-of select="count(//gra)"/></td>
						<td><xsl:value-of select="sum(//gra/cena)"/></td>
						<td>PLN</td>
					</tr>
				</table>			
			</body>
		</html>	
	</xsl:template>
</xsl:stylesheet>
