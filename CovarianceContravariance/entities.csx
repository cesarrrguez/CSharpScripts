public class Person
{
    public string Name { get; set; }
}

public class Teacher : Person { }

public class MailingList
{
    public void Add(IEnumerable<Person> people)
    {
        if (people == null) throw new ArgumentNullException(nameof(people));
    }
}

public class School
{
    public IEnumerable<Teacher> Teachers { get; set; }

    public School()
    {
        Teachers = new List<Teacher>();
    }

    public IEnumerable<Teacher> GetTeachers() => Teachers;
}
