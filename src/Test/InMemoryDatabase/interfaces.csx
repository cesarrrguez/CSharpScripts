#load "entities.csx"

public interface IDataContext { }

public interface IUserRepository
{
    Task<User> GetAsync(int userId);
}
