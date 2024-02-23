namespace ZeUnit;

public class OrderedLifecycleFactory : IZeClassFactory
{
    public OrderedLifecycleFactory(TypeInfo typeInfo)
    {
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public object Get()
    {
        throw new NotImplementedException();
    }
}
