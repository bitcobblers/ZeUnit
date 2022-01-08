namespace ZeUnit;

public class ZeDiscovery : IEnumerable<ZeTest>
{
    private List<ZeTest> tests = new List<ZeTest>();

    public ZeDiscovery FromAssemblies(Assembly[] sources)
    {
        foreach (var assembly in sources)
        {
            this.FromAssembly(assembly);
        }

        return this;
    }

    public ZeDiscovery FromAssembly(Assembly source)
    {
        tests.AddRange(source.GetTypes()
            .Where(type => type.Namespace != "ZeUnit")
            .SelectMany(type => type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.ReturnType.Equals(typeof(ZeResult)))
                .Select(m => new ZeTest() { Class = type.GetTypeInfo(), Method = m })));

        return this;
    }

    public IEnumerator<ZeTest> GetEnumerator() => tests.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => tests.GetEnumerator();
}