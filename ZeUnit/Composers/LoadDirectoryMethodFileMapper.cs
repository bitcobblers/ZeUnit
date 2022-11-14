using Microsoft.Extensions.FileProviders;

namespace ZeUnit.Composers;

public class LoadDirectoryMethodFileMapper
{
    public IEnumerable<string[]> Bind(MethodInfo method, IDirectoryContents files)
    {
        var args = new LoadDirectoryExtensionFilterBinder(method);
        if (args.Extensions.Length == 0 || (args.Extensions.Length > 1 && args.Extensions.Any(n=>string.IsNullOrEmpty(n))))
        {
            // no methods to load directories against.
            // or we have cases where the extensions are not defined.
            yield break;
        }

        var groups = files
            .Select(n => new DirectoryExtensionFileMapFromBinding(n, args.Extensions))
            .GroupBy(n => n.GroupName);

        foreach (var group in groups)
        {
            var groupFiles = args.Extensions
                .Select(n => group.FirstOrDefault(g => g.MatchedExtension == n))
                .Select(n=> n?.FileName)
                .ToArray()                ;

            if (groupFiles.Any(n => string.IsNullOrEmpty(n)))
            {
                continue;
            }

            yield return groupFiles;
        }
    }
}
