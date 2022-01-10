// See https://aka.ms/new-console-template for more information
namespace ZeUnit;

public interface IZeActivator : IDisposable
{
    object Get(TypeInfo @class);
    IEnumerable<object[]> Get(MethodInfo method);
}
