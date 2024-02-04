// See https://aka.ms/new-console-template for more information

using System.Text.Json.Nodes;

namespace ZeUnit.Composers.FileLoaders;

public class JsonObjectFileLoader : ZeTypeFileLoader<JsonObject>
{
    public override object Load(Type type, FileInfo file)
    {
        return JsonObject.Parse(file.OpenText()?.ReadToEnd() ?? "{}")!;
    }
}
