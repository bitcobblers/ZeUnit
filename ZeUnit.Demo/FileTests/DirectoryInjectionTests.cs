namespace ZeUnit.Demo.FileTests
{
    public class DirectoryInjectionTests
    {
        [LoadFiles("FileTests/test/")]
        public ZeResult LoadedFromDirectory(string fileString)
        {
            return Ze.Is.NotEmpty(fileString);
        }

        [LoadFiles("FileTests/test/")]
        public ZeResult LoadedFromDirectoryWithExtension(
            [ExtensionFilter(".sample.txt")] string fileString)
        {
            return Ze.Is.NotEmpty(fileString);
        }
    }

    public class DirectoryFileSetsInejctionTests 
    { 
        [LoadFileGroups("FileTests/test/")]
        public ZeResult LoadedFromDirectoryWithMultipleExtension(
            [ExtensionFilter(".test.txt")]string test, 
            [ExtensionFilter(".result.txt")]string result)
        {
            return Ze.Is.Equal(result, test);
        }
    }
}
