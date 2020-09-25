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

    public async Task Register(UserViewModel userViewModel)
    {
        var user = _mapper.Map<User>(userViewModel);

        await _userRepository.Add(user).ConfigureAwait(false);
        await _userRepository.UnitOfWork.Commit().ConfigureAwait(false);
    }

    public async Task Update(UserViewModel userViewModel)
    {
        var user = _mapper.Map<User>(userViewModel);

        _userRepository.Update(user);
        await _userRepository.UnitOfWork.Commit().ConfigureAwait(false);
    }

    public async Task Remove(int id)
    {
        var user = await _userRepository.GetById(id).ConfigureAwait(false);

        _userRepository.Remove(user);
        await _userRepository.UnitOfWork.Commit().ConfigureAwait(false);
    }

    public async Task<UserViewModel> GetById(int id)
    {
        var user = await _userRepository.GetById(id).ConfigureAwait(false);

        return _mapper.Map<UserViewModel>(user);
    }

    public async Task<IEnumerable<UserViewModel>> GetAll()
    {
        var users = await _userRepository.GetAll().ConfigureAwait(false);

        return _mapper.Map<IEnumerable<UserViewModel>>(users);
    }

    public void Dispose()
    {
        _userRepository.Dispose();
        GC.SuppressFinalize(this);
    }
}
