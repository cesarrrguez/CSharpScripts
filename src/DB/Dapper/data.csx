#load "interfaces.csx"
#load "utils.csx"

using System.Data;

using Dapper;
using Microsoft.Data.Sqlite;

public class ConnectionFactory : IConnectionFactory
{
    private readonly string _connectionString = $"Data Source={FolderUtil.GetCurrentDirectoryName()}/database.db";

    public IDbConnection GetConnection() => new SqliteConnection(_connectionString);
}

public class UnitOfWork : IUnitOfWork
{
    public IUserRepository Users { get; }

    public UnitOfWork(IUserRepository userRepository)
    {
        Users = userRepository;
    }
}

public class UserRepository : IUserRepository
{
    private readonly IConnectionFactory _connectionFactory;

    public UserRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<int> AddAsync(User user)
    {
        using var connection = _connectionFactory.GetConnection();
        const string query = "INSERT INTO Users (Name) VALUES (@Name); SELECT last_insert_rowid()";
        var result = await connection.QueryAsync<int>(query, user);
        return result.Single();
    }

    public async Task<int> UpdateAsync(User user)
    {
        using var connection = _connectionFactory.GetConnection();
        const string query = "UPDATE Users SET Name = @Name WHERE Id = @Id";
        return await connection.ExecuteAsync(query, user);
    }

    public async Task<int> DeleteAsync(int id)
    {
        using var connection = _connectionFactory.GetConnection();
        const string query = "DELETE FROM Users WHERE id = @Id";
        return await connection.ExecuteAsync(query, new { Id = id });
    }

    public async Task<User> GetByIdAsync(int id)
    {
        using var connection = _connectionFactory.GetConnection();
        const string query = "SELECT * FROM Users WHERE id = @Id";
        return await connection.QuerySingleOrDefaultAsync<User>(query, new { Id = id });
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        using var connection = _connectionFactory.GetConnection();
        const string query = "SELECT * FROM Users";
        return await connection.QueryAsync<User>(query);
    }
}
