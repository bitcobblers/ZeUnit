using Microsoft.Extensions.FileProviders;

namespace ZeUnit.Binders;

public class LoadDirectoryMethodComposer<TFileMapper> : IZeMethodBinder
    where TFileMapper : ILoadDirectoryMethodFileMapper, new()
{
    private readonly string directory;
    private bool disposedValue;

    public LoadDirectoryMethodComposer(ZeBinderAttribute attribute)
    {
        directory = Path.GetFullPath(((ILoadFilesAttribute)attribute).Directory);
    }

    public IEnumerable<MethodBinderInfo> Get(MethodInfo method)
    {
        var result = new List<MethodBinderInfo>();
        var fileProvider = new PhysicalFileProvider(directory);
        var parsor = new TFileMapper();

        var args = new LoadDirectoryExtensionFilterBinder(method);
        var binders = parsor.Bind(fileProvider.GetDirectoryContents(string.Empty), args.Extensions);

        foreach (var fileSet in binders)
        {
            var fileCompose = new LoadFileMethodComposer(new LoadFileAttribute(fileSet));
            result.AddRange(fileCompose.Get(method));
        }

        return result;
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
