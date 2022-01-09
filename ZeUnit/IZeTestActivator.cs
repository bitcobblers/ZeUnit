// See https://aka.ms/new-console-template for more information
namespace ZeUnit;

public interface IZeTestActivator : IDisposable
{
    object Get(TypeInfo @class);
    ZeResult Run(object instance, MethodInfo method);
}
