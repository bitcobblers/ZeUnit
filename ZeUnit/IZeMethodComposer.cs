// See https://aka.ms/new-console-template for more information
namespace ZeUnit;

public interface IZeMethodComposer : IDisposable
{    
    IEnumerable<object[]> Get(MethodInfo method);
}
