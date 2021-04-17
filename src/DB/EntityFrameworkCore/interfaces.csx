#load "entities.csx"
#load "viewModels.csx"

public interface IUnitOfWork : IDisposable
{
    Task<bool> CommitAsync();
}

public interface IRepository<T> where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}

public interface IUserRepository : IRepository<User>, IDisposable
{
    Task AddAsync(User user);
    void Update(User user);
    void Remove(User user);
    Task<User> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
}

public interface IUserService : IDisposable
{
    Task RegisterAsync(UserViewModel userViewModel);
    Task UpdateAsync(UserViewModel userViewModel);
    Task RemoveAsync(int id);
    Task<UserViewModel> GetByIdAsync(int id);
    Task<IEnumerable<UserViewModel>> GetAllAsync();
}

public interface IUserController : IDisposable
{
    Task CreateAsync(UserViewModel userViewModel);
    Task<UserViewModel> GetAsync(int id);
    Task EditAsync(UserViewModel userViewModel);
    Task DeleteAsync(int id);
    Task DetailsAsync(int id);
    Task IndexAsync();
}
