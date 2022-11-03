namespace ZeUnit.Runner.VisualStudio;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using System.Diagnostics;
using System.Reactive.Linq;

[ExtensionUri(Constants.ExecutorUri)]
public class VisualStudioZeUnitTestExecutor : ITestExecutor
{
    public void RunTests(IEnumerable<TestCase> tests, IRunContext runContext, IFrameworkHandle frameworkHandle)
    {
        frameworkHandle.SendMessage(TestMessageLevel.Informational, "Single Test");
        foreach (var test in tests)
        {
            var testResult = new TestResult(test)
            {
                Outcome = TestOutcome.Passed
            };

            frameworkHandle.RecordStart(testResult.TestCase);
            frameworkHandle.RecordResult(testResult);
            frameworkHandle.RecordEnd(testResult.TestCase, testResult.Outcome);
        }
    }

    public void RunTests(IEnumerable<string> sources, IRunContext runContext, IFrameworkHandle frameworkHandle)
    {
        frameworkHandle.SendMessage(TestMessageLevel.Informational, "Starting Tests");
        foreach (var source in sources)
        {
            var testBuilder = new TestCaseBuilder(source);

            Ze.Unit(new ZeBuilder()).Subscribe(pair =>
            {

                var (test, result) = pair;
                var testResult = new TestResult(testBuilder.Build(test))
                {
                    Outcome = result.All(x => x.Status == ZeStatus.Passed) ? TestOutcome.Passed : TestOutcome.Failed
                };
                
                frameworkHandle.RecordStart(testResult.TestCase);
                frameworkHandle.RecordResult(testResult);
                frameworkHandle.RecordEnd(testResult.TestCase, testResult.Outcome);

            });
            
        }
        
    }
    public void Cancel()
    {

    }
}