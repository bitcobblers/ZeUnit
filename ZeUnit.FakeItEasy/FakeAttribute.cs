namespace ZeUnit.FakeItEasy;

public class FakeAttribute<TType,TComposer> 
    : ZeComposerAttribute<FakeClassComposer<TType, TComposer>>
    where TComposer : IFakeComposer<TType>, new()
    where TType : class
{ 
}

public class FakeAttribute<TType> 
    : ZeComposerAttribute<FakeClassComposer<TType>>
    where TType : class
{
}