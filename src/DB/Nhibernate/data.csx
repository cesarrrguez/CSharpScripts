#load "entities.csx"
#load "interfaces.csx"
#load "utils.csx"

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;

using System.IO;

// Context
public static class DataContext
{
    private static readonly string _dbFileName = $"{FolderUtil.GetCurrentDirectoryName()}/database.db";
    private static ISessionFactory sessionFactory;

    public static ISession OpenSession()
    {
        return SessionFactory.OpenSession();
    }

    private static ISessionFactory SessionFactory
    {
        get { return sessionFactory ??= CreateSessionFactory(); }
    }

    private static ISessionFactory CreateSessionFactory()
    {
        return Fluently.Configure()
          .Database(
            SQLiteConfiguration.Standard
              .UsingFile(_dbFileName)
          )
          .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
          .ExposeConfiguration(BuildSchema)
          .BuildSessionFactory();
    }

    private static void BuildSchema(Configuration config)
    {
        if (!File.Exists(_dbFileName))
        {
            new SchemaExport(config).Create(false, true);
        }
        else
        {
            FileInfo info = new FileInfo(_dbFileName);
            long size = info.Length;
            if (size == 0)
            {
                new SchemaExport(config).Create(false, true);
            }
        }
    }
}

// Mappings
public class UserMap : ClassMap<User>
{
    public UserMap()
    {
        Table("Users");

        // Primary Key
        Id(u => u.Id).UniqueKey("Id");

        // Properties
        Map(u => u.FirstName)
            .Not.Nullable()
            .Length(50);

        Map(u => u.LastName)
            .Not.Nullable()
            .Length(50);

        Map(u => u.Age).Not.Nullable();

        // Relationships
        HasMany(u => u.Addresses)
            .Cascade.All()
            .Not.LazyLoad();

        HasMany(u => u.Emails)
            .Cascade.All()
            .Not.LazyLoad();
    }
}

public class UserAddressMap : ClassMap<UserAddress>
{
    public UserAddressMap()
    {
        Table("UserAddresses");

        // Primary Key
        Id(ua => ua.Id).UniqueKey("Id");

        // Properties
        Map(ua => ua.Street)
            .Not.Nullable()
            .Length(200);

        Map(ua => ua.City)
            .Not.Nullable()
            .Length(100);

        Map(ua => ua.State)
            .Not.Nullable()
            .Length(50);

        Map(ua => ua.ZipCode)
            .Not.Nullable()
            .CustomSqlType("varchar(10)")
            .Length(10);

        // Relationships
        References(ua => ua.User);
    }
}

public class UserEmailMap : ClassMap<UserEmail>
{
    public UserEmailMap()
    {
        Table("UserEmails");

        // Primary Key
        Id(ue => ue.Id).UniqueKey("Id");

        // Properties
        Map(ue => ue.EmailAddress)
            .Not.Nullable()
            .Length(200);

        // Relationships
        References(ue => ue.User);
    }
}

// Repositories
public class UserRepository : IUserRepository
{
    public async Task AddAsync(User user)
    {
        using ISession session = DataContext.OpenSession();
        using ITransaction transaction = session.BeginTransaction();

        try
        {
            await session.SaveAsync(user).ConfigureAwait(false);
            await transaction.CommitAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            if (!transaction.WasCommitted)
            {
                transaction.Rollback();
            }
            throw new Exception($"Add data: {ex.Message}");
        }
    }

    public async Task UpdateAsync(User user)
    {
        using ISession session = DataContext.OpenSession();
        using ITransaction transaction = session.BeginTransaction();

        try
        {
            await session.UpdateAsync(user).ConfigureAwait(false);
            await transaction.CommitAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            if (!transaction.WasCommitted)
            {
                transaction.Rollback();
            }
            throw new Exception($"Update data: {ex.Message}");
        }
    }

    public async Task DeleteAsync(User user)
    {
        using ISession session = DataContext.OpenSession();
        using ITransaction transaction = session.BeginTransaction();

        try
        {
            await session.DeleteAsync(user).ConfigureAwait(false);
            await transaction.CommitAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            if (!transaction.WasCommitted)
            {
                transaction.Rollback();
            }
            throw new Exception($"Delete data: {ex.Message}");
        }
    }

    public async Task<User> GetByIdAsync(int id)
    {
        using ISession session = DataContext.OpenSession();

        return await session.GetAsync<User>(id).ConfigureAwait(false);
    }

    public IList<User> GetAll()
    {
        using ISession session = DataContext.OpenSession();

        return session.Query<User>().ToList();
    }
}
