using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ZeUnit;

public class ZeRunner
{
    private readonly IEnumerable<ZeTestRunner> runners;    

    public ZeRunner(IEnumerable<ZeTestRunner> testRunners)
    {
        this.runners = testRunners;
    }

    public IEnumerable<IObservable<(ZeTest, ZeResult)>> Run(ZeTest test, ZeClassInstanceFactory factory)
    {                               
        foreach (var arguments in test.MethdoActivator.Get(test.Method))
        {
            IObservable<(ZeTest, ZeResult)> result;
            try
            {
                var instance = factory.Create();
                var runner = runners.First(n => n.SupportType == test.Method.ReturnType);
                result = runner.Run(test, instance, arguments);
            }
            catch (Exception ex)
            {                
                result = new ZeTestException(test, ex); 
            }
            yield return result;
        }               
    }
}

public class ZeTestException : IObservable<(ZeTest, ZeResult)>
{
    private ZeTest test;
    private Exception ex;

    public ZeTestException(ZeTest test, Exception ex)
    {
        this.test = test;
        this.ex = ex;
    }

    public IDisposable Subscribe(IObserver<(ZeTest, ZeResult)> observer)
    {
        var errorResult = new ZeResult()
                    .Assert(new AssertError(ex));
        var errorSubject = new AsyncSubject<(ZeTest, ZeResult)>();
        errorSubject.OnNext((test, errorResult));
        errorSubject.OnCompleted();
        return errorSubject.Subscribe(observer);
    }
}
