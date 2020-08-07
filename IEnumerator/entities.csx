using System.Collections;

public class Course
{
    private readonly Student[] _students;

    public Course()
    {
        _students = new Student[] {
            new Student("James", 9.7),
            new Student("Olivia", 6.8)
        };
    }

    public IEnumerator GetEnumerator()
    {
        return _students.GetEnumerator();
    }
}

public class Student
{
    public string Name { get; private set; }
    public double Average { get; private set; }

    public Student(string name, double average)
    {
        Name = name;
        Average = average;
    }

    public override string ToString() => $"Student. Name: {Name}, Average: {Average}";
}
