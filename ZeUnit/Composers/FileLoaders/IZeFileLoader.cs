// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Composers.FileLoaders;

public interface IZeFileLoader
{
    bool Match(Type type, FileInfo file);
    object Load(Type type, FileInfo file);
}
