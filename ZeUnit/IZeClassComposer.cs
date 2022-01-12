// See https://aka.ms/new-console-template for more information
namespace ZeUnit;

public interface IZeClassComposer : IDisposable
{
    object Get(TypeInfo @class);
}
