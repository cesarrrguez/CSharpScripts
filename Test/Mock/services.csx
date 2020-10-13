#load "interfaces.csx"

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _userRepository.GetAll().ConfigureAwait(false);
    }

    public async Task<User> GetUser(int userId)
    {
        return await _userRepository.Get(userId).ConfigureAwait(false);
    }
}
