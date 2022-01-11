namespace ZeUnit.Demo.AsyncTests
{
    public class AsyncTaskTests
    {
        public async Task<ZeResult> AsyncTestRun()
        {
            return Ze.Assert()
                .IsEqual(1, 1);
        }
    }
}
