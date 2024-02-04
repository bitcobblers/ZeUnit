using Microsoft.Extensions.FileProviders;

namespace ZeUnit.Composers;

public class DirectoryExtensionFileMapFromBinding : DirectoryExtensionFileMap
{
    public DirectoryExtensionFileMapFromBinding(IFileInfo file, string[] extensions)
    {
        var match = extensions.FirstOrDefault(ex => file.Name.EndsWith(ex));
        if (match == null)
        {
            return;
        }
        
        this.FileName = file.PhysicalPath;
        this.MatchedExtension = match;
        this.GroupName = match == null || match == string.Empty
            ? this.FileName
            : file.Name.Replace(match, string.Empty);
    }
}
