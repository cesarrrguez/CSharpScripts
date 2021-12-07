#load "entities.csx"
#load "utils.csx"

#r "nuget: Microsoft.Extensions.Configuration, 5.0.0"
#r "nuget: Microsoft.Extensions.Configuration.Json, 5.0.0"
#r "nuget: Microsoft.Extensions.Configuration.Binder, 5.0.0"

using Microsoft.Extensions.Configuration;

IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(FolderUtil.GetCurrentDirectoryName())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration configuration = builder.Build();

AppConfig appConfig = configuration.GetSection("application").Get<AppConfig>();

WriteLine($"Application Name: {appConfig.Name}");
WriteLine($"Application Version: {appConfig.Version}");
