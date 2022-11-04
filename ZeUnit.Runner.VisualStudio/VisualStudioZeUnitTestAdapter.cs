namespace ZeUnit.Runner.VisualStudio;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Reflection;

[FileExtension(".dll")]
[FileExtension(".exe")]
[Category("managed")]
[DefaultExecutorUri(Constants.ExecutorUri)]
[ExtensionUri(Constants.ExecutorUri)]
//[ExtensionUri(Constants.ExecutorUri)]
public class VisualStudioZeUnitTestAdapter : ITestDiscoverer, ITestExecutor
{
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
            var testBuilder = new TestCaseBuilder(source);
            var discovery = new ZeDiscovery(testRunnerDiscovery.SupportedTypes())
                .FromAssembly(source);

            foreach (var test in discovery)
            {
                var msTest = testBuilder.Build(test);
                discoverySink.SendTestCase(msTest);
            }
        }
    }

    public void RunTests(IEnumerable<TestCase> tests, IRunContext runContext, IFrameworkHandle frameworkHandle)
    {
        frameworkHandle.SendMessage(TestMessageLevel.Informational, $"Running {tests.Count()}");
        
        var discovered = tests.Select(msTest => (msTest, (ZeTest)msTest.LocalExtensionData))
            .GroupBy(pair => (pair.Item2?.Class, pair.Item2?.ClassActivator), pair => pair);
        
        var executionList = new List<Task>();
        var runner = new ZeRunner(testRunnerDiscovery.Runners());

        foreach (var classActivation in discovered)
        {
            var (@class, composer) = classActivation.Key;
                        
            var lifeCycle = @class?
                .GetCustomAttribute<ZeLifeCycleAttribute>() ?? (ZeLifeCycleAttribute)new TransientAttribute();
            
            var factory = lifeCycle.GetFactory(composer, @class);
            foreach (var (testCase, test) in classActivation)
            {
                var result = new TestResult(testCase);
                if (test == null)
                {
                    result.Outcome = TestOutcome.Skipped;
                    frameworkHandle.RecordResult(result);
                    frameworkHandle.RecordEnd(testCase, result.Outcome);
                    continue;
                }

                executionList.Add(runner.Run(test, factory).Merge().Select(pair =>
                {
                    var (zeTest, zeResult) = pair;
                    result.Outcome = zeResult.Any() && zeResult.All(x => x.Status == ZeStatus.Passed) ? TestOutcome.Passed : TestOutcome.Failed;
                    frameworkHandle.RecordResult(result);
                    frameworkHandle.RecordEnd(testCase, result.Outcome);
                    return zeResult;
                }).ToTask());
            }        
            
        }

        Task.WhenAll(executionList).Wait();

    }

    public void RunTests(IEnumerable<string> sources, IRunContext runContext, IFrameworkHandle frameworkHandle)
    {
        frameworkHandle.SendMessage(TestMessageLevel.Informational, "Starting Tests");
        foreach (var source in sources)
        {
            var testBuilder = new TestCaseBuilder(source);

            

        }

    }
    public void Cancel()
    {

    }
}
