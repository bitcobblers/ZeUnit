
namespace ZeUnit
{
    public interface IZeTestRunnerDiscovery
    {
        ZeTestRunner[] Runners();
        Type[] SupportedTypes();
    }
}