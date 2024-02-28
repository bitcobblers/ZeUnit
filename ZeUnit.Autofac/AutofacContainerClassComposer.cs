// See https://aka.ms/new-console-template for more information

using Autofac;
using ZeUnit.Composers;

namespace ZeUnit.Autofac;

public class AutofacContainerClassComposer : IZeClassComposer
{
    private readonly IContainer container;
    private bool disposedValue;

    public AutofacContainerClassComposer(IEnumerable<ZeComposerAttribute> attributes)
    {
        var builder = new ContainerBuilder();
        foreach (var registryType in attributes
            .Where(n => n.GetType().IsAssignableTo(typeof(AutofacContainerAttribute)))
            .Select(n => ((AutofacContainerAttribute)n).Registry))
        {
            var registry = (Module)Activator.CreateInstance(registryType)!;
            builder.RegisterModule(registry);
        }
        container = builder.Build();
    }

    public object? Get(Type @class)
    {
        return container.Resolve(@class);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                container.Dispose();
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