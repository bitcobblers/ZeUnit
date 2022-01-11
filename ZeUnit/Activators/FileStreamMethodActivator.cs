// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Activators;

public class FileTextMethodActivator : IZeMethodActivator
{
    private bool disposedValue;
    private LoadFileTextAttribute attribute;

    public FileTextMethodActivator(ZeActivatorAttribute attribute)
    {
        this.attribute = (LoadFileTextAttribute)attribute;
    }

    public IEnumerable<object[]> Get(MethodInfo method)
    {
        yield return this.attribute.FileNames
            .Select(f => new FileInfo(f))
            .Where(f => f.Exists)
            .Select(f => (object)f.OpenText().ReadToEnd())
            .ToArray();        
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

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~FileTextMethodActivator()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    
}

public class FileStreamMethodActivator : IZeMethodActivator
{
    private readonly LoadFileStreamAttribute attribute;
    private bool disposedValue;

    public FileStreamMethodActivator(ZeActivatorAttribute attribute)
    {
        this.attribute = (LoadFileStreamAttribute)attribute;
    }

    public IEnumerable<object[]> Get(MethodInfo method)
    {
        yield return this.attribute.FileNames
            .Select(f => new FileInfo(f))
            .Where(f=> f.Exists)        
            .Select(f => (object)f.OpenRead())
            .ToArray();                    
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
