var domain = AppDomain.CurrentDomain;

WriteLine("Domain name: {0}", domain.FriendlyName);
WriteLine("Domain process ID: {0}", domain.Id);
WriteLine("Domain base directory: {0}", domain.BaseDirectory);

// Default domain
if (domain.IsDefaultAppDomain())
    WriteLine("Is default domain");
else
    WriteLine("Is not default domain");

// Domain assemblies 
WriteLine("\nDomain assemblies:");
var assemblies = domain.GetAssemblies();

foreach (var item in assemblies)
    WriteLine("Name: {0}, Version: {1}", item.GetName().Name, item.GetName().Version);
