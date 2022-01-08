// See https://aka.ms/new-console-template for more information
namespace ZeUnit
{
    public interface IZeRunner
    {
        ZeResult? Run(ZeTest test);
    }
}