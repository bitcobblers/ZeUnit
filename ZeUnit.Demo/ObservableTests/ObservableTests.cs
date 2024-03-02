using System.Reactive.Linq;

namespace ZeUnit.Demo.ObservableTests
{
    public class SkippedTests
    {
        [Skip("Some Attribute Reason")]
        public Fact TestIsSkippedByAttribute()
        {
            return false;
        }

        public Fact TestIsSkippedByCode()
        {
            return Is.Skipped("Some Runtime Reason");
        }
    }

    public class ObservableTests
    {
        public IObservable<Fact> EnumerableTestRun()
        {
            return Observable.Interval(new TimeSpan(1000))
                .Take(5)
                .Select(i => i.Is(i));
        }
    }
}
