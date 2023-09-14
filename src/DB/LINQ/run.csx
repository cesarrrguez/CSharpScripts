#load "../../../packages.csx"

#load "data.csx"

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

App.Run();

public static class App
{
    public static void Run()
    {
        AppDbContext appDbContext = InitialiseDatabase();

        DbSet<Animal> animalsFromDb = appDbContext.Animals;
        List<Animal> animalsInList = new List<Animal>();

        List<Animal> filteredDbAnimals = animalsFromDb.Where(x => x.Name == "Dog").ToList();
        List<Animal> filteredListAnimals = animalsInList.Where(x => x.Name == "Dog").ToList();

        WriteLine($"{filteredDbAnimals.Count} animals in the Database");
        WriteLine($"{filteredListAnimals.Count} animals in the List");
    }

    private static AppDbContext InitialiseDatabase()
    {
        ServiceProvider services = new ServiceCollection()
            .AddDbContext<AppDbContext>()
            .BuildServiceProvider();

        return services.GetRequiredService<AppDbContext>();
    }
}
