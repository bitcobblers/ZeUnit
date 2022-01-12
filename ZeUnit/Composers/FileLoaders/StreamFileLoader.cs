// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Composers.FileLoaders;

public class StreamFileLoader : ZeTypeFileLoader<Stream>
{
    public override object Load(Type type, FileInfo file)
    {
        return file.OpenRead();
    }
}
