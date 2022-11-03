namespace ZeUnit;

public class ZeDiscovery : IEnumerable<ZeTest>
{
    private readonly List<ZeTest> tests = new();
    private List<Type> supportedTypes = new List<Type>();

    public ZeDiscovery(IEnumerable<Type> supportedTypes)
    {
        this.supportedTypes.AddRange(supportedTypes);
    }

    private readonly List<Func<Type, bool>> conditions = new()
    {
        (type) => type.Namespace != "ZeUnit",        
    };
    public ZeDiscovery FromAssemblies(Assembly[] sources)
    {
        foreach (var assembly in sources)
        {
            this.FromAssembly(assembly);
        }

        return this;
    }

    public ZeDiscovery Where(Func<Type, bool> selctor)
    {
        conditions.Add(selctor);
        return this;
    } 
    
    public ComposerClassFactory ClassFactory = new ComposerClassFactory();

    public ComposerMethodFactory MethodFactory = new ComposerMethodFactory();

    public ZeDiscovery FromAssembly(string source)
    {
;        return this.FromAssembly(Assembly.LoadFile(source));
    }

    public ZeDiscovery FromAssembly(Assembly source)
    {
        foreach(var method in source
            .GetTypes()
            .SelectMany(type => type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
            .Where(m => supportedTypes.Contains(m.ReturnType)))
        {
            var classType = method.DeclaringType.GetTypeInfo();
            var activators = this.ClassFactory.Get(classType);
            foreach (var activator in activators) 
            {
                foreach (var activation in this.MethodFactory.Get(method))
                {
                    tests.Add(new ZeTest()
                    {
                        Class = classType,
                        ClassActivator = activator,
                        Method = method,
                        MethdoActivator = activation,
                    });
                }
            }
        }

        return this;
    }    

    public IEnumerator<ZeTest> GetEnumerator() => tests
        .Where(test => conditions.Aggregate(true, (sum, n) => n(test.Class) && sum))
        .GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}