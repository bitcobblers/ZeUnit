namespace ZeUnit.Demo.AsyncTests
{
    public class AsyncTaskTests
    {
        public async Task<ZeResult> AsyncTestRun()
        {
            return Ze.Is.Equal(1, 1);
        }
    }
}
