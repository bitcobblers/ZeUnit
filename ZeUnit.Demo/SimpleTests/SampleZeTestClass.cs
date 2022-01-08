using ZeUnit.Assertions;

namespace ZeUnit.Demo.SimpleTests;

public class SampleZeTestClass
{
    public ZeResult SimpleTestMethodThatPasses() 
    {            
        var result = 2 + 2;
        return Ze.Assert()
            .IsType<int>(result)
            .IsEqual(4, result);
    }

    public ZeResult SimpleTestMethodThatFailes()
    {
        var result = 2 + 2;
        return Ze.Assert()            
            .IsEqual(5, result);
    }
}