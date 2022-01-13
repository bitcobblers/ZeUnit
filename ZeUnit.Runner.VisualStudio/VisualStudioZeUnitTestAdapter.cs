namespace ZeUnit.Runner.VisualStudio;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;

[FileExtension(".dll")]
[FileExtension(".exe")]
[DefaultExecutorUri(ExecutorUri)]
[ExtensionUri(ExecutorUri)]
public class VisualStudioZeUnitTestAdapter : ITestDiscoverer, ITestExecutor
{
    public const string ExecutorUri = "executor://ZeUnit.Runner.VisualStudio.VisualStudioZeUnitTestAdapter";
    private ZeTestRunnerDiscovery testRunnerDiscovery;

    public VisualStudioZeUnitTestAdapter()
    {
        this.testRunnerDiscovery = new DefaultTestRunnerDiscovery();        
    }    

    public void DiscoverTests(IEnumerable<string> sources, IDiscoveryContext discoveryContext, IMessageLogger logger, ITestCaseDiscoverySink discoverySink)
    {
        foreach (var source in sources)
        {
            var discovery = new ZeDiscovery(testRunnerDiscovery.SupportedTypes())
                .FromAssembly(source);

            foreach (var test in discovery)
            {
                discoverySink.SendTestCase(new TestCase(
                    $"{test.Class.FullName}::{test.Method.Name}",
                    new Uri(ExecutorUri),
                    source));
            }
        }
    }

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