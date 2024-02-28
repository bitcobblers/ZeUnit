namespace ZeUnit.TestAdapter;

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
                    source)
        {
            CodeFilePath = test.Class!.FullName,
            DisplayName = test.Name,
            LineNumber = 1,
        };
    }
}