using Microsoft.Extensions.FileProviders;

namespace ZeUnit.Binders;

public interface ILoadDirectoryMethodFileMapper
{
    IEnumerable<string[]> Bind(IDirectoryContents files, string[] extensions);
}
