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
        var name = $"{test.Class.FullName}::{test.Method.Name}";
        return new TestCase(
                    name,
                    new Uri(Constants.ExecutorUri),
                    this.source)
        {
            CodeFilePath = "code file path",
            DisplayName = name,
            LineNumber = 1
        };
    }
}