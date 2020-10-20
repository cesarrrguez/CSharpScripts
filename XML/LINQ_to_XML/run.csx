#load "xmlBuilder.csx"
#load "xmlParser.csx"

int section;
var separator = new string(Enumerable.Repeat('-', 67).ToArray());
Action<string> beginSection = title => WriteLine($"\n{++section}) {title}:\n{separator}");

var documentsPath = "XML/LINQ_to_XML/Documents";

var xmlBuilder = new XMLBuilder(documentsPath);

beginSection("Simple XML document");
xmlBuilder.BuildSimpleXMLDocument();

beginSection("Functional construction XML document");
xmlBuilder.BuildFunctionalConstructionXMLDocument();

beginSection("Complete XML document");
xmlBuilder.BuildCompleteXMLDocument();

beginSection("XML document from array data");
xmlBuilder.BuildXMLDocumentFromArrayData();

beginSection("XML document from string data");
xmlBuilder.BuildXMLDocumentFromStringData();

var xmlParser = new XmlParser(documentsPath);

beginSection("Parse XML document");
xmlParser.ParseXMLDocument();

beginSection("Parse XML file document");
xmlParser.ParseXMLFileDocument();
