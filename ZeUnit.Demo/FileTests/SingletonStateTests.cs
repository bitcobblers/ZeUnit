namespace ZeUnit.Demo.FileTests;

public class SingletonStateTests
{
  
    [Only(typeof(TestSingleton))]
    public class FirstSingletonStateTest(TestSingleton onlyOne)
    {            
        public Fact ValueShouldBeZero()
        {
            return onlyOne.Count == 0;
        }
    }
    
    [Only(typeof(TestSingleton))]
    [DependsOn(typeof(FirstSingletonStateTest))]        
    public class SecondSingletonStateTest(TestSingleton onlyOne)
    {
        public Fact ValueAddedOneShouldBeOne()
        {
            return ++onlyOne.Count == 1;
        }
    }

    [Only(typeof(TestSingleton))]
    [DependsOn(typeof(SecondSingletonStateTest))]
    public class ThirdSingletonStateTest(TestSingleton onlyOne)
    {            
        public Fact ValueShouldBeOne()
        {
            return onlyOne.Count == 1;
        }
    }

}
