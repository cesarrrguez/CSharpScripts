#load "../../packages.csx"

#load "entities.csx"
#load "utils.csx"

using Microsoft.Extensions.Configuration;

IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(FolderUtil.GetCurrentDirectoryName())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration configuration = builder.Build();

AppConfig appConfig = configuration.GetSection("application").Get<AppConfig>();

WriteLine($"Application Name: {appConfig.Name}");
WriteLine($"Application Version: {appConfig.Version}");
