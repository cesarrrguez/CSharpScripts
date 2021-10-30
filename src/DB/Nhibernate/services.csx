#load "interfaces.csx"
#load "viewModels.csx"

using AutoMapper;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task AddAsync(UserViewModel userViewModel)
    {
        var user = _mapper.Map<User>(userViewModel);

        await _userRepository.AddAsync(user).ConfigureAwait(false);
    }

    public async Task UpdateAsync(UserViewModel userViewModel)
    {
        var user = _mapper.Map<User>(userViewModel);

        await _userRepository.UpdateAsync(user).ConfigureAwait(false);
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id).ConfigureAwait(false);

        await _userRepository.DeleteAsync(user).ConfigureAwait(false);
    }

    public async Task<UserViewModel> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id).ConfigureAwait(false);

        return _mapper.Map<UserViewModel>(user);
    }

    public IList<UserViewModel> GetAll()
    {
        var users = _userRepository.GetAll();

        return _mapper.Map<IList<UserViewModel>>(users);
    }
}
