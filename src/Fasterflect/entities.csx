public class User
{
    public string Name { get; set; }
    public string[] Emails { get; set; }

    public override string ToString()
    {
        return $"{GetType().Name}. {nameof(Name)}: {Name}, {nameof(Emails)}: {string.Join(", ", Emails)}";
    }
}
