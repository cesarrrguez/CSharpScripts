using System.Xml.Linq;

public class XmlParser
{
    public string DocumentsPath { get; }

    public XmlParser(string documentsPath)
    {
        DocumentsPath = documentsPath;
    }

    public void ParseXMLDocument()
    {
        var separator = new string(Enumerable.Repeat('-', 67).ToArray());

        var studentsXML = new XElement("Students",
            new XElement("James", new XAttribute("ID", "10100"),
                new XElement("Course", "POO"),
                new XElement("Average", "10")
            ), // End of James
            new XElement("Olivia", new XAttribute("ID", "25350"),
                new XElement("Course", "UML"),
                new XElement("Average", "9.5")
            ) // End of Olivia
        ); // End of students

        WriteLine(studentsXML);

        // Nodes
        WriteLine("\nNodes:");
        WriteLine(separator);
        foreach (var node in studentsXML.Nodes())
            WriteLine(node.ToString());

        // Elements
        WriteLine("\nElements:");
        WriteLine(separator);
        foreach (var element in studentsXML.Elements())
            WriteLine(element.Name + "=" + element.Value);

        // First node
        WriteLine("\nFirst node:");
        WriteLine(separator);
        WriteLine(studentsXML.FirstNode);

        // First node parent
        WriteLine("\nFirst node parent:");
        WriteLine(separator);
        WriteLine(studentsXML.FirstNode.Parent.Name);

        // Last node
        WriteLine("\nLast node:");
        WriteLine(separator);
        WriteLine(studentsXML.LastNode);

        // Last node parent
        WriteLine("\nLast node parent:");
        WriteLine(separator);
        WriteLine(studentsXML.LastNode.Parent.Name);

        // Query 1
        WriteLine("\nQuery 1:");
        WriteLine(separator);
        var query_1 = from student in studentsXML.Elements()
                      where student.Elements().Any(course => course.Value == "POO")
                      select student.Value;

        foreach (var item in query_1)
            WriteLine(item);

        // Query 2
        WriteLine("\nQuery 2:");
        WriteLine(separator);
        var query_2 = from student in studentsXML.Elements()
                      where student.Elements().Any(course => course.Value == "POO")
                      select student.Name;

        foreach (var item in query_2)
            WriteLine(item.ToString());

        // Query 3
        WriteLine("\nQuery 3:");
        WriteLine(separator);
        var query_3 = from student in studentsXML.Elements()
                      from course in student.Elements()
                      where course.Name == "Course"
                      select course.Value;

        foreach (var item in query_3)
            WriteLine(item);

        // Count
        WriteLine("\nCount:");
        WriteLine(separator);
        var n = studentsXML.Elements("James").Count();
        WriteLine(n);

        // Element
        WriteLine("\nElement:");
        WriteLine(separator);
        var firstElement = studentsXML.Element("James").Element("Course").Value;
        WriteLine(firstElement);

        // Next node
        WriteLine("\nNext node:");
        WriteLine(separator);
        var nextNode = studentsXML.FirstNode.NextNode;
        WriteLine(nextNode);

        // New element
        WriteLine("\nNew element:");
        WriteLine(separator);
        studentsXML.SetElementValue("John", "");
        WriteLine(studentsXML);

        // Edit element
        WriteLine("\nEdit element:");
        WriteLine(separator);
        studentsXML.SetElementValue("John", "Something");
        WriteLine(studentsXML);

        // Add element after
        WriteLine("\nAdd element after:");
        WriteLine(separator);
        studentsXML.FirstNode.AddAfterSelf(new XElement("Isabella"));
        WriteLine(studentsXML);

        // Add element before
        WriteLine("\nAdd element before:");
        WriteLine(separator);
        studentsXML.FirstNode.AddBeforeSelf(new XElement("Kevin"));
        WriteLine(studentsXML);

        // Set value
        WriteLine("\nSet value:");
        WriteLine(separator);
        var averageJames = studentsXML.Element("James").Element("Average");
        averageJames.SetValue(8);
        WriteLine(studentsXML);

        // Set value
        WriteLine("\nGet value:");
        WriteLine(separator);
        var averageJamesValue = averageJames.Value;
        WriteLine(averageJamesValue);
    }

    public void ParseXMLFileDocument()
    {
        var separator = new string(Enumerable.Repeat('-', 67).ToArray());

        var students = XDocument.Load(Path.Combine(DocumentsPath, "document_5.xml"));

        WriteLine(students);

        // Remove descendants
        WriteLine("\nRemove descendants:");
        WriteLine(separator);
        students.Descendants("Course").Remove();
        WriteLine(students);

        // Get averages
        WriteLine("\nGet averages:");
        WriteLine(separator);
        var averages = from a in students.Descendants("Average")
                       select a.Value;

        foreach (var average in averages)
            WriteLine(average);
    }
}
