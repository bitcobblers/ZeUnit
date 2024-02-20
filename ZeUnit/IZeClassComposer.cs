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
        throw new NotImplementedException();
    }
}

public class SingletonLifeCycleFactory : IZeLifeCycleFactory
{
    public ZeClassInstanceFactory GetFactory(IZeClassComposer zeClassComposer, TypeInfo typeInfo)
    {
        throw new NotImplementedException();
    }
}

public class OrderedLifeCycleFactory : IZeLifeCycleFactory
{
    public ZeClassInstanceFactory GetFactory(IZeClassComposer zeClassComposer, TypeInfo typeInfo)
    {
        throw new NotImplementedException();
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
