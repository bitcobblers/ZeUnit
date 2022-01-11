namespace ZeUnit;

public abstract class TestRunner<TTYpe> : TestRunner
{
    public override Type SupportType => typeof(TTYpe);
}
