// See https://aka.ms/new-console-template for more information
namespace ZeUnit;

public interface IZeMethodBinder : IDisposable
{    
    IEnumerable<object[]> Get(MethodInfo method);
}
