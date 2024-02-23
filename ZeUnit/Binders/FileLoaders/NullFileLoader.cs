// See https://aka.ms/new-console-template for more information


// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Binders.FileLoaders;

public class NullFileLoader : IZeFileLoader
{
    public object Load(Type type, FileInfo file)
    {
        return null!;
    }

    public bool Match(Type type, FileInfo file) => true;
}
