#load "entities.csx"

#r "nuget: Microsoft.Extensions.Configuration, 3.1.0"
#r "nuget: Microsoft.Extensions.Configuration.Json, 3.1.0"
#r "nuget: Microsoft.Extensions.Configuration.Binder, 3.1.0"

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Binder;

var rootPath = @"D:\Workspace\CSharpScripts\Configuration";

var configuration = new ConfigurationBuilder()
                .SetBasePath(rootPath)
                .AddJsonFile("appsettings.json", true, true)
                .Build();

var appConfig = configuration.GetSection("application").Get<AppConfig>();

Console.WriteLine($"Application Name: {appConfig.Name}");
Console.WriteLine($"Application Version: {appConfig.Version}");
