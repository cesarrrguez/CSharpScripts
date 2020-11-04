// XmlReader
// -----------------------
// * Faster
// * Less memory consuming
// -----------------------

#load "utils.csx"

using System.Xml;

var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "document.xml");

var xmlReader = XmlReader.Create(path);

while (xmlReader.Read())
{
    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "project"))
    {
        if (xmlReader.HasAttributes)
        {
            WriteLine($"\n{xmlReader.GetAttribute("name")}, {xmlReader.GetAttribute("launch")}");
        }
    }
    else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "edition"))
    {
        if (xmlReader.HasAttributes)
        {
            WriteLine(xmlReader.GetAttribute("language"));
        }
    }
}
