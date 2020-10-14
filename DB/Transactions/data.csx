#load "entities.csx"
#load "interfaces.csx"

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// Context
public class DataContext : DbContext
{
    public const string DEFAULT_SCHEMA = "data";

    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderMap());
        modelBuilder.ApplyConfiguration(new CustomerMap());

        base.OnModelCreating(modelBuilder);
    }
}

// Mappings
public class OrderMap : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders", DataContext.DEFAULT_SCHEMA);

        // Primary Key
        builder.HasKey(o => o.Id);

        // Properties
        builder.Property(o => o.Product)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(o => o.Units).IsRequired();

        builder.Property(o => o.CustomerId).IsRequired();
    }
}

public class CustomerMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers", DataContext.DEFAULT_SCHEMA);

        // Primary Key
        builder.HasKey(c => c.Id);

        // Properties
        builder.Property(c => c.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.LastName)
            .IsRequired()
            .HasMaxLength(50);
    }
}
