#load "entities.csx"
#load "utils.csx"

#r "nuget: Microsoft.Extensions.Configuration, 3.1.0"
#r "nuget: Microsoft.Extensions.Configuration.Json, 3.1.0"
#r "nuget: Microsoft.Extensions.Configuration.Binder, 3.1.0"

using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
                .SetBasePath(FolderUtil.GetCurrentDirectoryName())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

var appConfig = configuration.GetSection("application").Get<AppConfig>();

WriteLine($"Application Name: {appConfig.Name}");
WriteLine($"Application Version: {appConfig.Version}");
