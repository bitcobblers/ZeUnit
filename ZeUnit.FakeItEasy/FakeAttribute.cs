namespace ZeUnit.FakeItEasy;

public class FakeAttribute<TType> 
    : ZeComposerAttribute<FakeClassComposer<TType>>
    where TType : class
{

}
