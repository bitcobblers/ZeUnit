namespace ZeUnit.Demo.SimpleTests;

public class SampleZeTestClass
{
    public ZeResult SimpleTestMethodThatPasses() 
    {            
        var result = 2 + 2;
        return result
            .Is(4)
            .IsType<int>();
    }

    //public ZeResult SimpleTestMethodThatFailes()
    //{
    //    var result = 2 + 2;
    //    return Ze.Is            
    //        .Equal(5, result);
    //}
}