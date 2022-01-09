// See https://aka.ms/new-console-template for more information
namespace ZeUnit
{
    public interface IZeRunner
    {
        IEnumerable<ZeResult> Run(ZeTest test);
    }
}