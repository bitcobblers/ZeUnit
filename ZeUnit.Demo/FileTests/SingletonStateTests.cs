namespace ZeUnit.Demo.FileTests
{
    public class SingletonStateTests
    {
      
        [Only(typeof(TestSingleton))]
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
        
        [Only(typeof(TestSingleton))]
        [DependsOn(typeof(FirstSingletonStateTest))]        
        public class SecondSingletonStateTest
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

        [Only(typeof(TestSingleton))]
        [DependsOn(typeof(SecondSingletonStateTest))]
        public class ThirdSingletonStateTest
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
}
