// See https://aka.ms/new-console-template for more information

using Lamar;
using System.Reflection;

namespace ZeUnit.Lamar;



public class LamarTestActivator : IZeTestActivator, IDisposable
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

    public ZeResult Run(object instance, MethodInfo method)
    {
        var loaders = method.GetCustomAttributes<LamarContainerAttribute>().Select(n => n.Registry);
        _ = new LamarRegistryBuilder(loaders).Build(this.container);
        
        var parameters = method.GetParameters()
            .Select(n => this.container.GetInstance(n.ParameterType))
            .ToArray();
        
        return (ZeResult)method.Invoke(instance, parameters.Length == 0 ? null : parameters);
    }    
}
