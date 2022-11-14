namespace ZeUnit.Composers;

public class LoadDirectoryExtensionFilterBinder
{
    public LoadDirectoryExtensionFilterBinder(MethodInfo method)
    {
        this.Extensions = method.GetParameters()
            .Select(n => n.GetCustomAttributes(typeof(ExtensionFilterAttribute)))
            .Select(n => n.Cast<ExtensionFilterAttribute>().FirstOrDefault())
            .Select(n => n?.Filter ?? "")
            .ToArray();
    }

    public string[] Extensions { get; set; }
}
