using Autofac;

namespace ZeUnit.Demo.AutofacInjectionTests;

public class SimpleServiceInjectionModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<SimpleInjectedService>().As<ISimpleInjectedService>();
    }
}
