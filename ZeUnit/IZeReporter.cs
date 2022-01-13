// See https://aka.ms/new-console-template for more information

namespace ZeUnit;

public interface IZeReporter : IObserver<(ZeTest, ZeResult)>
{
}