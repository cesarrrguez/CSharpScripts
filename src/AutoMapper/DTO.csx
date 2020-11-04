public class UserDTO
{
    public Guid Id { get; private set; }
    public string Name { get; }
    public string Street { get; }
    public string City { get; }

    public override string ToString()
    {
        return $"User. Id: {Id}, Name: {Name}, Street: {Street}, City: {City}";
    }
}
