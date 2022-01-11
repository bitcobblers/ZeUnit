//// See https://aka.ms/new-console-template for more information

//namespace ZeUnit.Lamar;

//public class LamarMethodActivator : ZeMethodAttributeActivator<LamarContainerAttribute>, IDisposable
//{
//    private readonly Container container;

//    public LamarMethodActivator()
//    {
//        container = new Container(new ServiceRegistry());
//    }
    
//    protected override IEnumerable<object[]> Get(MethodInfo method, IEnumerable<LamarContainerAttribute> attributes)
//    {
//        var loaders = attributes.Select(n => n.Registry);
//        _ = new LamarRegistryBuilder(loaders).Build(this.container);

//        yield return method.GetParameters()
//            .Select(n => this.container.GetInstance(n.ParameterType))
//            .ToArray();
//    }
//}
