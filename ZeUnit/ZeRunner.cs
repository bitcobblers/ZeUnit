using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ZeUnit;

public class ZeRunner
{
    private readonly List<ObservableRunner> runners = new List<ObservableRunner>()
    {
        new ObservableResultRunner(),
        new TaskResultRunner(),
        new EnumerableResultRunner(),
        new SingleResultRunner(),
    };
    private IObserver<(ZeTest, ZeResult)> subject;

    public ZeRunner(IObserver<(ZeTest, ZeResult)> subject)
    {
        this.subject = subject;
    }

    public void Run(ZeTest test)
    {                       
        var instance = test.ClassActivator.Get(test.Class);               
        foreach (var arguments in test.MethdoActivator.Get(test.Method))
        {            
            var runner = runners.First(n => n.SupportType == test.Method.ReturnType);
            try
            {
                runner.Run(this.subject, test, instance, arguments);
            }
            catch (Exception ex)
            {
                this.subject.OnNext((test, Ze.Assert().Assert(new Failed(ex.Message))));
            }            
        }               
    }
}