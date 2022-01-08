// See https://aka.ms/new-console-template for more information

using ZeUnit;

public interface IZeReporter
{
    void Report(ZeTest test, ZeResult? result);
}