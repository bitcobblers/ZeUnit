namespace ZeUnit.Runner.VisualStudio;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;


[ExtensionUri(Constants.ExecutorUri)]
public class VisualStudioZeUnitExecutor : ITestExecutor
{
    public void RunTests(IEnumerable<TestCase> tests, IRunContext runContext, IFrameworkHandle frameworkHandle)
    {
        Console.WriteLine("test");

    }

    public void RunTests(IEnumerable<string> sources, IRunContext runContext, IFrameworkHandle frameworkHandle)
    {
        Console.WriteLine("test");
    }

    public void Cancel()
    {
        Console.WriteLine("test");
    }
}
