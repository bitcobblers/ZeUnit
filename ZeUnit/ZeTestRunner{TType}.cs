namespace ZeUnit;

public abstract class ZeTestRunner<TType> : ZeTestRunner
{
    public override Type SupportType => typeof(TType);
}
