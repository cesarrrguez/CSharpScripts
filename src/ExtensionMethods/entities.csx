using ProtoBuf;

[Serializable, ProtoContract]
public class User
{
    [ProtoMember(1)]
    public string Name { get; }
    [ProtoMember(2)]
    public double Age { get; private set; }

    // Empty constructor for ProtoBuf
    protected User() { }

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

    public override string ToString() => $"User. Name: {Name}, Age: {Age}";
}
