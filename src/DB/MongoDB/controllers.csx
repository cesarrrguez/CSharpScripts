#load "interfaces.csx"
#load "entities.csx"

public class UserController : IUserController
{
    private readonly IUserService _userService;
    private readonly string _separator = new string(Enumerable.Repeat('-', 15).ToArray());

    public UserController(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public void Get()
    {
        WriteLine("\nGet Users:");
        WriteLine(_separator);

        var users = _userService.Get();

        if (users?.Count > 0)
            users.ForEach(user => WriteLine(user));
        else
            WriteLine("No users");
    }

    public void Get(string id)
    {
        WriteLine("\nGet User:");
        WriteLine(_separator);

        var user = _userService.Get(id);
        if (user == null) throw new ArgumentException(nameof(id));

        WriteLine(user);
    }

    public void Create(User user)
    {
        WriteLine("\nCreate User:");
        WriteLine(_separator);

        _userService.Create(user);

        WriteLine(user);
    }

    public void Update(string id, User userIn)
    {
        WriteLine("\nUpdate User:");
        WriteLine(_separator);

        var user = _userService.Get(id);
        if (user == null) throw new ArgumentException(nameof(id));

        _userService.Update(id, userIn);

        WriteLine(userIn);
    }

    public void Delete(string id)
    {
        WriteLine("\nDelete User:");
        WriteLine(_separator);

        var user = _userService.Get(id);
        if (user == null) throw new ArgumentException(nameof(id));

        _userService.Remove(user.Id);

        WriteLine(user);
    }
}
