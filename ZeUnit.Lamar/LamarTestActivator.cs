// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Lamar;

public class LamarTestActivator : IZeActivator, IDisposable
{
    private readonly Container container;

    public LamarTestActivator()
    {
        container = new Container(new ServiceRegistry());
    }

    public void Dispose()
    {
        container.Dispose();
    }

    public object Get(TypeInfo @class)
    {
        var container = new Container(new ServiceRegistry());
        var loaders = @class.GetCustomAttributes<LamarContainerAttribute>().Select(n=>n.Registry);
        return new LamarRegistryBuilder(loaders).Build(container).GetInstance(@class);        
    }

    public IEnumerable<object[]>Get(MethodInfo method)
    {
        var loaders = method.GetCustomAttributes<LamarContainerAttribute>().Select(n => n.Registry);
        _ = new LamarRegistryBuilder(loaders).Build(this.container);
        yield return method.GetParameters()
            .Select(n => this.container.GetInstance(n.ParameterType))
            .ToArray();
    }    
}
