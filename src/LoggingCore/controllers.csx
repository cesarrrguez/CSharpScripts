#load "interfaces.csx"

using System.Threading;
using Microsoft.Extensions.Logging;

public class UserController : IUserController
{
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<string> GetAsync()
    {
        _logger.LogError("The server went down temporarily at {Time}", DateTime.UtcNow);

        try
        {
            throw new Exception("You forgot to catch me");
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, "There was a bad exception at {Time}", DateTime.UtcNow);
        }

        return await _userService.GetAsync();
    }
}
