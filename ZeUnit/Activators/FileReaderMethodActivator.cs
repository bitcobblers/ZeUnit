// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Activators;

public class FileReaderMethodActivator : IZeMethodActivator
{
    private readonly LoadFileAttribute attribute;
    private bool disposedValue;
    private List<IZeFileLoader> loaders = new()
    {
        new ByteArrayFileLoader(),
        new FileStreamFileLoader(),
        new StreamFileLoader(),
        new StringFileLoader(),
        new DeserializeXmlLoad(),
        new DeserializeJsonLoad(),
    };

    public FileReaderMethodActivator(ZeActivatorAttribute attribute)
    {
        this.attribute = (LoadFileAttribute)attribute;
    }

    public IEnumerable<object[]> Get(MethodInfo method)
    {
        var paramters = method.GetParameters()
            .Select(n=>n.ParameterType);

        yield return this.attribute.FileNames
            .Select(f => new FileInfo(f))
            .Zip(paramters)
            .Select(pair =>
            {
                var loader = loaders.FirstOrDefault(n => n.Match(pair.Second, pair.First), new NullFileLoader());
                return loader.Load(pair.Second, pair.First);
            })
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
