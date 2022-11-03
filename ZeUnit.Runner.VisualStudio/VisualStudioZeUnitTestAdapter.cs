namespace ZeUnit.Runner.VisualStudio;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using System.ComponentModel;

[FileExtension(".dll")]
[FileExtension(".exe")]
[Category("managed")]
[DefaultExecutorUri(Constants.ExecutorUri)]
//[ExtensionUri(Constants.ExecutorUri)]
public class VisualStudioZeUnitTestDiscoverer : ITestDiscoverer
{
    // https://github.com/Microsoft/vstest-docs/blob/main/RFCs/0004-Adapter-Extensibility.md
    //  https://github.com/xunit/visualstudio.xunit
    //


    // Last place i left off:
    //  - https://blog.dantup.com/2014/02/some-things-i-learned-while-building-my-visual-studio-test-adapter/
    //  - https://github.com/DanTup/TestAdapters/blob/master/DanTup.TestAdapters.Jasmine.Vsix/DanTup.TestAdapters.Jasmine.Vsix.csproj
    //  - https://stackoverflow.com/questions/24811460/can-i-not-debug-the-itestexecutor-methods-in-a-unit-test-adapter
    //  - https://stackoverflow.com/questions/21646104/how-do-i-get-visual-studios-test-window-to-use-my-itestcontainerdiscoverer

    // Test Command
    //   - vstest.console.exe /testadapterpath:"C:\Dev\ZeUnit\ZeUnit.Runner.VisualStudio\bin\Debug\net6.0" "C:\Dev\ZeUnit\ZeUnit.Demo\bin\Debug\net6.0\ZeUnit.Demo.dll"
    // No test is available in C:\Dev\ZeUnit\ZeUnit.Demo\bin\Debug\net6.0\ZeUnit.Demo.dll. Make sure that test discoverer & executors are registered and platform & framework version settings are appropriate and try again.
    private readonly ZeTestRunnerDiscovery testRunnerDiscovery;

    public VisualStudioZeUnitTestDiscoverer()
    {
       this.testRunnerDiscovery = new DefaultTestRunnerDiscovery();
    }

    public void DiscoverTests(IEnumerable<string> sources, IDiscoveryContext discoveryContext, IMessageLogger logger, ITestCaseDiscoverySink discoverySink)
    {
        logger.SendMessage(TestMessageLevel.Informational, "Attempting Discovery");
        foreach (var source in sources)
        {
            var discovery = new ZeDiscovery(testRunnerDiscovery.SupportedTypes())
                .FromAssembly(source);

            foreach (var test in discovery)
            {
                var name = $"{test.Class.FullName}::{test.Method.Name}";
                discoverySink.SendTestCase(new TestCase(
                    name,
                    new Uri(Constants.ExecutorUri),
                    source)
                {
                    CodeFilePath = "code file path",
                    DisplayName = name,
                    LineNumber = 1
                });
            }
        }
    }
}
