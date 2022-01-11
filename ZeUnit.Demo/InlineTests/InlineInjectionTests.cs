using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeUnit.Demo.InlineTests
{    
    public class InlineInjectionTests
    {      
        [InlineData("test1", 1)]
        [InlineData("test2", 2)]
        public ZeResult InlineInjectionForMethodWorks(string method, int expected)
        {
            return Ze.Assert()
                .IsEqual($"test{expected}", method);
        }
    }
}
