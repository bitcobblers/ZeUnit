// See https://aka.ms/new-console-template for more information
namespace ZeUnit;

public class ZeRunner : IZeRunner
{
    public IEnumerable<ZeResult> Run(ZeTest test)
    {
        using var activator = ClassActivatorFactory.Get(test.Class);
        var instance = activator.Get(test.Class);
        foreach (var methodActivator in MethodActivatorFactory.Get(test.Method))
        {
            var result = Ze.Assert();
            try
            {
                result = methodActivator.Run(instance, test.Method);
            }
            catch (Exception ex)
            {
                result.Assert(new Failed(ex.Message));
            }

            yield return result;
        }
    }
}