namespace ZeUnit.Binders;

using ZeUnit.Binders.FileLoaders;

public class LoadFileMethodComposer : IZeMethodBinder
{
    private bool disposedValue;
    private readonly LoadFileAttribute attribute;
    private List<IZeFileLoader> loaders = new()
    {
        new StreamFileLoader(),
        new FileStreamFileLoader(),
        new ByteArrayFileLoader(),
        new StringFileLoader(),
        new XDocumentFileLoader(),
        new JsonObjectFileLoader(),
        new DeserializeXmlLoad(),
        new DeserializeJsonLoad(),
    };

    public LoadFileMethodComposer(ZeComposerAttribute attribute)
    {
        this.attribute = (LoadFileAttribute)attribute;
    }

    public IEnumerable<MethodBinderInfo> Get(MethodInfo method)
    {
        var parameters = method.GetParameters()
            .Select(n => n.ParameterType);

        yield return new("FileName:???", attribute.FileNames
            .Select(f => new FileInfo(f))
            .Zip(parameters)
            .Select(pair =>
            {
                var loader = loaders.FirstOrDefault(n => n.Match(pair.Second, pair.First), new NullFileLoader());
                return loader.Load(pair.Second, pair.First);
            })
            .ToArray());
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
