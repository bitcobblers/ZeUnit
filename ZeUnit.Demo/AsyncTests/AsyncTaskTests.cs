namespace ZeUnit.Demo.AsyncTests
{
    public class AsyncTaskTests
    {
        public async Task<Ze> AsyncTestRun()
        {
            await Task.Delay(1000);
            return 1.Is(1);
        }
    }
}
