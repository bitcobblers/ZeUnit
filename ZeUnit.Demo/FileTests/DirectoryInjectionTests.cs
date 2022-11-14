namespace ZeUnit.Demo.FileTests
{
    public class DirectoryInjectionTests
    {
        [LoadDirectory("FileTests/test/")]
        public ZeResult LoadedFromDirectory(string value)
        {
            return Ze.Is.NotEmpty(value);
        }

        [LoadDirectory("FileTests/test/")]
        public ZeResult LoadedFromDirectoryWithExtension(
            [ExtensionFilter("sample.txt")]string value)
        {
            return Ze.Is.NotEmpty(value);
        }

        [LoadDirectory("FileTests/test/")]
        public ZeResult LoadedFromDirectoryWithMultipleExtension(
            [ExtensionFilter("test.txt")]string value, 
            [ExtensionFilter("result.txt")]string result)
        {
            return Ze.Is.Equal(result, value);
        }

    }
}
