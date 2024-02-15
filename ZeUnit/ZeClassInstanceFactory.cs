namespace ZeUnit;

public class TransientInstaceFactory : ZeClassInstanceFactory
{
    public override object Create()
    {
        throw new NotImplementedException();
    }
}

public abstract class ZeClassInstanceFactory
{
    public abstract object Create();    
}
