using Microsoft.Extensions.FileProviders;

namespace ZeUnit.Binders;

public class LoadFileGroupsFromDirectoryFileMapper : ILoadDirectoryMethodFileMapper
{
    public IEnumerable<string[]> Bind(IDirectoryContents files, string[] extensions)
    {
        if (extensions.Any(n => string.IsNullOrEmpty(n)))
        {
            // Groupsets requires each argument to define an extension.
            yield break;
        }

        var groups = files
            .Select(n => new DirectoryExtensionFileMapFromBinding(n, extensions))
            .GroupBy(n => n.GroupName);

        foreach (var group in groups)
        {
            var groupFiles = extensions
                .Select(n => group.FirstOrDefault(g => g.MatchedExtension == n))
                .Select(n => n?.FileName)
                .ToArray();

            if (groupFiles.Any(n => string.IsNullOrEmpty(n)))
            {
                continue;
            }

            yield return groupFiles!;
        }
    }
}
