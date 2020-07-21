#load "entities.csx"
#load "viewModels.csx"

public interface IUnitOfWork : IDisposable
{
    Task<bool> Commit();
}

public interface IRepository<T> where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}

public interface IUserRepository : IRepository<User>, IDisposable
{
    Task Add(User user);
    void Update(User user);
    void Remove(User user);
    Task<User> GetById(int id);
    Task<IEnumerable<User>> GetAll();
}

public interface IUserService : IDisposable
{
    Task Register(UserViewModel userViewModel);
    Task Update(UserViewModel userViewModel);
    Task Remove(int id);
    Task<UserViewModel> GetById(int id);
    Task<IEnumerable<UserViewModel>> GetAll();
}

public interface IUserController : IDisposable
{
    Task Create(UserViewModel userViewModel);
    Task<UserViewModel> Get(int id);
    Task Edit(UserViewModel userViewModel);
    Task Delete(int id);
    Task Details(int id);
    Task Index();
}
