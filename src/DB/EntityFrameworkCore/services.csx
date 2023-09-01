#load "interfaces.csx"
#load "viewModels.csx"

using AutoMapper;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task RegisterAsync(UserViewModel userViewModel)
    {
        var user = _mapper.Map<User>(userViewModel);

        await _userRepository.AddAsync(user);
        await _userRepository.UnitOfWork.CommitAsync();
    }

    public async Task UpdateAsync(UserViewModel userViewModel)
    {
        var user = _mapper.Map<User>(userViewModel);

        _userRepository.Update(user);
        await _userRepository.UnitOfWork.CommitAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        _userRepository.Remove(user);
        await _userRepository.UnitOfWork.CommitAsync();
    }

    public async Task<UserViewModel> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        return _mapper.Map<UserViewModel>(user);
    }

    public async Task<IEnumerable<UserViewModel>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<UserViewModel>>(users);
    }

    public void Dispose()
    {
        _userRepository.Dispose();
        GC.SuppressFinalize(this);
    }
}
