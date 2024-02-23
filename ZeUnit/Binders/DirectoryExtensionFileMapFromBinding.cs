using Microsoft.Extensions.FileProviders;

namespace ZeUnit.Binders;

public class DirectoryExtensionFileMapFromBinding : DirectoryExtensionFileMap
{
    public DirectoryExtensionFileMapFromBinding(IFileInfo file, string[] extensions)
    {
        var match = extensions.FirstOrDefault(ex => file.Name.EndsWith(ex));
        if (match == null)
        {
            return;
        }

        FileName = file.PhysicalPath;
        MatchedExtension = match;
        GroupName = match == null || match == string.Empty
            ? FileName
            : file.Name.Replace(match, string.Empty);
    }
}
