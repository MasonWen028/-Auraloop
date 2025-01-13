using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceRegistrationExtensions
{
    public static void RegisterServices(this IServiceCollection services, Assembly assembly)
    {
        // Get all types from the specified assembly
        var types = assembly.GetTypes();

        // Find all interfaces and their corresponding concrete implementations
        foreach (var type in types)
        {
            if (type.IsInterface && type.Name.StartsWith("I") && !type.IsGenericType)
            {
                // Try to find the corresponding implementation (e.g., IAlbumService -> AlbumService)
                var implementation = types.FirstOrDefault(t => !t.IsInterface && !t.IsAbstract && t.Name == type.Name.Substring(1));
                if (implementation != null)
                {
                    // Register the service as scoped
                    services.AddScoped(type, implementation);
                }
            }
        }
    }
}
