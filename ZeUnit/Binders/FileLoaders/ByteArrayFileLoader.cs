// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Binders.FileLoaders;

public class ByteArrayFileLoader : ZeTypeFileLoader<byte[]>
{
    public override object Load(Type type, FileInfo file)
    {
        using (var stream = file.OpenRead())
        using (var memoryStream = new MemoryStream())
        {
            stream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
