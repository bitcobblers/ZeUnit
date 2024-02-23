using Microsoft.Extensions.FileProviders;

namespace ZeUnit.Binders;

public class LoadSingleFileFromDirectoryFileMapper : ILoadDirectoryMethodFileMapper
{
    public IEnumerable<string[]> Bind(IDirectoryContents files, string[] extensions)
    {
        if (extensions.Length == 0 || extensions.Length > 1)
        {
            // no methods to load directories against.
            // or more than one depedency.  // this shoudl be errors in the future.
            yield break;
        }
        var extension = extensions.First();
        foreach (var file in files)
        {
            if (string.IsNullOrEmpty(extension) || file.Name.EndsWith(extension))
            {
                yield return new[] { file.PhysicalPath };
            }
        }
    }
}
