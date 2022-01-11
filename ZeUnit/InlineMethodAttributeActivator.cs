// See https://aka.ms/new-console-template for more information
namespace ZeUnit;

public class InlineMethodAttributeActivator : IZeMethodActivator
{
    private readonly InlineDataAttribute attribute;
    private bool disposedValue;

    public InlineMethodAttributeActivator(ZeActivatorAttribute attribute)
    {
        this.attribute = (InlineDataAttribute)attribute;
    }    

    public IEnumerable<object[]> Get(MethodInfo method)
    {
        yield return this.attribute.Args;
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
