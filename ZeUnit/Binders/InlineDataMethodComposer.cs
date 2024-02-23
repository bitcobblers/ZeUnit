// See https://aka.ms/new-console-template for more information


// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Binders;

public class InlineDataMethodComposer : IZeMethodBinder
{
    private readonly InlineDataAttribute attribute;
    private bool disposedValue;

    public InlineDataMethodComposer(ZeBinderAttribute attribute)
    {
        this.attribute = (InlineDataAttribute)attribute;
    }

    public IEnumerable<MethodBinderInfo> Get(MethodInfo method)
    {
        yield return new("Inline", attribute.Args);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
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
