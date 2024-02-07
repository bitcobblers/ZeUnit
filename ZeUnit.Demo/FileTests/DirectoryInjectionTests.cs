using ZeUnit.Assertions;

namespace ZeUnit.Demo.FileTests
{
    public class DirectoryInjectionTests
    {
        [LoadFiles("FileTests/test/")]
        public ZeResult LoadedFromDirectory(string fileString)
        {
            return fileString.NotEmpty();
        }

        [LoadFiles("FileTests/test/")]
        public ZeResult LoadedFromDirectoryWithExtension(
            [ExtensionFilter(".sample.txt")] string fileString)
        {
            return fileString.NotEmpty();
        }
    }

    public class DirectoryFileSetsInejctionTests 
    { 
        [LoadFileGroups("FileTests/test/")]
        public ZeResult LoadedFromDirectoryWithMultipleExtension(
            [ExtensionFilter(".test.txt")]string test, 
            [ExtensionFilter(".result.txt")]string result)
        {
            return test.ShouldBe(result);
        }
    }
}
