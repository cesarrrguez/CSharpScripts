#load "entities.csx"
#load "interfaces.csx"

// Repositories
public class UserRepository : IUserRepository
{
    public Task<IEnumerable<User>> GetAllAsync() => throw new NotImplementedException();

    public Task<User> GetAsync(int userId) => throw new NotImplementedException();
}
