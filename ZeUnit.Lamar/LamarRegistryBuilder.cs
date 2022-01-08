// See https://aka.ms/new-console-template for more information

using Lamar;

namespace ZeUnit.Lamar;

public class LamarRegistryBuilder
{
    private readonly IEnumerable<Type> registries;

    public LamarRegistryBuilder(IEnumerable<Type> registries)
    {
        this.registries = registries;
    }

    public IContainer Build(IContainer container)
    {
        foreach (var registryType in registries)
        {
            var registry = (ServiceRegistry)container.GetInstance(registryType);
            container.Configure(registry);
        }

        return container;
    }
}
