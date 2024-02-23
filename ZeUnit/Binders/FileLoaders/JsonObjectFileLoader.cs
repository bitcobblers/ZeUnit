// See https://aka.ms/new-console-template for more information

using System.Text.Json.Nodes;

namespace ZeUnit.Binders.FileLoaders;

public class JsonObjectFileLoader : ZeTypeFileLoader<JsonObject>
{
    public override object Load(Type type, FileInfo file)
    {
        return JsonNode.Parse(file.OpenText()?.ReadToEnd() ?? "{}")!;
    }
}
