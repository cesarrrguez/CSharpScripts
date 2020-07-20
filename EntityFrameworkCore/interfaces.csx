#load "entities.csx"

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
    Task<IEnumerable<User>> GetAll();
    Task<User> Get(int userId);
}

public interface IUserService : IDisposable
{
    Task RegisterNewUser(User user);
    Task EditUser(User user);
    Task DeleteUser(User user);
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUser(int userId);
}
