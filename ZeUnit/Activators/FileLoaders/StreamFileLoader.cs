// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Activators;

public class StreamFileLoader : ZeTypeFileLoader<Stream>
{
    public override object Load(Type type, FileInfo file)
    {
        return (object)file.OpenRead();
    }
}
