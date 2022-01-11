namespace ZeUnit.Demo.InlineTests
{
    public class InlineInjectionTests
    {      
        [InlineData("test1", 1)]
        [InlineData("test2", 2)]
        public ZeResult InlineInjectionForMethodWorks(string method, int expected)
        {
            return Ze.Is
                .Equal($"test{expected}", method);
        }
    }
}
