#load "entities.csx"
#load "interfaces.csx"

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// Context
public class DataContext : DbContext, IUnitOfWork
{
    public const string DEFAULT_SCHEMA = "data";

    public DbSet<User> Users { get; set; }
    public DbSet<UserAddress> UserAddresses { get; set; }
    public DbSet<UserEmail> UserEmails { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new UserAddressMap());
        modelBuilder.ApplyConfiguration(new UserEmailMap());

        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> Commit()
    {
        return await SaveChangesAsync().ConfigureAwait(false) > 0;
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

        builder.Property(u => u.Age).IsRequired();
    }
}

public class UserAddressMap : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.ToTable("UserAddresses", DataContext.DEFAULT_SCHEMA);

        // Primary Key
        builder.HasKey(ua => ua.Id);

        // Properties
        builder.Property(ua => ua.Street)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(ua => ua.City)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ua => ua.State)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(ua => ua.ZipCode)
            .IsRequired()
            .HasMaxLength(10)
            .HasColumnType("varchar(100)");

        // Relationships
        builder.HasOne(ua => ua.User)
            .WithMany(ua => ua.Addresses)
            .IsRequired();
    }
}

public class UserEmailMap : IEntityTypeConfiguration<UserEmail>
{
    public void Configure(EntityTypeBuilder<UserEmail> builder)
    {
        builder.ToTable("UserEmails", DataContext.DEFAULT_SCHEMA);

        // Primary Key
        builder.HasKey(ue => ue.Id);

        // Properties
        builder.Property(ue => ue.EmailAddress)
            .IsRequired()
            .HasMaxLength(200);

        // Relationships
        builder.HasOne(ue => ue.User)
            .WithMany(ue => ue.Emails)
            .IsRequired();
    }
}

// Repositories
public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public UserRepository(DataContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user).ConfigureAwait(false);
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
    }

    public void Remove(User user)
    {
        _context.Users.Remove(user);
    }

    public async Task<User> GetById(int id)
    {
        return await _context.Users
            .Include(u => u.Addresses)
            .Include(u => u.Emails)
            .SingleOrDefaultAsync(u => u.Id == id).ConfigureAwait(false);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.Users
            .Include(u => u.Addresses)
            .Include(u => u.Emails)
            .ToListAsync().ConfigureAwait(false);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
