// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Composers.FileLoaders;

using System.Text.Json;

public class DeserializeJsonLoad : IZeFileLoader
{
    public bool Match(Type type, FileInfo file) => file.Extension.ToLower() == ".json";

    public object Load(Type type, FileInfo file)
    {
        var text = file.OpenText().ReadToEnd();
        return JsonSerializer.Deserialize(text, type, new JsonSerializerOptions());

    }
}
