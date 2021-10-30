#load "entities.csx"
#load "viewModels.csx"

public interface IRepository<T> where T : IAggregateRoot { }

public interface IUserRepository : IRepository<User>
{
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
    Task<User> GetByIdAsync(int id);
    IList<User> GetAll();
}

public interface IUserService
{
    Task AddAsync(UserViewModel userViewModel);
    Task UpdateAsync(UserViewModel userViewModel);
    Task DeleteAsync(int id);
    Task<UserViewModel> GetByIdAsync(int id);
    IList<UserViewModel> GetAll();
}

public interface IUserController
{
    Task AddAsync(UserViewModel userViewModel);
    Task UpdateAsync(UserViewModel userViewModel);
    Task DeleteAsync(int id);
    Task<UserViewModel> GetByIdAsync(int id);
    Task DetailsAsync(int id);
    void Index();
}
