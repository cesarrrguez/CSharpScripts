#load "settings.csx"
#load "interfaces.csx"
#load "controllers.csx"
#load "services.csx"

using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

public static class IoC
{
    public static void RegisterServices(IServiceCollection services)
    {
        // UI
        services.AddScoped<IPostController, PostController>();

        // Application
        services.AddScoped<IPostService, PostService>();

        // Infrastructure - Data
        services.AddSingleton<IGraphQLSettings>(sp =>
           sp.GetRequiredService<IOptions<GraphQLSettings>>().Value);

        services.AddScoped<IGraphQLClient>(sp =>
            new GraphQLHttpClient(sp.GetRequiredService<IGraphQLSettings>().EndPointUrl, new NewtonsoftJsonSerializer()));
    }
}
