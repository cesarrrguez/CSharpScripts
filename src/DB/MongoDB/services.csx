#load "entities.csx"
#load "interfaces.csx"

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public List<User> Get() => _userRepository.Get();

    public User Get(string id) => _userRepository.Get(id);

    public User Create(User user) => _userRepository.Create(user);

    public void Update(string id, User user) => _userRepository.Update(id, user);

    public void Remove(User user) => _userRepository.Remove(user);

    public void Remove(string id) => _userRepository.Remove(id);
}
