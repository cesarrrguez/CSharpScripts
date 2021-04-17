#load "viewModels.csx"
#load "controllers.csx"
#load "configurations.csx"
#load "utils.csx"

#r "nuget: AutoMapper, 10.0.0"
#r "nuget: Microsoft.EntityFrameworkCore.Sqlite, 3.1.0"
//#r "nuget: Microsoft.EntityFrameworkCore.SqlServer, 3.1.0"
#r "nuget: AutoMapper.Extensions.Microsoft.DependencyInjection, 8.0.1"

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

// Call App entry point
App.Run();

public static class App
{
    private static IServiceProvider _serviceProvider;

    public static void Run()
    {
        ConfigureServices();

        // Ensure the database is created
        _serviceProvider.GetService<DataContext>().Database.EnsureCreated();

        var servicesTask = CallServicesAsync();
        servicesTask.Wait();

        DisposeServices();
    }

    private static void ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite($"Filename={FolderUtil.GetCurrentDirectoryName()}/database.db");
            //options.UseSqlServer("Server=localhost;Database=EntityFrameworkCore;Trusted_Connection=True;");
        }, ServiceLifetime.Transient);

        AutoMapperConfig.AddAutoMapperConfiguration(services);

        DependencyInjectionConfig.AddDependencyInjectionConfiguration(services);

        _serviceProvider = services.BuildServiceProvider();
    }

    private static void DisposeServices()
    {
        if (_serviceProvider == null) return;

        if (_serviceProvider is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }

    private static async Task CallServicesAsync()
    {
        // Create user view model object
        var userViewModel = CreateUserViewModel();

        // Create User
        await _serviceProvider.GetService<IUserController>().CreateAsync(userViewModel).ConfigureAwait(false);
        await _serviceProvider.GetService<IUserController>().IndexAsync().ConfigureAwait(false);

        // Update User
        userViewModel = _serviceProvider.GetService<IUserController>().GetAsync(1).Result;
        userViewModel.Age = 21;
        userViewModel.Emails.Add(new UserEmailViewModel { EmailAddress = "james.wilson_33.@hotmail.com" });
        await _serviceProvider.GetService<IUserController>().EditAsync(userViewModel).ConfigureAwait(false);
        await _serviceProvider.GetService<IUserController>().IndexAsync().ConfigureAwait(false);

        // Details User
        await _serviceProvider.GetService<IUserController>().DetailsAsync(userViewModel.Id).ConfigureAwait(false);

        // Delete User
        await _serviceProvider.GetService<IUserController>().DeleteAsync(userViewModel.Id).ConfigureAwait(false);
        await _serviceProvider.GetService<IUserController>().IndexAsync().ConfigureAwait(false);
    }

    private static UserViewModel CreateUserViewModel()
    {
        return new UserViewModel
        {
            FirstName = "James",
            LastName = "Wilson",
            Age = 30,
            Addresses = new List<UserAddressViewModel>(new UserAddressViewModel[] {
            new UserAddressViewModel {
                Street= "Wall Street",
                City= "New York",
                State="New York State",
                ZipCode="0123456789"},
         }),
            Emails = new List<UserEmailViewModel>(new UserEmailViewModel[] {
            new UserEmailViewModel {
                EmailAddress= "james.wilson@gmail.com"
            },
         })
        };
    }
}
