
#load "utils.csx"

using System.Xml;

var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "document.xml");

var xmlDocument = new XmlDocument();
xmlDocument.Load(path);

foreach (XmlNode xmlNode in xmlDocument.DocumentElement.ChildNodes[0].ChildNodes)
{
    WriteLine($"\n{xmlNode.Attributes["name"].Value}, {xmlNode.Attributes["launch"].Value}");

    foreach (XmlNode xmlNodeItem in xmlNode.FirstChild.ChildNodes)
    {
        WriteLine(xmlNodeItem.Attributes["language"].Value);

        WriteLine($"\tInner Text: {xmlNodeItem.InnerText}");
        WriteLine($"\tInner Xml: {xmlNodeItem.InnerXml}");
        WriteLine($"\tOuter Xml: {xmlNodeItem.OuterXml}");
    }
}
