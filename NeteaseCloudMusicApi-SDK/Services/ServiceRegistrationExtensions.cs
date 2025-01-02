using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceRegistrationExtensions
{
    public static void AddServicesFromFolder(this IServiceCollection services, Assembly assembly, string partialNamespace)
    {
        // Filter types by namespace containing the partial namespace
        var typesInNamespace = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.Namespace != null && t.Namespace.Contains(partialNamespace));

        foreach (var type in typesInNamespace)
        {
            var interfaceType = type.GetInterfaces().FirstOrDefault();
            if (interfaceType != null)
            {
                services.AddScoped(interfaceType, type);
                Console.WriteLine($"Registered: {interfaceType.Name} -> {type.Name}");
            }
        }
    }
}
