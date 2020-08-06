using System.Xml.Linq;

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

    Console.WriteLine(studentsXML);

    // Nodes
    Console.WriteLine("\nNodes:");
    Console.WriteLine(separator);
    foreach (var node in studentsXML.Nodes())
        Console.WriteLine(node.ToString());

    // Elements
    Console.WriteLine("\nElements:");
    Console.WriteLine(separator);
    foreach (var element in studentsXML.Elements())
        Console.WriteLine(element.Name + "=" + element.Value);

    // First node
    Console.WriteLine("\nFirst node:");
    Console.WriteLine(separator);
    Console.WriteLine(studentsXML.FirstNode);

    // First node parent
    Console.WriteLine("\nFirst node parent:");
    Console.WriteLine(separator);
    Console.WriteLine(studentsXML.FirstNode.Parent.Name);

    // Last node
    Console.WriteLine("\nLast node:");
    Console.WriteLine(separator);
    Console.WriteLine(studentsXML.LastNode);

    // Last node parent
    Console.WriteLine("\nLast node parent:");
    Console.WriteLine(separator);
    Console.WriteLine(studentsXML.LastNode.Parent.Name);

    // Query 1
    Console.WriteLine("\nQuery 1:");
    Console.WriteLine(separator);
    var query_1 = from student in studentsXML.Elements()
                  where student.Elements().Any(course => course.Value == "POO")
                  select student.Value;

    foreach (var item in query_1)
        Console.WriteLine(item);

    // Query 2
    Console.WriteLine("\nQuery 2:");
    Console.WriteLine(separator);
    var query_2 = from student in studentsXML.Elements()
                  where student.Elements().Any(course => course.Value == "POO")
                  select student.Name;

    foreach (var item in query_2)
        Console.WriteLine(item.ToString());

    // Query 3
    Console.WriteLine("\nQuery 3:");
    Console.WriteLine(separator);
    var query_3 = from student in studentsXML.Elements()
                  from course in student.Elements()
                  where course.Name == "Course"
                  select course.Value;

    foreach (var item in query_3)
        Console.WriteLine(item);

    // Count
    Console.WriteLine("\nCount:");
    Console.WriteLine(separator);
    var n = studentsXML.Elements("James").Count();
    Console.WriteLine(n);

    // Element
    Console.WriteLine("\nElement:");
    Console.WriteLine(separator);
    var firstElement = studentsXML.Element("James").Element("Course").Value;
    Console.WriteLine(firstElement);

    // Next node
    Console.WriteLine("\nNext node:");
    Console.WriteLine(separator);
    var nextNode = studentsXML.FirstNode.NextNode;
    Console.WriteLine(nextNode);

    // New element
    Console.WriteLine("\nNew element:");
    Console.WriteLine(separator);
    studentsXML.SetElementValue("John", "");
    Console.WriteLine(studentsXML);

    // Edit element
    Console.WriteLine("\nEdit element:");
    Console.WriteLine(separator);
    studentsXML.SetElementValue("John", "Something");
    Console.WriteLine(studentsXML);

    // Add element after
    Console.WriteLine("\nAdd element after:");
    Console.WriteLine(separator);
    studentsXML.FirstNode.AddAfterSelf(new XElement("Isabella"));
    Console.WriteLine(studentsXML);

    // Add element before
    Console.WriteLine("\nAdd element before:");
    Console.WriteLine(separator);
    studentsXML.FirstNode.AddBeforeSelf(new XElement("Kevin"));
    Console.WriteLine(studentsXML);

    // Set value
    Console.WriteLine("\nSet value:");
    Console.WriteLine(separator);
    var averageJames = studentsXML.Element("James").Element("Average");
    averageJames.SetValue(8);
    Console.WriteLine(studentsXML);

    // Set value
    Console.WriteLine("\nGet value:");
    Console.WriteLine(separator);
    var averageJamesValue = averageJames.Value;
    Console.WriteLine(averageJamesValue);
}

public void ParseXMLFileDocument()
{
    var separator = new string(Enumerable.Repeat('-', 67).ToArray());

    var students = XDocument.Load("XML/Documents/document_5.xml");

    Console.WriteLine(students);

    // Remove descendants
    Console.WriteLine("\nRemove descendants:");
    Console.WriteLine(separator);
    students.Descendants("Course").Remove();
    Console.WriteLine(students);

    // Get averages
    Console.WriteLine("\nGet averages:");
    Console.WriteLine(separator);
    var averages = from a in students.Descendants("Average")
                   select a.Value;

    foreach (var average in averages)
        Console.WriteLine(average);
}
