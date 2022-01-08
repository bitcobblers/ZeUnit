using System.Collections;

namespace ZeUnit
{
    public static class Ze
    {
        public static ZeResult Assert()
        {
            return new ZeResult();
        }
    }

    public class ZeResult : IEnumerable<ZeAssertion>
    {
        private List<ZeAssertion> assertions = new List<ZeAssertion>();        

        public ZeResult Assert(ZeAssertion assertion)
        {
            assertions.Add(assertion);
            return this;
        }

        public IEnumerator<ZeAssertion> GetEnumerator()
        {
            return assertions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return assertions.GetEnumerator();
        }
    }
}