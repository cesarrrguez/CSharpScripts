#load "interfaces.csx"

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task RegisterNewUser(User user)
    {
        await _userRepository.Add(user);
        await _userRepository.UnitOfWork.Commit();
    }

    public async Task EditUser(User user)
    {
        _userRepository.Update(user);
        await _userRepository.UnitOfWork.Commit();
    }

    public async Task DeleteUser(User user)
    {
        _userRepository.Remove(user);
        await _userRepository.UnitOfWork.Commit();
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
