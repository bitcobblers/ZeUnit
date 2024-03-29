﻿using System.Reactive.Subjects;

namespace ZeUnit.TestRunners;

public class EnumerableTestRunner : ZeTestRunner<IEnumerable<Fact>>
{
    public override IObservable<(ZeTest, Fact)> Run(ZeTest test, IZeClassFactory factory, object[] arguments)
    {
        var instance = factory.Get();
        var subject = new AsyncSubject<(ZeTest, Fact)>();
        foreach (var result in (IEnumerable<Fact>)test.Method!.Invoke(instance, arguments.Any() ? arguments : null)!)
        {
            subject.OnNext((test, result));
        }
        subject.OnCompleted();
        return subject;
    }
}
