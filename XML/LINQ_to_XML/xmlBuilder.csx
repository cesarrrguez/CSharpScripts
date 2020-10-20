using System.Xml.Linq;

public class XMLBuilder
{
    public string DocumentsPath { get; }

    public XMLBuilder(string documentsPath)
    {
        DocumentsPath = documentsPath;
    }

    public void BuildSimpleXMLDocument()
    {
        var rootXML = new XElement("root");
        var element1 = new XElement("Element1");
        element1.Add(new XAttribute("attribute", "value"));
        element1.Add(new XElement("nested", "content"));
        rootXML.Add(element1);

        WriteLine(rootXML);
        rootXML.Save(Path.Combine(DocumentsPath, "document_1.xml"));
    }

    public void BuildFunctionalConstructionXMLDocument()
    {
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
        studentsXML.Save(Path.Combine(DocumentsPath, "document_2.xml"));
    }

    public void BuildCompleteXMLDocument()
    {
        var documentXML = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XComment("List of students"),
            new XProcessingInstruction("xml-stylesheet", "href='styles.css' title='Compact' type='text/css'"),
            new XElement("Students",
                new XElement("James", new XAttribute("ID", "10100"),
                    new XElement("Course", "POO"),
                    new XElement("Average", "10")
                ), // End of James
                new XElement("Olivia", new XAttribute("ID", "25350"),
                    new XElement("Course", "UML"),
                    new XElement("Average", "9.5")
                ) // End of Olivia
            ) // End of students
        ); // End of document

        WriteLine(documentXML);
        documentXML.Save(Path.Combine(DocumentsPath, "document_3.xml"));
    }

    public void BuildXMLDocumentFromArrayData()
    {
        var students = new[]
        {
            new { Name = "James", Course = "POO", Average = 10 },
            new { Name = "Olivia", Course = "UML", Average = 9 }
        };

        var studentsXML = new XElement("Students",
            from s in students
            select new XElement("Student", new XAttribute("Name", s.Name),
                new XElement("Course", s.Course),
                new XElement("Average", s.Average)
            ) // End of Student
        ); // End of Students

        WriteLine(studentsXML);
        studentsXML.Save(Path.Combine(DocumentsPath, "document_4.xml"));
    }

    public void BuildXMLDocumentFromStringData()
    {
        const string students = @"<Students>
  <Student Name='James'>
    <Course>POO</Course>
    <Average>10</Average>
  </Student>
  <Student Name='Olivia'>
    <Course>UML</Course>
    <Average>9</Average>
  </Student>
</Students>";

        var studentsXML = XElement.Parse(students);

        WriteLine(studentsXML);
        studentsXML.Save(Path.Combine(DocumentsPath, "document_5.xml"));
    }
}
