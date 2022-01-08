using System.Reflection;

namespace ZeUnit
{
    public class ZeTest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public MethodInfo Method { get; set; }
    }
}