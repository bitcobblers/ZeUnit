namespace ZeUnit;
public interface IZeLifecycle<TFactory> : IZeLifecycle
    where TFactory : IZeLifeCycleFactory
{
}
public interface IZeLifecycle
{
}

public abstract class SingletonLifeCycle : IZeLifecycle<SingletonLifeCycleFactory>
{
}
public abstract class OrderedLifeCycle : IZeLifecycle<OrderedLifeCycleFactory>
{
}

public class TransientLifeCycleFactory : IZeLifeCycleFactory
{
    public TransientLifeCycleFactory(IZeClassComposer zeClassComposer, TypeInfo typeInfo)
    {
    }

    public object Create()
    {
        return new();
    }
}

public class SingletonLifeCycleFactory : IZeLifeCycleFactory
{
    public SingletonLifeCycleFactory(IZeClassComposer zeClassComposer, TypeInfo typeInfo)
    {
    }

    public object Create()
    {
        return new();
    }
}

public class OrderedLifeCycleFactory : IZeLifeCycleFactory
{
    public OrderedLifeCycleFactory(IZeClassComposer zeClassComposer, TypeInfo typeInfo)
    {
    }

    public object Create()
    {
        return new();
    }
}

public interface IZeLifeCycleFactory
{
    object Create();
}


public interface IZeClassComposer : IDisposable
{
    object Get(TypeInfo @class);
}
