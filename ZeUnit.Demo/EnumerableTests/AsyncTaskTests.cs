namespace ZeUnit.Demo.EnumerableTests
{
    public class EnumerableTests
    {
        public IEnumerable<ZeResult> EnumerableTestRun()
        {
            return Enumerable.Range(1, 5).Select(i => Ze.Is.Equal(i, i));
        }
    }
}
