public class User
{
    public int Id { get; private set; }
    public string FullName { get; private set; }
    public int CourseId { get; private set; }

    public User(int id, string fullName, int courseId)
    {
        Id = id;
        FullName = fullName;
        CourseId = courseId;
    }

    public override string ToString()
    {
        return $"User (Id: {Id}, FullName: {FullName}, CourseId: {CourseId})";
    }
}

public class Course
{
    public int Id { get; private set; }
    public string Title { get; private set; }

    public Course(int id, string city)
    {
        Id = id;
        Title = city;
    }

    public override string ToString()
    {
        return $"Course (Id: {Id}, Title: {Title})";
    }
}
