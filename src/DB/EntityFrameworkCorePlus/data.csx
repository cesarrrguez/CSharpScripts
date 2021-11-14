#load "entities.csx"
#load "utils.csx"

using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Filename={FolderUtil.GetCurrentDirectoryName()}/database.db");
        base.OnConfiguring(optionsBuilder);
    }
}

public class DbUtil
{
    public void PrepareData()
    {
        CreateDb();
        GenerateUsers();
    }

    private void CreateDb()
    {
        using var context = new ApplicationDbContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }

    private void GenerateUsers()
    {
        var users = new List<User>();

        for (int i = 0; i < 100_000; i++)
        {
            users.Add(new User() { Name = $"User {i}" });
        }

        using var context = new ApplicationDbContext();
        context.AddRange(users);
        context.SaveChanges();
    }

    public void DeleteAllUsers()
    {
        using var context = new ApplicationDbContext();
        var personas = context.Users.Where(x => x.Id < 50_000).ToList();
        context.RemoveRange(personas);
        context.SaveChanges();
    }

    public void DeleteAllUsersPlus()
    {
        using var context = new ApplicationDbContext();
        //context.Users.DeleteFromQuery();
        context.Users.Where(x => x.Id < 50_000).DeleteFromQuery();
    }
}
