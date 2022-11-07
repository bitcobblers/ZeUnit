using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Timers;

namespace ZeUnit;

public class ZeRunner
{
    private readonly IEnumerable<ZeTestRunner> runners;    

    public ZeRunner(IEnumerable<ZeTestRunner> testRunners)
    {
        this.runners = testRunners;
    }

    public IObservable<(ZeTest, ZeResult)> Run(ZeTest test, ZeClassInstanceFactory factory)
    {
        // foreach (var arguments in test.MethdoActivator.Get(test.Method))

        var startTime = DateTime.Now;
        try
        {                
            var runner = runners.First(n => n.SupportType == test.Method.ReturnType);            
            return runner.Run(test, factory, test.Arguments()).Select(n =>
            {
                n.Item2.Duration = DateTime.Now - startTime;
                return n;
            });
        }
        catch (Exception ex)
        {                
            return new ZeTestException(test, ex).Select(n =>
            {
                n.Item2.Duration = DateTime.Now - startTime;
                return n;
            });
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
