namespace ZeUnit.Demo.InlineTests
{
    public class InlineInjectionTests
    {      
        [InlineData("test1", 1)]
        [InlineData("test2", 2)]
        public Fact InlineInjectionForMethodWorks(string method, int expected)
        {
            return $"test{expected}".Is(method);
        }
    }
}
