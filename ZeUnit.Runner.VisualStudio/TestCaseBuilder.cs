namespace ZeUnit.Runner.VisualStudio;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;

public class TestCaseBuilder
{
    private readonly string source;    
    public TestCaseBuilder(string source) 
    {
        this.source = source;
    }    

    public TestCase Build(ZeTest test)
    {        
        return new TestCase(
                    test.Name,
                    new Uri(Constants.ExecutorUri),
                    this.source)
        {
            CodeFilePath = test.Class.FullName,
            DisplayName = test.Name,
            LineNumber = 1,
        };
    }
}