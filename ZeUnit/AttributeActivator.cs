// See https://aka.ms/new-console-template for more information
namespace ZeUnit;

public abstract class AttributeActivator : IZeActivator
{
    private List<Type> types = new List<Type>();

    protected void Register<TType>()
        where TType : ZeActivatorAttribute
    {
        this.types.Add(typeof(TType));
    }

    public object Get(TypeInfo @class)
    {
        var attributes = @class.GetCustomAttributes()
            .Where(n=>this.types.Contains(n.GetType()))
            .Select(n=>(ZeActivatorAttribute)n);

        return this.Get(@class, attributes);
    }

    protected abstract object Get(TypeInfo @class, IEnumerable<ZeActivatorAttribute> attributes);
    
    public IEnumerable<object[]> Get(MethodInfo method)
    {
        var attributes = method.GetCustomAttributes()
            .Where(n => this.types.Contains(n.GetType()))
            .Select(n => (ZeActivatorAttribute)n);

        return this.Get(method, attributes);
    }

    protected abstract IEnumerable<object[]> Get(MethodInfo method, IEnumerable<ZeActivatorAttribute> attributes);

    public void Dispose()
    {        
    }    
}
