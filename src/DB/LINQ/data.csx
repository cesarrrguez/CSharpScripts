#load "entities.csx"
#load "utils.csx"

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Animal> Animals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"DataSource={FolderUtil.GetCurrentDirectoryName()}/app.db");
}
