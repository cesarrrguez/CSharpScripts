#load "entities.csx"

public interface IDataContext
{
}

public interface IRepository<T> where T : IAggregateRoot
{
}

public interface IUserRepository : IRepository<User>, IDisposable
{
    Task Add(User user);
    Task Update(User user);
    Task Remove(User user);
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
