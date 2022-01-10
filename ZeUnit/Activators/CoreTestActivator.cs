// See https://aka.ms/new-console-template for more information
namespace ZeUnit;


public class CoreTestActivator : IZeActivator
{
    public void Dispose()
    {        
    }

    public object Get(TypeInfo @class)
    {
        return Activator.CreateInstance(@class);
    }

    public IEnumerable<object[]> Get(MethodInfo method)
    {
        yield return new object[0];
    }    
}
