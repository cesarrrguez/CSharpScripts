#load "../../../packages.csx"

#load "viewModels.csx"
#load "controllers.csx"
#load "configurations.csx"
#load "utils.csx"

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
