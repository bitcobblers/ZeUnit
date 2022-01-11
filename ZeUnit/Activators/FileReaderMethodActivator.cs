// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Activators;

public class FileReaderMethodActivator : IZeMethodActivator
{
    private readonly LoadFileAttribute attribute;
    private bool disposedValue;
    private Func<FileInfo, object> defaultLoad = file => null;
    private Dictionary<Type, Func<FileInfo, object>> loaders = new()
    {
        [typeof(string)] = file => (object)file.OpenText().ReadToEnd(),
        [typeof(FileStream)] = file => (object)file.OpenRead(),
        [typeof(Stream)] = file => (object)file.OpenRead(),
        [typeof(byte[])] = file =>
        {
            using (var stream = file.OpenRead())
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
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
            .Select(pair => (loaders.ContainsKey(pair.Second) ? loaders[pair.Second] : defaultLoad)(pair.First))
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
