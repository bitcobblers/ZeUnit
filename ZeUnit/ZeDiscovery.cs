using System.Net.Http.Headers;
using ZeUnit.Composers;

namespace ZeUnit;

public class ZeDiscovery : IEnumerable<ZeTest>
{
    private readonly List<ZeTest> tests = new();
    private readonly List<Type> supportedTypes = new List<Type>();

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

    public ZeDiscovery Where(Func<Type, bool> selector)
    {
        conditions.Add(selector);
        return this;
    }

    public ComposerMethodFactory MethodFactory = new ComposerMethodFactory();

    public ZeDiscovery FromAssembly(string source)
    {
        ; return this.FromAssembly(Assembly.LoadFile(source));
    }

    public ZeDiscovery FromAssembly(Assembly source)
    {
        foreach (var method in source
            .GetTypes()
            .SelectMany(type => (type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
            .Where(m => supportedTypes.Contains(m.ReturnType)))
            .Where(m => m.GetCustomAttributes().All(a => a?.GetType() != typeof(SkipAttribute))))
        {
            var classType = method.DeclaringType!.GetTypeInfo();
            var lifecycle = classType.GetInterfaces()
                .Where(n => n.IsAssignableFrom(typeof(IZeLifecycle<>)))
                .Select(n => n.GenericTypeArguments[0])
                .FirstOrDefault();
            var factory = lifecycle != null 
                ? (IZeClassFactory)Activator.CreateInstance(lifecycle)! 
                : new TransientLifecycleFactory(classType);

            var tracker = new IndexTracker();
            var composers = this.MethodFactory.Get(method);
            var methodActivations = composers.SelectMany(n => n.Get(method).Select(a => (n.GetType().Name, a)));
            foreach (var activation in methodActivations)
            {
                var index = tracker.IndexFor(classType.Name, method.Name);
                tests.Add(new ZeTest()
                {
                    Name = $"{classType.FullName}::{method.Name}::{activation.Name}::{activation.a.Key}::{index}",
                    Class = classType,
                    ClassFactory = factory,
                    Method = method,
                    Arguments = () => activation.a.Arguments,
                });
            }
        }

        return this;
    }

    public IEnumerator<ZeTest> GetEnumerator() => tests
        .Where(test => conditions.Aggregate(true, (sum, n) => n(test.Class!) && sum))
        .GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}

public class IndexTracker : Dictionary<string, int>
{
    public int IndexFor(string className, string methodName)
    {
        var key = $"{className}::{methodName}";
        if (!this.ContainsKey(key))
        {
            this[key] = 0;
        }

        return ++this[key];
    }
}
