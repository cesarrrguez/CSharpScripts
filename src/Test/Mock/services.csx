#load "interfaces.csx"

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllAsync().ConfigureAwait(false);
    }

    public async Task<User> GetUserAsync(int userId)
    {
        return await _userRepository.GetAsync(userId).ConfigureAwait(false);
    }
}
