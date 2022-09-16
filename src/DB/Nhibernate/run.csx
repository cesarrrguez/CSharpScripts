#load "viewModels.csx"
#load "controllers.csx"
#load "configurations.csx"
#load "utils.csx"

#r "nuget: NHibernate, 5.3.9"
#r "nuget: FluentNHibernate, 3.1.0"
#r "nuget: System.Data.SQLite, 1.0.114.4"
#r "nuget: System.Data.SQLite.Core, 1.0.114.3"
#r "nuget: System.Data.SQLite.Linq, 1.0.114"
#r "nuget: AutoMapper, 10.0.0"
#r "nuget: Microsoft.Extensions.DependencyInjection, 3.1.0"
#r "nuget: AutoMapper.Extensions.Microsoft.DependencyInjection, 8.0.1"

using Microsoft.Extensions.DependencyInjection;

await App.RunAsync();

public static class App
{
    private static IServiceProvider _serviceProvider;

    public static async Task RunAsync()
    {
        ConfigureServices();

        await CallServicesAsync();

        DisposeServices();
    }

    private static void ConfigureServices()
    {
        var services = new ServiceCollection();

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
        var userViewModel = CreateUserViewModel();
        var userController = _serviceProvider.GetService<IUserController>();

        // Add
        await userController.AddAsync(userViewModel);
        userController.Index();

        // Update
        userViewModel = await userController.GetByIdAsync(1);
        userViewModel.Age = 21;
        userViewModel.Emails.Add(new UserEmailViewModel { EmailAddress = "james.wilson_33.@hotmail.com" });
        await userController.UpdateAsync(userViewModel);
        userController.Index();

        // Details
        await userController.DetailsAsync(userViewModel.Id);

        // Delete
        await userController.DeleteAsync(userViewModel.Id);
        userController.Index();
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
