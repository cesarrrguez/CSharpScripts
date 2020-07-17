#load "interfaces.csx"

public class UserController : IUserController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public string Get()
    {
        return _userService.GetName();
    }
}
