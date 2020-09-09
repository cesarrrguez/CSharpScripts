#load "entities.csx"
#load "interfaces.csx"

// Repositories
public class UserRepository : IUserRepository
{
    public Task<IEnumerable<User>> GetAll() => throw new NotImplementedException();

    public Task<User> Get(int userId) => throw new NotImplementedException();
}
