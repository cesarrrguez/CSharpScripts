public class User
{
    private readonly Guid _id;

    public User()
    {
        _id = new Guid();
    }

    public Guid GetId()
    {
        return _id;
    }

    public override string ToString() => $"Id: {_id}";
}
