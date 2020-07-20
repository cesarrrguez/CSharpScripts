#load "entities.csx"
#load "interfaces.csx"

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// Context
public class DataContext : DbContext, IDataContext
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
        builder.HasKey(u => u.Id);

        // Properties
        builder.Property(u => u.Product)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Units).IsRequired();
    }
}

public class CustomerMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers", DataContext.DEFAULT_SCHEMA);

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

// Unit of Work
public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;

    private IOrderRepository _orderRepository;
    public IOrderRepository OrderRepository
    {
        get { return _orderRepository = _orderRepository ?? new OrderRepository(_context); }
    }

    private ICustomerRepository _customerRepository;
    public ICustomerRepository CustomerRepository
    {
        get { return _customerRepository = _customerRepository ?? new CustomerRepository(_context); }
    }

    public UnitOfWork(DataContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public bool Commit()
    {
        return _context.SaveChanges() > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}

// Repositories
public class OrderRepository : IOrderRepository
{
    private readonly DataContext _context;

    public OrderRepository(DataContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(Order order)
    {
        _context.Orders.Add(order);
    }
}

public class CustomerRepository : ICustomerRepository
{
    private readonly DataContext _context;

    public CustomerRepository(DataContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(Customer customer)
    {
        _context.Customers.Add(customer);
    }
}
