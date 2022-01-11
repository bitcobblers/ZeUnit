// See https://aka.ms/new-console-template for more information
namespace ZeUnit;

public interface IZeClassActivator : IDisposable
{
    object Get(TypeInfo @class);
}
