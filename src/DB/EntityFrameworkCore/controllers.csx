#load "interfaces.csx"

public class UserController : IUserController
{
    private readonly IUserService _userService;
    private readonly string _separator = new string(Enumerable.Repeat('-', 15).ToArray());

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public async Task CreateAsync(UserViewModel userViewModel)
    {
        WriteLine("Create User:");
        WriteLine(_separator);

        await _userService.RegisterAsync(userViewModel);
    }

    public async Task<UserViewModel> GetAsync(int id)
    {
        return await _userService.GetByIdAsync(id);
    }

    public async Task EditAsync(UserViewModel userViewModel)
    {
        WriteLine("\nEdit User:");
        WriteLine(_separator);

        await _userService.UpdateAsync(userViewModel);
    }

    public async Task DeleteAsync(int id)
    {
        WriteLine("\nDelete User:");
        WriteLine(_separator);

        await _userService.RemoveAsync(id);
    }

    public async Task DetailsAsync(int id)
    {
        WriteLine("\nDetails User:");
        WriteLine(_separator);

        var userViewModel = await _userService.GetByIdAsync(id);
        PrintUser(userViewModel);
    }

    public async Task IndexAsync()
    {
        var users = await _userService.GetAllAsync();
        PrintUsers(users);
    }

    private void PrintUsers(IEnumerable<UserViewModel> users)
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

    private void PrintUser(UserViewModel userViewModel)
    {
        WriteLine(userViewModel);
    }

    public void Dispose()
    {
        _userService.Dispose();
        GC.SuppressFinalize(this);
    }
}
