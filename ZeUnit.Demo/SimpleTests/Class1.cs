using ZeUnit.Assertions;

namespace ZeUnit.Demo.SimpleTests;

public class SampleZeTestClass
{
    public ZeResult SimpleTestMethod() 
    {            
        var result = 2 + 2;
        return Ze.Assert()
            .IsType<int>(result)
            .IsEqual(4, result);
    }
}