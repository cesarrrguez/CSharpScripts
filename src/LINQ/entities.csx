public class User
{
    public int Id { get; }
    public string FullName { get; }
    public int CourseId { get; }

    public User(int id, string fullName, int courseId)
    {
        Id = id;
        FullName = fullName;
        CourseId = courseId;
    }

    public override string ToString() => $"User (Id: {Id}, FullName: {FullName}, CourseId: {CourseId})";
}

public class Course
{
    public int Id { get; }
    public string Title { get; }

    public Course(int id, string city)
    {
        Id = id;
        Title = city;
    }

    public override string ToString() => $"Course (Id: {Id}, Title: {Title})";
}

public class Sale
{
    public string Product { get; set; }
    public decimal Amount { get; set; }
    public string Brand { get; set; }
}
