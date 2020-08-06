#load "xmlBuilder.csx"
#load "xmlParser.csx"

var section = 0;
var separator = new string(Enumerable.Repeat('-', 67).ToArray());
Action<string> beginSection = title => Console.WriteLine($"\n{++section}) {title}:\n{separator}");

beginSection("Simple XML document");
BuildSimpleXMLDocument();

beginSection("Functional construction XML document");
BuildFunctionalConstructionXMLDocument();

beginSection("Complete XML document");
BuildCompleteXMLDocument();

beginSection("XML document from array data");
BuildXMLDocumentFromArrayData();

beginSection("XML document from string data");
BuildXMLDocumentFromStringData();

beginSection("Parse XML document");
ParseXMLDocument();

beginSection("Parse XML file document");
ParseXMLFileDocument();
