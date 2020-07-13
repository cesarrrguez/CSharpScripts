#load "interfaces.csx"

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void RegisterNewUser(User user)
    {
        _userRepository.Add(user);
    }

    public void EditUser(User user)
    {
        _userRepository.Update(user);
    }

    public void DeleteUser(User user)
    {
        _userRepository.Delete(user);
    }

    public List<User> GetAllUsers()
    {
        return _userRepository.GetAll();
    }
    
    public User GetUser(int userId)
    {
        return _userRepository.Get(userId);
    }
}
