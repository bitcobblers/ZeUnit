using FakeItEasy;
using ZeUnit.Autofac;
using ZeUnit.FakeItEasy;

namespace ZeUnit.Demo.AutofacInjectionTests;

[Fakes]
[AutofacContainer(typeof(SimpleServiceInjectionModule))]
public class AutofacInjectionZeTestClass(
    Func<ISimpleInjectedDependency, ISimpleInjectedService> factory, 
    Fake<ISimpleInjectedDependency> fake)
{    
    public Fact ConstructorInjectionTestMethodThatPasses()
    {
        fake.CallsTo(n => n.Value()).Returns("Fake");
        var instance = factory(fake.FakedObject);

        return instance.Test() == "Fake";

    }
}