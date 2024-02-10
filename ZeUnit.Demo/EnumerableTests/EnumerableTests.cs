namespace ZeUnit.Demo.EnumerableTests
{
    public class EnumerableTests
    {
        public IEnumerable<Ze> EnumerableTestRun()
        {
            return Enumerable.Range(1, 5).Select(i => i.Is(i));
        }
    }
}
