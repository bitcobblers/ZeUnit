// See https://aka.ms/new-console-template for more information
namespace ZeUnit;

public record MethodBinderInfo(string Key, object[] Arguments);
public interface IZeMethodBinder : IDisposable
{    
    IEnumerable<MethodBinderInfo> Get(MethodInfo method);
}
