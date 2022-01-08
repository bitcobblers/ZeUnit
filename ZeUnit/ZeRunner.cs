// See https://aka.ms/new-console-template for more information
namespace ZeUnit;

public class ZeRunner : IZeRunner
{
    public ZeResult? Run(ZeTest test)
    {
        var instance = test.Class.GetConstructor(Array.Empty<Type>()).Invoke(null);
        var parameters = test.Method.GetParameters();

        if (parameters.Length == 0)
        {
            return (ZeResult)test.Method.Invoke(instance, null);
        }

        throw new Exception("Not implemented yet.  Will attempt to populate the types from the container.");
    }
}