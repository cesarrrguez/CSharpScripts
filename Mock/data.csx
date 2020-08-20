#load "entities.csx"
#load "interfaces.csx"

// Context
public class DataContext : IDataContext { }

// Repositories
public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Task<IEnumerable<User>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<User> Get(int userId)
    {
        throw new NotImplementedException();
    }
}
