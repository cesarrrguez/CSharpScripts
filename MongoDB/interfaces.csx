#load "entities.csx"

public interface IDbSettings
{
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
    string UsersCollectionName { get; set; }
}

public interface IUserRepository
{
    List<User> Get();
    User Get(string id);
    User Create(User user);
    void Update(string id, User user);
    void Remove(User user);
    void Remove(string id);
}

public interface IUserService
{
    List<User> Get();
    User Get(string id);
    void Create(User user);
    void Update(string id, User user);
    void Remove(User user);
    void Remove(string id);
}

public interface IUserController
{
    void Get();
    void Get(string id);
    void Create(User user);
    void Update(string id, User user);
    void Delete(string id);
}
