namespace ZeUnit;

public class ZeRunner : IZeRunner
{
    public IEnumerable<ZeResult> Run(ZeTest test)
    {        
         var instance = test.ClassActivator.Get(test.Class);        
        foreach (var arguments in test.MethdoActivator.Get(test.Method))
        {
            var result = Ze.Assert();
            try
            {
                result = (ZeResult)test.Method.Invoke(instance, arguments.Any() ? arguments : null);
            }
            catch (Exception ex)
            {
                result.Assert(new Failed(ex.Message));
            }

            yield return result;
        }
    }
}