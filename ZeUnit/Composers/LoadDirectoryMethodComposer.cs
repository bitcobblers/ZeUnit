namespace ZeUnit.Composers;

public class LoadDirectoryMethodComposer : IZeMethodComposer
{
    private readonly LoadDirectoryAttribute attribute;
    private bool disposedValue;

    public LoadDirectoryMethodComposer(ZeComposerAttribute attribute)
    {
        this.attribute = (LoadDirectoryAttribute)attribute;
    }

    public IEnumerable<object[]> Get(MethodInfo method)
    {
        var result = new List<object[]>();
        var paramters = method.GetParameters()
            .Select(n => n.ParameterType);

        if (paramters.Count() != 1 && paramters.Count() != this.attribute.Extentions.Count()) {
            return result;
        }

        var directory = new DirectoryInfo(this.attribute.Directory);
        var files = directory.GetFiles().Select(n =>
        {
            var match = this.attribute.Extentions.FirstOrDefault(ex => n.Name.EndsWith(ex));
            return match == null || match == string.Empty 
                ? (n.Name, "", n)
                : (n.Name.Replace(match, string.Empty), match, n);
        }).GroupBy(n => n.Item1);
            
        foreach ( var fileSet in files) {
            if (fileSet.Count() == paramters.Count() && this.attribute.Extentions.All(a => fileSet.Any(f => f.Item2 == a)))
            {
                var fileNames = this.attribute.Extentions
                    .Select(n => fileSet.FirstOrDefault(f => f.Item2 == n))
                    .Where(n=>n.n != null)
                    .Select(n => n.n.FullName)
                    .ToArray();
                var fileCompose = new LoadFileMethodComposer(new LoadFileAttribute(fileNames));
                result.AddRange(fileCompose.Get(method));
            }                
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
