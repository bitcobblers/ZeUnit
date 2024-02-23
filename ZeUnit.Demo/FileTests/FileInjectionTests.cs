using System.Text;
using ZeUnit.Demo.InjectionTests;

namespace ZeUnit.Demo.FileTests
{
    public class TestSingleton
    {
        public int Count = 0;
    }

    [Only(typeof(TestSingleton))]
    [LamarContainer(typeof(SimpleServiceInjectionRegistry))]
    public class CoreFactoryCanMixComposers
    {
        private readonly TestSingleton one;
        private readonly ISimpleInjectedService service;

        public CoreFactoryCanMixComposers(TestSingleton one, ISimpleInjectedService service)
        {
            this.one = one;
            this.service = service;
        }

        public IEnumerable<Fact> BothInjectableObjectsShouldNotBeNull()
        {
            yield return this.one != null;
            yield return this.service != null;
        }
    }

    public class FileInjectionTests
    {
       
        [LoadFile("FileTests/test.txt")]
        public Fact LoadFileStream(FileStream stream)
        {
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd().Is("test");
        }

        [LoadFile("FileTests/test.txt")]
        public Fact LoadFileText(string actual)
        {            
            return actual.Is("test");
        }

        [LoadFile("FileTests/test.txt")]
        public Fact LoadFileByteArray(byte[] actual)
        {
            // This test looks skip the first 3 char to avoid the BOM (EF BB BF in hex)
            var expected = Encoding.ASCII.GetBytes("test");            
            return expected.SequenceEqual(actual.Skip(3)).True();
        }

        [LoadFile("FileTests/test.txt", "FileTests/test.txt")]
        public Fact LoadMultipleFileText(string actual1, string actual2)
        {
            return "test"
                .Is(actual1)
                .Is(actual2);
        }

        [LoadFile("FileTests/test.txt")]
        [LoadFile("FileTests/test.txt")]
        public Fact LoadFileTextWithMultipleActivations(string actual)
        {
            return actual.Is("test");
        }        
    }
}
