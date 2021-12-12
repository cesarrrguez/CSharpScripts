#load "entities.csx"

public interface IDataContext { }

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
}
