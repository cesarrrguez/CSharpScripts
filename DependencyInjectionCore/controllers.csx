#load "interfaces.csx"

public class UserController : IUserController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public void Get()
    {
        var name = _userService.GetName();
        WriteLine(name);
    }
}
