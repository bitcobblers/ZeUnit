﻿using System.Reactive.Subjects;

namespace ZeUnit.TestRunners;

public class ObjectTestRunner : ZeTestRunner<Fact>
{
    public override IObservable<(ZeTest, Fact)> Run(ZeTest test, IZeClassFactory factory, object[] arguments)
    {
        var instance = factory.Get();
        var subject = new AsyncSubject<(ZeTest, Fact)>();
        subject.OnNext((test, (Fact)test.Method!.Invoke(instance, arguments.Any() ? arguments : null)!));
        subject.OnCompleted();
        return subject;
    }
}
