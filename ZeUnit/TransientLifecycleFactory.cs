namespace ZeUnit;

public class TransientLifecycleFactory : IZeClassFactory
{
    private readonly ComposerClassFactory zeClassComposer;
    private readonly TypeInfo typeInfo;

    public TransientLifecycleFactory(TypeInfo typeInfo)
    {
        this.zeClassComposer = new ComposerClassFactory(typeInfo);
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
