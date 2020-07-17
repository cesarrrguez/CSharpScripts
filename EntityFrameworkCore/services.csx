#load "interfaces.csx"

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task RegisterNewUser(User user)
    {
        await _userRepository.Add(user);
    }

    public async Task EditUser(User user)
    {
        await _userRepository.Update(user);
    }

    public async Task DeleteUser(User user)
    {
        await _userRepository.Remove(user);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _userRepository.GetAll();
    }

    public async Task<User> GetUser(int userId)
    {
        return await _userRepository.Get(userId);
    }

    public void Dispose()
    {
        _userRepository.Dispose();
        GC.SuppressFinalize(this);
    }
}
