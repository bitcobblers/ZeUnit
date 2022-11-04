namespace ZeUnit.Runner.VisualStudio;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

public class TestCaseBuilder
{
    private readonly string source;    
    public TestCaseBuilder(string source) 
    {
        this.source = source;
    }    

    public TestCase Build(ZeTest test)
    {
        var name = $"{test.Class.FullName}::{test.Method.Name}::{Guid.NewGuid()}";
        return new TestCase(
                    name,
                    new Uri(Constants.ExecutorUri),
                    this.source)
        {
            CodeFilePath = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName(),
            DisplayName = name,
            LineNumber = 1,
            LocalExtensionData = test
        };
    }
}