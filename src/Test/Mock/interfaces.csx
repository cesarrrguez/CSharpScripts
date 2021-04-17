#load "entities.csx"

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> GetAsync(int userId);
}

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetUserAsync(int userId);
}
