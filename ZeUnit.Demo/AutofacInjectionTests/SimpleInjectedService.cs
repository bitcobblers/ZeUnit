namespace ZeUnit.Demo.AutofacInjectionTests;

public interface ISimpleInjectedDependency
{
    string Value();
}

public class SimpleInjectedService(ISimpleInjectedDependency dependency) : ISimpleInjectedService
{   
    public string Test() => dependency.Value();
}
