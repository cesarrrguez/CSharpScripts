#load "interfaces.csx"

public class UserController : IUserController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public void Get()
    {
        var name = _userService.GetName();
        WriteLine(name);
    }
}
