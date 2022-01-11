namespace ZeUnit.Demo.FileTests
{
    public class FileInjectionTests
    {
        [LoadFileStream("FileTests/test.txt")]
        public ZeResult LoadFileStream(FileStream stream)
        {
            using var reader = new StreamReader(stream);
            return Ze.Is.Equal("test", reader.ReadToEnd());
        }

        [LoadFileText("FileTests/test.txt")]
        public ZeResult LoadFileText(string text)
        {            
            return Ze.Is.Equal("test", text);
        }
    }
}
