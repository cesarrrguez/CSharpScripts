#load "entities.csx"

using System.Data;

public interface IConnectionFactory
{
    IDbConnection GetConnection();
}

public interface IUnitOfWork
{
    IUserRepository Users { get; }
}

public interface IGenericRepository<T> where T : class
{
    Task<int> AddAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(int id);
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
}

public interface IUserRepository : IGenericRepository<User> { }

public interface IUserService
{
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
    Task<User> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
}
