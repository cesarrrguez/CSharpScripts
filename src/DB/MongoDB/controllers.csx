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

    public async Task GetAllAsync()
    {
        WriteLine("\nGet Users:");
        WriteLine(_separator);

        var users = await _userService.GetAllAsync();

        if (users?.Count > 0)
        {
            users.ForEach(user => WriteLine(user));
        }
        else
        {
            WriteLine("No users");
        }
    }

    public async Task GetAsync(string id)
    {
        WriteLine("\nGet User:");
        WriteLine(_separator);

        var user = await _userService.GetAsync(id);
        if (user == null) throw new ArgumentException(nameof(id));

        WriteLine(user);
    }

    public async Task CreateAsync(User user)
    {
        WriteLine("\nCreate User:");
        WriteLine(_separator);

        await _userService.CreateAsync(user);

        WriteLine(user);
    }

    public async Task UpdateAsync(string id, User userIn)
    {
        WriteLine("\nUpdate User:");
        WriteLine(_separator);

        var user = await _userService.GetAsync(id);
        if (user == null) throw new ArgumentException(nameof(id));

        await _userService.UpdateAsync(id, userIn);

        WriteLine(userIn);
    }

    public async Task DeleteAsync(string id)
    {
        WriteLine("\nDelete User:");
        WriteLine(_separator);

        var user = await _userService.GetAsync(id);
        if (user == null) throw new ArgumentException(nameof(id));

        await _userService.RemoveAsync(user.Id);

        WriteLine(user);
    }
}
