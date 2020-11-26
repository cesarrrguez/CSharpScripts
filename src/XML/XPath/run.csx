#load "utils.csx"

using System.Xml;

var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "document.xml");

var xmlDocument = new XmlDocument();
xmlDocument.Load(path);

XmlNodeList itemNodes = xmlDocument.SelectNodes("//wikimedia//projects//project");

foreach (XmlNode itemNode in itemNodes)
{
    WriteLine($"{itemNode.Attributes["name"].Value}, {itemNode.Attributes["launch"].Value}");
}
