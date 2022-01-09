using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeUnit.Demo.InlineTests
{
    [InlineData("test")]
    public class InlineInjectionTests
    {
        private readonly string injected;
        public InlineInjectionTests(string injected)
        {
            this.injected = injected;
        }

        public ZeResult InlineInjectorForClassIsWorking()
        {
            return Ze.Assert()
                .IsEqual("test", this.injected);
        }

        [InlineData("test")]
        public ZeResult InlineInjectionForMethodWorks(string method)
        {
            return Ze.Assert()
                .IsEqual("test", method);
        }
    }
}
