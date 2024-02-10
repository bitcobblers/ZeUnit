using ZeUnit.Assertions;

namespace ZeUnit.Demo.FileTests
{
    public class DirectoryInjectionTests
    {
        [LoadFiles("FileTests/test/")]
        public Ze LoadedFromDirectory(string fileString)
        {
            return fileString.IsNotEmpty();
        }

        [LoadFiles("FileTests/test/")]
        public Ze LoadedFromDirectoryWithExtension(
            [ExtensionFilter(".sample.txt")] string fileString)
        {
            return fileString.IsNotEmpty();
        }
    }

    public class DirectoryFileSetsInejctionTests 
    { 
        [LoadFileGroups("FileTests/test/")]
        public Ze LoadedFromDirectoryWithMultipleExtension(
            [ExtensionFilter(".test.txt")]string test, 
            [ExtensionFilter(".result.txt")]string result)
        {
            return test.Is(result);
        }
    }
}
