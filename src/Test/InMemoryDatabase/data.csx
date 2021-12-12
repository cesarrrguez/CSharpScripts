#load "entities.csx"
#load "interfaces.csx"

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// Context
public class DataContext : DbContext, IDataContext
{
    public const string DEFAULT_SCHEMA = "data";

    public DbSet<User> Users { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());

        base.OnModelCreating(modelBuilder);
    }
}

// Mappings
public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", DataContext.DEFAULT_SCHEMA);

        // Primary Key
        builder.HasKey(u => u.Id);

        // Properties
        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(50);
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

    public async Task<User> GetByIdAsync(int userId)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.Id == userId).ConfigureAwait(false);
    }
}
