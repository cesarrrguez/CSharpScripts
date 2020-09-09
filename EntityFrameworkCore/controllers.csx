#load "interfaces.csx"

public class UserController : IUserController
{
    private readonly IUserService _userService;
    private readonly string _separator = new string(Enumerable.Repeat('-', 15).ToArray());

    public UserController(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public async Task Create(UserViewModel userViewModel)
    {
        Console.WriteLine("Create User:");
        Console.WriteLine(_separator);

        await _userService.Register(userViewModel).ConfigureAwait(false);
    }

    public async Task<UserViewModel> Get(int id)
    {
        return await _userService.GetById(id).ConfigureAwait(false);
    }

    public async Task Edit(UserViewModel userViewModel)
    {
        Console.WriteLine("\nEdit User:");
        Console.WriteLine(_separator);

        await _userService.Update(userViewModel).ConfigureAwait(false);
    }

    public async Task Delete(int id)
    {
        Console.WriteLine("\nDelete User:");
        Console.WriteLine(_separator);

        await _userService.Remove(id).ConfigureAwait(false);
    }

    public async Task Details(int id)
    {
        Console.WriteLine("\nDetails User:");
        Console.WriteLine(_separator);

        var userViewModel = await _userService.GetById(id).ConfigureAwait(false);
        PrintUser(userViewModel);
    }

    public async Task Index()
    {
        var users = await _userService.GetAll().ConfigureAwait(false);
        PrintUsers(users);
    }

    private void PrintUsers(IEnumerable<UserViewModel> users)
    {
        if (users?.Any() != true)
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

    private void PrintUser(UserViewModel userViewModel)
    {
        Console.WriteLine(userViewModel);
    }

    public void Dispose()
    {
        _userService.Dispose();
        GC.SuppressFinalize(this);
    }
}
