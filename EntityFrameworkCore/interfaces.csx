#load "entities.csx"

public interface IRepository<T> where T : IAggregateRoot
{
}

public interface IUserRepository : IRepository<User>
{
    void Add(User user);
    void Update(User user);
    void Delete(User user);
    List<User> GetAll();
    User Get(int userId);
}

public interface IUserService
{
    void RegisterNewUser(User user);
    void EditUser(User user);
    void DeleteUser(User user);
    List<User> GetAllUsers();
    User GetUser(int userId);
}
