namespace ZeUnit.Runner.VisualStudio;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;

[ExtensionUri(Constants.ExecutorUri)]
public class VisualStudioZeUnitTestExecutor : ITestExecutor 
{    
    public void RunTests(IEnumerable<TestCase> tests, IRunContext runContext, IFrameworkHandle frameworkHandle)
    {
        frameworkHandle.SendMessage(TestMessageLevel.Informational, "test");
    }

    public void RunTests(IEnumerable<string> sources, IRunContext runContext, IFrameworkHandle frameworkHandle)
    {
        frameworkHandle.SendMessage(TestMessageLevel.Informational, "test");
    }

    public void Cancel()
    {

    }
}