using System.Reflection;

namespace ZeUnit;


public class NoTestDiscovered
{
    public static MethodInfo TestHandler = typeof(NoTestDiscovered).GetMethod("ReportOnError")!;
    
    [Skip]
    public Fact ReportOnError(Exception ex)
    {
         return new Fact(ex)
            .Assert(new AssertError(ex));
    }
}


public class DiscoveryErrorLifecycleFactory : IZeClassFactory
{
    public MethodInfo GetHandler() => NoTestDiscovered.TestHandler;

    public object Get()
    {
        return new NoTestDiscovered();
    }

    public void Dispose()
    {
    }
}

public class TransientLifecycleFactory : IZeClassFactory
{
    private readonly ComposerClassFactory zeClassComposer;
    private readonly TypeInfo typeInfo;

    public TransientLifecycleFactory(TypeInfo typeInfo, ComposerClassFactory factory)
    {
        this.zeClassComposer = factory;
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
                var value = zeClassComposer.Get(arg);
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
