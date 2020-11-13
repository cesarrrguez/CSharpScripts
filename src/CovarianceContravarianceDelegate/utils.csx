#load "entities.csx"

public static class Utils
{
    public delegate Person CovarianceDelegate(Teacher teacher);

    public static Teacher GetTeacherFromTeacher(Teacher teacher)
    {
        if (teacher == null) throw new ArgumentNullException(nameof(teacher));

        WriteLine("Get teacher from teacher method");

        return new Teacher();
    }

    public static Person GetPersonFromTeacher(Teacher teacher)
    {
        if (teacher == null) throw new ArgumentNullException(nameof(teacher));

        WriteLine("Get person from teacher method");

        return new Person();
    }

    public static Person GetPersonFromPerson(Person person)
    {
        if (person == null) throw new ArgumentNullException(nameof(person));

        WriteLine("Get person from person method");

        return new Person();
    }
}
