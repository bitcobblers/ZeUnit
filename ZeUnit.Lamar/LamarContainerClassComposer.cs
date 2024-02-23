// See https://aka.ms/new-console-template for more information

using ZeUnit.Composers;

namespace ZeUnit.Lamar;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class LamarContainerAttribute : ZeComposerAttribute<LamarContainerClassComposer>
{
    public LamarContainerAttribute() : this(typeof(ServiceRegistry))
    {
    }

    public LamarContainerAttribute(Type registry) : base()
    {
        if (!registry.IsAssignableTo(typeof(ServiceRegistry)))
        {
            throw new InvalidDataException("Lamar container must register a type of ServiceRegistry.");
        }

        this.Registry = registry;
    }

    public Type Registry { get; }
}


public class LamarContainerClassComposer : IZeClassComposer
{
    private readonly Container container;
    private bool disposedValue;

    public LamarContainerClassComposer(IEnumerable<ZeComposerAttribute> attributes)
    {
        this.container = new Container(new ServiceRegistry());
        foreach (var registryType in attributes
            .Where(n => n.GetType().IsAssignableTo(typeof(LamarContainerAttribute)))
            .Select(n => ((LamarContainerAttribute)n).Registry))
        {
            var registry = (ServiceRegistry)this.container.GetInstance(registryType);
            this.container.Configure(registry);
        }
    }

    public object? Get(Type @class)
    {
        return  this.container.GetInstance(@class);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                this.container.Dispose();
            }

            disposedValue = true;
        }
    }


    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}