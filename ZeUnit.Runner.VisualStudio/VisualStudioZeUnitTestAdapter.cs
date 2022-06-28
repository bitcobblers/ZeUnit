namespace ZeUnit.Runner.VisualStudio;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using Microsoft.VisualStudio.TestWindow.Extensibility;
using Microsoft.VisualStudio.TestWindow.Extensibility.Model;
using System.ComponentModel;
using System.Composition;


public class TestContainer : ITestContainer
{
	public TestContainer(ITestContainerDiscoverer discoverer, string source)
	{
		this.Discoverer = discoverer;
		this.Source = source;
		this.CreatedTime = DateTime.Now;
	}

	public DateTime CreatedTime { get; private set; }

	public int CompareTo(ITestContainer other)
	{
		var otherContainer = other as TestContainer;
		if (otherContainer == null)
			return -1;

		if (this.Source != otherContainer.Source)
			return this.Source.CompareTo(otherContainer.Source);

		return this.CreatedTime.CompareTo(otherContainer.CreatedTime);
	}

	public IEnumerable<Guid> DebugEngines
	{
		get { return Enumerable.Empty<Guid>(); }
	}

	public IDeploymentData DeployAppContainer()
	{
		return null;
	}

	public ITestContainerDiscoverer Discoverer { get; private set; }

	public bool IsAppContainerTestContainer
	{
		get { return false; }
	}

	public ITestContainer Snapshot()
	{
		return this;
	}

    public string Source { get; private set; }

	public FrameworkVersion TargetFramework
	{
		get { return FrameworkVersion.None; }
	}

	public Architecture TargetPlatform
	{
		get { return Architecture.AnyCPU; }
	}
}


[FileExtension(".dll")]
[FileExtension(".exe")]
[ExtensionUri(ExecutorUri)]
[Category("managed")]
[DefaultExecutorUri(ExecutorUri)]
[Export(typeof(ITestDiscoverer))]
[Export(typeof(ITestExecutor))]
public class VisualStudioZeUnitTestAdapter : ITestDiscoverer, ITestExecutor
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

    public const string ExecutorUri = "executor://ZeUnit.Runner.VisualStudio.VisualStudioZeUnitTestAdapter";
    private readonly ZeTestRunnerDiscovery testRunnerDiscovery;

    public VisualStudioZeUnitTestAdapter()
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
                    new Uri(ExecutorUri),
                    source)
                {
                    CodeFilePath = "code file path",
                    DisplayName = name,
                    LineNumber = 1
                });
            }
        }
    }

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