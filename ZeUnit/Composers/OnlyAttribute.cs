namespace ZeUnit.Composers;


public interface IZeBuilderAttribute
{
    Type Type { get; }
    object Build();
}

public abstract class OnlyAttribute<TType, TAttribute> 
    : ZeComposerAttribute<SingletonComposer<TAttribute>>
    , IZeBuilderAttribute
    where TAttribute : OnlyAttribute<TType, TAttribute>
{
    public Type Type => typeof(TType);

    public object Build() => Compose()!;

    protected abstract TType Compose();
}

public class OnlyAttribute : OnlyAttribute<object, OnlyAttribute>, IZeBuilderAttribute
{
    public OnlyAttribute(Type @class) 
    {        
        this.Type = @class;     
    }

    public Type Type { get; }

    protected override object Compose()
    {
        try
        {
            return System.Activator.CreateInstance(Type)!;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }
}
