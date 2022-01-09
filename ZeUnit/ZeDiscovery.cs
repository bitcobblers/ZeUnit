namespace ZeUnit;

public class ZeDiscovery : IEnumerable<ZeTest>
{
    private readonly List<ZeTest> tests = new();
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

    public ZeDiscovery FromAssembly(Assembly source)
    {
        tests.AddRange(source.GetTypes()            
            .SelectMany(type => type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.ReturnType.Equals(typeof(ZeResult)))
                .Select(m => new ZeTest() { Class = type.GetTypeInfo(), Method = m })));

        return this;
    }    

    public IEnumerator<ZeTest> GetEnumerator() => tests
        .Where(test => conditions.Aggregate(true, (sum, n) => n(test.Class) && sum))
        .GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}