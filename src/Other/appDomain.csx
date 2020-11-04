var domain = AppDomain.CurrentDomain;

Console.WriteLine("Domain name: {0}", domain.FriendlyName);
Console.WriteLine("Domain process ID: {0}", domain.Id);
Console.WriteLine("Domain base directory: {0}", domain.BaseDirectory);

// Default domain
if (domain.IsDefaultAppDomain())
    Console.WriteLine("Is default domain");
else
    Console.WriteLine("Is not default domain");

// Domain assemblies 
Console.WriteLine("\nDomain assemblies:");
var assemblies = domain.GetAssemblies();

foreach (var item in assemblies)
    Console.WriteLine("Name: {0}, Version: {1}", item.GetName().Name, item.GetName().Version);
