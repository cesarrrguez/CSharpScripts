#load "interfaces.csx"

using MongoDB.Driver;

// Context
public class DataContext
{
    public IMongoCollection<User> Users { get; set; }

    public DataContext(IDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var dataBase = client.GetDatabase(settings.DatabaseName);

        Users = dataBase.GetCollection<User>(settings.UsersCollectionName);
    }
}

// Repositories
public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<User>> GetAllAsync()
    {
        var users = await _context.Users.FindAsync(_ => true);
        return users.ToList();
    }

    public async Task<User> GetAsync(string id)
    {
        var user = await _context.Users.FindAsync(u => u.Id == id);
        return user.FirstOrDefault();
    }

    public async Task<User> CreateAsync(User user)
    {
        await _context.Users.InsertOneAsync(user);
        return user;
    }

    public async Task UpdateAsync(string id, User user)
    {
        await _context.Users.ReplaceOneAsync(u => u.Id == id, user);
    }

    public async Task RemoveAsync(User user)
    {
        await _context.Users.DeleteOneAsync(u => u.Id == user.Id);
    }

    public async Task RemoveAsync(string id)
    {
        await _context.Users.DeleteOneAsync(u => u.Id == id);
    }
}
