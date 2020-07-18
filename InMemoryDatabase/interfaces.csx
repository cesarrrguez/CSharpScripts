#load "entities.csx"

public interface IDataContext
{
}

public interface IUserRepository
{
    Task<User> Get(int userId);
}
