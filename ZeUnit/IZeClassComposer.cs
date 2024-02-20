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

public class TransientLifeCycleFactory : ZeLifeCycleFactory
{
    public TransientLifeCycleFactory(IZeClassComposer zeClassComposer, TypeInfo typeInfo) 
        : base(zeClassComposer, typeInfo)
    {
    }

    public override object Create()
    {
        return this.ZeClassComposer.Get(TypeInfo);
    }
}

public abstract class ZeLifeCycleFactory: IZeLifeCycleFactory
{
    protected ZeLifeCycleFactory(IZeClassComposer zeClassComposer, TypeInfo typeInfo)
    {
        ZeClassComposer = zeClassComposer;
        TypeInfo = typeInfo;
    }

    protected IZeClassComposer ZeClassComposer { get; }
    protected TypeInfo TypeInfo { get; }

    public abstract object Create();
}

public class SingletonLifeCycleFactory : ZeLifeCycleFactory
{
    public SingletonLifeCycleFactory(IZeClassComposer zeClassComposer, TypeInfo typeInfo) 
        : base(zeClassComposer, typeInfo)
    {
    }

    public override object Create()
    {
        return new();
    }
}

public class OrderedLifeCycleFactory : ZeLifeCycleFactory
{
    public OrderedLifeCycleFactory(IZeClassComposer zeClassComposer, TypeInfo typeInfo)
        : base(zeClassComposer, typeInfo)
    {
    }

    public override object Create()
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
