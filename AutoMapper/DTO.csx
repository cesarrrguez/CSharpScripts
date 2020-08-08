public class UserDTO
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Street { get; private set; }
    public string City { get; private set; }

    public override string ToString()
    {
        return $"User. Id: {Id}, Name: {Name}, Street: {Street}, City: {City}";
    }
}
