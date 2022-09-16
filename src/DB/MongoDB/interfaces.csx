#load "entities.csx"

public interface IDbSettings
{
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
    string UsersCollectionName { get; set; }
}

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User> GetAsync(string id);
    Task<User> CreateAsync(User user);
    Task UpdateAsync(string id, User user);
    Task RemoveAsync(User user);
    Task RemoveAsync(string id);
}

public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task<User> GetAsync(string id);
    Task<User> CreateAsync(User user);
    Task UpdateAsync(string id, User user);
    Task RemoveAsync(User user);
    Task RemoveAsync(string id);
}

public interface IUserController
{
    Task GetAllAsync();
    Task GetAsync(string id);
    Task CreateAsync(User user);
    Task UpdateAsync(string id, User user);
    Task DeleteAsync(string id);
}
