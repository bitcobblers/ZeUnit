// See https://aka.ms/new-console-template for more information
namespace ZeUnit;

public class ZeRunner<TActivator> : IZeRunner
    where TActivator : IZeTestActivator, IDisposable, new()
{
    public ZeResult? Run(ZeTest test)
    {
        try
        {
            using var activator = new TActivator();
            var instance = activator.Get(test.Class);
            return activator.Run(instance, test.Method);
        }
        catch (Exception ex)
        {
            return Ze.Assert().Assert(new Failed(ex.Message));
        }
    }
}