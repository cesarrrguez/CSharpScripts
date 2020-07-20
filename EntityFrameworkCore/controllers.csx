#load "interfaces.csx"

public class UserController
{
    private readonly IUserService _userService;
    private string _separator = new string(Enumerable.Repeat('-', 15).ToArray());

    public UserController(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public async Task Create(User user)
    {
        Console.WriteLine("Add User:");
        Console.WriteLine(_separator);

        await _userService.RegisterNewUser(user);
    }

    public async Task Edit(User user)
    {
        Console.WriteLine("\nUpdate User:");
        Console.WriteLine(_separator);

        await _userService.EditUser(user);
    }

    public async Task Delete(User user)
    {
        Console.WriteLine("\nDelete User:");
        Console.WriteLine(_separator);

        await _userService.DeleteUser(user);
    }

    public async Task Details(int userId)
    {
        Console.WriteLine("\nGet User:");
        Console.WriteLine(_separator);

        var user = await _userService.GetUser(userId);
        PrintUser(user);
    }

    public async Task Index()
    {
        var users = await _userService.GetAllUsers();
        PrintUsers(users);
    }

    private void PrintUsers(IEnumerable<User> users)
    {
        if (users == null || !users.Any())
        {
            Console.WriteLine("No users");
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
        Console.WriteLine(user);
    }
}
