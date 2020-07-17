#load "entities.csx"

public interface IDataContext
{
}

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll();
    Task<User> Get(int userId);
}

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUser(int userId);
}
