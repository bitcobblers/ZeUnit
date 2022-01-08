// See https://aka.ms/new-console-template for more information
namespace ZeUnit;

public class ZeRunner : IZeRunner
{
    public ZeResult? Run(ZeTest test)
    {        
        var container = new Container(new ServiceRegistry());
        var loaders = test.Class.GetCustomAttributes<ZeLoaderAttribute>();
        var inputs = test.Method.GetCustomAttributes<ZeInputsAttribute>();

        foreach (var loaderType in loaders.Select(l => l.Loader).Concat(inputs.SelectMany(l => l.Loaders)))
        {
            var loader = (ZeContainerLoader)container.GetInstance(loaderType);
            foreach (var registry in loader.Registration())
            {
                container.Configure(registry);
            }            
        }
        try
        {
            var instance = container.GetInstance(test.Class);
            var parameters = test.Method.GetParameters().Select(n => container.GetInstance(n.ParameterType)).ToArray();

            return (ZeResult)test.Method.Invoke(instance, parameters.Length == 0 ? null : parameters);
        }
        catch (Exception ex)
        {
            return Ze.Assert().Assert(new Failed(ex.Message));
        }
    }
}