#load "entities.csx"

#r "nuget: Microsoft.Extensions.Configuration, 3.1.0"
#r "nuget: Microsoft.Extensions.Configuration.Json, 3.1.0"
#r "nuget: Microsoft.Extensions.Configuration.Binder, 3.1.0"

using Microsoft.Extensions.Configuration;

var path = Path.Combine(Directory.GetCurrentDirectory(), "Configuration");
var configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

var appConfig = configuration.GetSection("application").Get<AppConfig>();

Console.WriteLine($"Application Name: {appConfig.Name}");
Console.WriteLine($"Application Version: {appConfig.Version}");
