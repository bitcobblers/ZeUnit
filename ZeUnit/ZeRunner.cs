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

    public IObservable<(ZeTest, Fact)> Run(ZeTest test, ZeClassInstanceFactory factory)
    {
        // foreach (var arguments in test.MethdoActivator.Get(test.Method))

        var startTime = DateTime.Now;
        try
        {                
            var runner = runners.First(n => n.SupportType == test.Method!.ReturnType);            
            return runner.Run(test, factory, test.Arguments?.Invoke() ?? new object[0]).Select(n =>
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

public class ZeTestException : IObservable<(ZeTest, Fact)>
{
    private ZeTest test;
    private Exception ex;

    public ZeTestException(ZeTest test, Exception ex)
    {
        this.test = test;
        this.ex = ex;
    }

    public IDisposable Subscribe(IObserver<(ZeTest, Fact)> observer)
    {
        var errorResult = new Fact(null!)
                    .Assert(new AssertError(ex));
        var errorSubject = new AsyncSubject<(ZeTest, Fact)>();
        errorSubject.OnNext((test, errorResult));
        errorSubject.OnCompleted();
        return errorSubject.Subscribe(observer);
    }
}
