using System.Text;
using ZeUnit.Demo.InjectionTests;

namespace ZeUnit.Demo.FileTests
{
    public class TestSingleton
    {
        public int Count = 0;
    }

    [Composers.Singleton(typeof(TestSingleton))]
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

    public class SingletonStateTests
    {
      
        [Composers.Singleton(typeof(TestSingleton))]
        public class FirstSingletonStateTest
        {
            private readonly TestSingleton onlyOne;

            public FirstSingletonStateTest(TestSingleton onlyOne)
            {
                this.onlyOne = onlyOne;
            }

            public Fact ValueShouldBeZero()
            {
                return this.onlyOne.Count == 0;
            }
        }

        [Composers.Singleton(typeof(TestSingleton))]
        public class SecondSingletonStateTest : IZeDependency<FirstSingletonStateTest>
        {
            private readonly TestSingleton onlyOne;

            public SecondSingletonStateTest(TestSingleton onlyOne)
            {
                this.onlyOne = onlyOne;
            }

            public Fact ValueAddedOneShouldBeOne()
            {
                return ++this.onlyOne.Count == 1;
            }
        }

        [Composers.Singleton(typeof(TestSingleton))]
        public class ThirdSingletonStateTest : IZeDependency<SecondSingletonStateTest>
        {
            private readonly TestSingleton onlyOne;

            public ThirdSingletonStateTest(TestSingleton onlyOne)
            {
                this.onlyOne = onlyOne;
            }

            public Fact ValueShouldBeOne()
            {
                return this.onlyOne.Count == 1;
            }
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
