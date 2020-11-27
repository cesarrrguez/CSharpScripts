public class User
{
    public string Name { get; set; }
    public int Age { get; set; }

    // Instance constructor
    public User(string name, int age)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Age = age;
    }

    // Copy constructor
    public User(User user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));

        Name = user.Name;
        Age = user.Age;
    }

    // Copy constructor alternative
    //public User(User user) : this(user.Name, user.Age) { }

    public override string ToString() => $"User. Name: {Name}, Age: {Age}";
}
