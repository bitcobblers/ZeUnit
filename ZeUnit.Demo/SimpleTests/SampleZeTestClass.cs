namespace ZeUnit.Demo.SimpleTests;

public class SampleZeTestClass
{
    public Fact SimpleTestMethodThatPasses() 
    {            
        var result = 2 + 2;
        return result
            .Is(4)
            .IsType<int>();
    }    

    public Fact UsingInplicitCasting() 
    {            
        var result = 2 + 2;
        return result == 4;
    }    

    
    public Fact UsingInplicitCastingCustomMessage() 
    {            
        var result = 2 + 2;
        return (result == 4, "2 + 2 should be 4");
    }    
}