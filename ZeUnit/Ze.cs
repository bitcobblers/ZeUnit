using System.Reactive.Subjects;

namespace ZeUnit;

public abstract class ZeActivatorAttribute : Attribute
{    
    protected ZeActivatorAttribute(Type type)
    {
        this.Activator = type;
    }

    public Type Activator { get; }    
}

public static class Ze
{
    public static ZeResult Assert()
    {
        return new ZeResult();
    }       

    public static void Unit(Func<ZeDiscovery, ZeDiscovery> config, params IZeReporter[] reporters)        
    {
        var subject = new Subject<(ZeTest, ZeResult)>();
        var testRunner = new ZeRunner(subject);
        var discovery = config(new ZeDiscovery());

        subject.Subscribe(n =>
        {
            foreach (var reporter in reporters)
            {
                reporter.Report(n.Item1, n.Item2);
            }
        });

        foreach (var test in discovery)
        {
            testRunner.Run(test);
        }
    }
}