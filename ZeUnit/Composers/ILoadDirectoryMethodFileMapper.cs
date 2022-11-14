using Microsoft.Extensions.FileProviders;

namespace ZeUnit.Composers;

public interface ILoadDirectoryMethodFileMapper
{
    IEnumerable<string[]> Bind(IDirectoryContents files, string[] extensions);
}
