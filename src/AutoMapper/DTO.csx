public class UserDTO
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public string Street { get; set; }
    public string City { get; set; }

    public override string ToString() => $"User. Id: {Id}, Name: {Name}, Street: {Street}, City: {City}";
}
