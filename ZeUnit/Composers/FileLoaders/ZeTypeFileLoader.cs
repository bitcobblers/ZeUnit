// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Composers.FileLoaders;

public abstract class ZeTypeFileLoader<TType> : IZeFileLoader
{
    public bool Match(Type type, FileInfo file) => type == typeof(TType);
    public abstract object Load(Type type, FileInfo file);
}
