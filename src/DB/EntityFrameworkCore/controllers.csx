#load "interfaces.csx"

public class UserController : IUserController
{
    private readonly IUserService _userService;
    private readonly string _separator = new string(Enumerable.Repeat('-', 15).ToArray());

    public UserController(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public async Task CreateAsync(UserViewModel userViewModel)
    {
        WriteLine("Create User:");
        WriteLine(_separator);

        await _userService.RegisterAsync(userViewModel).ConfigureAwait(false);
    }

    public async Task<UserViewModel> GetAsync(int id)
    {
        return await _userService.GetByIdAsync(id).ConfigureAwait(false);
    }

    public async Task EditAsync(UserViewModel userViewModel)
    {
        WriteLine("\nEdit User:");
        WriteLine(_separator);

        await _userService.UpdateAsync(userViewModel).ConfigureAwait(false);
    }

    public async Task DeleteAsync(int id)
    {
        WriteLine("\nDelete User:");
        WriteLine(_separator);

        await _userService.RemoveAsync(id).ConfigureAwait(false);
    }

    public async Task DetailsAsync(int id)
    {
        WriteLine("\nDetails User:");
        WriteLine(_separator);

        var userViewModel = await _userService.GetByIdAsync(id).ConfigureAwait(false);
        PrintUser(userViewModel);
    }

    public async Task IndexAsync()
    {
        var users = await _userService.GetAllAsync().ConfigureAwait(false);
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
