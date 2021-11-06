public class User
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString() => $"{GetType().Name}. {nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
}
