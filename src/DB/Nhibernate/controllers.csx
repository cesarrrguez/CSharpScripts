#load "interfaces.csx"

public class UserController : IUserController
{
    private readonly IUserService _userService;
    private readonly string _separator = new string(Enumerable.Repeat('-', 15).ToArray());

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public async Task AddAsync(UserViewModel userViewModel)
    {
        WriteLine("Add User:");
        WriteLine(_separator);

        await _userService.AddAsync(userViewModel);
    }

    public async Task UpdateAsync(UserViewModel userViewModel)
    {
        WriteLine("\nUpdate User:");
        WriteLine(_separator);

        await _userService.UpdateAsync(userViewModel);
    }

    public async Task DeleteAsync(int id)
    {
        WriteLine("\nDelete User:");
        WriteLine(_separator);

        await _userService.DeleteAsync(id);
    }

    public async Task<UserViewModel> GetByIdAsync(int id)
    {
        return await _userService.GetByIdAsync(id);
    }

    public async Task DetailsAsync(int id)
    {
        WriteLine("\nDetails User:");
        WriteLine(_separator);

        var userViewModel = await _userService.GetByIdAsync(id);
        PrintUser(userViewModel);
    }

    public void Index()
    {
        var users = _userService.GetAll();
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
}
