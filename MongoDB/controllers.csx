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
        PrintUsers(users);
    }

    public void Get(string id)
    {
        WriteLine("\nGet User:");
        WriteLine(_separator);

        var user = _userService.Get(id);
        if (user == null) throw new ArgumentException(nameof(id));

        PrintUser(user);
    }

    public void Create(User user)
    {
        _userService.Create(user);
    }

    public void Update(string id, User userIn)
    {
        var user = _userService.Get(id);
        if (user == null) throw new ArgumentException(nameof(id));

        _userService.Update(id, userIn);
    }

    public void Delete(string id)
    {
        var user = _userService.Get(id);
        if (user == null) throw new ArgumentException(nameof(id));

        _userService.Remove(user.Id);
    }

    private void PrintUsers(IEnumerable<User> users)
    {
        if (users?.Any() != true)
        {
            WriteLine("No users");
        }
        else
        {
            foreach (var user in users)
            {
                PrintUser(user);
            }
        }
    }

    private void PrintUser(User user)
    {
        WriteLine(user);
    }
}
