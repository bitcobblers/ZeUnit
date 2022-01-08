// See https://aka.ms/new-console-template for more information
namespace ZeUnit;

public class CoreTestActivator : IZeTestActivator, IDisposable
{    
    public object Get(TypeInfo @class)
    {
        return Activator.CreateInstance(@class);
    }

    public ZeResult Run(object instance, MethodInfo method)
    {
        return (ZeResult) method.Invoke(instance, null);
    }

    public void Dispose()
    {
    }
}
