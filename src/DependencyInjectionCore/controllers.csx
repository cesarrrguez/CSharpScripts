#load "interfaces.csx"

public class UserController : IUserController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public async Task GetAsync()
    {
        var name = await _userService.GetAsync();
        WriteLine(name);
    }
}
