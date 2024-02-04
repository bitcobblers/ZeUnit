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

    public void DiscoverTests(IEnumerable<string> sources, IDiscoveryContext discoveryContext, IMessageLogger logger,
        ITestCaseDiscoverySink discoverySink)
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

    public void RunTests(IEnumerable<TestCase>? tests, IRunContext? runContext, IFrameworkHandle? frameworkHandle)
    {
        frameworkHandle!.SendMessage(TestMessageLevel.Informational, $"Running {tests!.Count()}");
        var sources = tests!.GroupBy(n => n.Source);
        var executionList = new List<Task>();
        var runner = new ZeRunner(testRunnerDiscovery.Runners());

        foreach (var source in sources)
        {
            var discovery = new ZeDiscovery(testRunnerDiscovery.SupportedTypes())
                .FromAssembly(source.Key);

            var classes = source.Select(n => (discovery.FirstOrDefault(z => z.Name == n.FullyQualifiedName), n))
                .GroupBy(pair => (pair.Item1?.Class, pair.Item1?.ClassActivator));

            foreach (var classPair in classes)
            {
                var (@class, composer) = classPair.Key;
                var lifeCycle = @class?
                    .GetCustomAttribute<ZeLifeCycleAttribute>() ?? (ZeLifeCycleAttribute)new TransientAttribute();

                var factory = lifeCycle.GetFactory(composer!, @class!);

                foreach (var (zeTest, testCase) in classPair)
                {
                    var result = new TestResult(testCase);
                    if (zeTest == null)
                    {
                        result.Duration = TimeSpan.Zero;
                        result.Outcome = TestOutcome.Skipped;
                        frameworkHandle.RecordResult(result);
                        frameworkHandle.RecordEnd(testCase, result.Outcome);
                        continue;
                    }

                    executionList.Add(runner.Run(zeTest, factory).Select(pair =>
                    {
                        var (zeTest, zeResult) = pair;
                        result.Duration = zeResult.Duration;
                        result.Outcome = zeResult.Any() && zeResult.All(x => x.Status == ZeStatus.Passed)
                            ? TestOutcome.Passed
                            : TestOutcome.Failed;
                        frameworkHandle.RecordResult(result);
                        frameworkHandle.RecordEnd(testCase, result.Outcome);
                        return zeResult;
                    }).ToTask());
                }
            }
        }

        Task.WhenAll(executionList).Wait();
    }

    public void RunTests(IEnumerable<string>? sources, IRunContext? runContext, IFrameworkHandle? frameworkHandle)
    {
        frameworkHandle!.SendMessage(TestMessageLevel.Informational, "Starting Tests");

        var testCases =
            (from source in sources
                let builder = new TestCaseBuilder(source)
                let discoverer = new ZeDiscovery(testRunnerDiscovery.SupportedTypes()).FromAssembly(source)
                from test in discoverer
                select builder.Build(test))
            .ToArray();

        RunTests(testCases, runContext!, frameworkHandle!);
    }

    public void Cancel()
    {

    }
}