[Serializable]
public class User
{
    public string Name { get; private set; }
    public double Age { get; private set; }

    public User(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

        Name = name;
    }

    public void SetAge(double age)
    {
        if (age < 0) throw new ArgumentException(nameof(age));

        Age = age;
    }

    public override string ToString()
    {
        return $"User. Name: {Name}, Age: {Age}";
    }
}
