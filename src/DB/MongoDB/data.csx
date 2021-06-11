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

    public List<User> Get() => _context.Users.Find(_ => true).ToList();

    public User Get(string id) => _context.Users.Find(u => u.Id == id).FirstOrDefault();

    public User Create(User user)
    {
        _context.Users.InsertOne(user);
        return user;
    }

    public void Update(string id, User user) => _context.Users.ReplaceOne(u => u.Id == id, user);

    public void Remove(User user) => _context.Users.DeleteOne(u => u.Id == user.Id);

    public void Remove(string id) => _context.Users.DeleteOne(u => u.Id == id);
}
