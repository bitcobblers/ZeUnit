namespace ZeUnit.Demo.AsyncTests
{
    public class AsyncTaskTests
    {
        public async Task<ZeResult> AsyncTestRun()
        {
            await Task.Delay(1000);
            return Ze.Is.Equal(1, 1);
        }
    }
}
