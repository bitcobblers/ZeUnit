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
    public ZeClassInstanceFactory GetFactory(IZeClassComposer zeClassComposer, TypeInfo typeInfo)
    {
        return new TransientInstaceFactory();
    }
}

public class SingletonLifeCycleFactory : IZeLifeCycleFactory
{
    public ZeClassInstanceFactory GetFactory(IZeClassComposer zeClassComposer, TypeInfo typeInfo)
    {
        return new TransientInstaceFactory();
    }
}

public class OrderedLifeCycleFactory : IZeLifeCycleFactory
{
    public ZeClassInstanceFactory GetFactory(IZeClassComposer zeClassComposer, TypeInfo typeInfo)
    {
        return new TransientInstaceFactory();
    }
}

public interface IZeLifeCycleFactory
{
    ZeClassInstanceFactory GetFactory(IZeClassComposer zeClassComposer, TypeInfo typeInfo);
}


public interface IZeClassComposer : IDisposable
{
    object Get(TypeInfo @class);
}
