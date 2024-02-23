using ZeUnit.Composers;

namespace ZeUnit;
public interface IZeLifecycle<TFactory> : IZeLifecycle
    where TFactory : IZeClassFactory
{
}
public interface IZeLifecycle
{
}

public interface IOrderedLifeCycle : IZeLifecycle<OrderedLifecycleFactory>
{
}


public interface ITransientLifeCycle : IZeLifecycle<TransientLifecycleFactory>
{
}

public interface IZeDependency
{

}
public class OrderedLifecycleFactory : IZeClassFactory
{
    public OrderedLifecycleFactory(IZeClassComposer[] zeClassComposer, TypeInfo typeInfo)
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


public class TransientLifecycleFactory : IZeClassFactory, IZeDependency
{
    private readonly IZeClassComposer[] zeClassComposer;
    private readonly TypeInfo typeInfo;

    public TransientLifecycleFactory(IZeClassComposer[] zeClassComposer, TypeInfo typeInfo)
    {
        this.zeClassComposer = zeClassComposer;
        this.typeInfo = typeInfo;
    }
    
    public object Get()
    {
        var constructors = typeInfo.GetConstructors()
            .Select(n =>new { ConstructorInfo = n, Args = n.GetParameters() })
            .OrderBy(n => n.Args.Length);
        foreach(var constuctor in constructors)
        {
            var values = new List<object>();
            foreach (var arg in constuctor.Args)
            {
                var value = zeClassComposer
                    .Select(n=>n.Get(arg.ParameterType))
                    .FirstOrDefault();
                
                if (value == null)
                {
                    break;
                }

                values.Add(value);
            }
            if (values.Count == constuctor.Args.Length)
            {
                if (constuctor.Args.Length == 0)
                {
                    return constuctor.ConstructorInfo.Invoke(null);                    
                }

                if (constuctor.Args.Length == 1 && typeof(IEnumerable).IsAssignableFrom(values.First().GetType()))
                {
                    return constuctor.ConstructorInfo.Invoke(new[] { values.ToArray() });                    
                }

                return constuctor.ConstructorInfo.Invoke(values.ToArray());           
            }
        }
        
        return Activator.CreateInstance(typeInfo)!;
    }
    public void Dispose()
    {
    }

}

public interface IZeClassFactory : IDisposable
{
    object Get();
}

public interface IZeClassComposer : IDisposable
{
    object? Get(Type args);
}
