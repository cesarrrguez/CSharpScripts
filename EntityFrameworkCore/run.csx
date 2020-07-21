#load "viewModels.csx"
#load "controllers.csx"
#load "configurations.csx"

#r "nuget: AutoMapper, 10.0.0"
#r "nuget: Microsoft.EntityFrameworkCore.Sqlite, 3.1.0"
#r "nuget: AutoMapper.Extensions.Microsoft.DependencyInjection, 8.0.1"

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

// Call App entry point
await App.Run();

public class App
{
    private static IServiceProvider _serviceProvider;

    public async static Task Run()
    {
        RegisterServices();

        // Ensure the database is created
        _serviceProvider.GetService<DataContext>().Database.EnsureCreated();

        await CallServices();

        DisposeServices();
    }

    private static void RegisterServices()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite("Filename=EntityFrameworkCore/database.db");
        }, ServiceLifetime.Transient);

        AutoMapperConfig.AddAutoMapperConfiguration(services);

        DependencyInjectionConfig.AddDependencyInjectionConfiguration(services);

        _serviceProvider = services.BuildServiceProvider();
    }

    private static void DisposeServices()
    {
        if (_serviceProvider == null)
        {
            return;
        }
        if (_serviceProvider is IDisposable)
        {
            ((IDisposable)_serviceProvider).Dispose();
        }
    }

    private static async Task CallServices()
    {
        // Create user view model object
        var userViewModel = CreateUserViewModel();

        // Create User
        await _serviceProvider.GetService<IUserController>().Create(userViewModel);
        await _serviceProvider.GetService<IUserController>().Index();

        // Update User
        userViewModel = _serviceProvider.GetService<IUserController>().Get(1).Result;
        userViewModel.Age = 21;
        userViewModel.Emails.Add(new UserEmailViewModel { EmailAddress = "james.wilson_33.@hotmail.com" });
        await _serviceProvider.GetService<IUserController>().Edit(userViewModel);
        await _serviceProvider.GetService<IUserController>().Index();

        // Details User
        await _serviceProvider.GetService<IUserController>().Details(userViewModel.Id);

        // Delete User
        await _serviceProvider.GetService<IUserController>().Delete(userViewModel.Id);
        await _serviceProvider.GetService<IUserController>().Index();
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
