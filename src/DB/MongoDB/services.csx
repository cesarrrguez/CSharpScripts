#load "entities.csx"
#load "interfaces.csx"

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> GetAllAsync() => await _userRepository.GetAllAsync();

    public async Task<User> GetAsync(string id) => await _userRepository.GetAsync(id);

    public async Task<User> CreateAsync(User user) => await _userRepository.CreateAsync(user);

    public async Task UpdateAsync(string id, User user) => await _userRepository.UpdateAsync(id, user);

    public async Task RemoveAsync(User user) => await _userRepository.RemoveAsync(user);

    public async Task RemoveAsync(string id) => await _userRepository.RemoveAsync(id);
}
