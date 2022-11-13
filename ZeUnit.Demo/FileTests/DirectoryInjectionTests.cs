namespace ZeUnit.Demo.FileTests
{
    public class DirectoryInjectionTests
    {
        [LoadDirectory("FileTests/test/")]
        public ZeResult LoadedFromDirectory(string value)
        {
            return Ze.Is.NotEmpty(value);
        }

        [LoadDirectory("FileTests/test/", "sample.txt")]
        public ZeResult LoadedFromDirectoryWithExtension(string value)
        {
            return Ze.Is.NotEmpty(value);
        }

        [LoadDirectory("FileTests/test/", "test.txt", "result.txt")]
        public ZeResult LoadedFromDirectoryWithMultipleExtension(string value, string result)
        {
            return Ze.Is.Equal(result, value);
        }

    }
}
