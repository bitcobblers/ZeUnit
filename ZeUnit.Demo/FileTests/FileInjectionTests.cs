using System.Text;

namespace ZeUnit.Demo.FileTests
{

    [Singleton]
    public class FileInjectionTests
    {
        [LoadFile("FileTests/test.txt")]
        public ZeResult LoadFileStream(FileStream stream)
        {
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd().Is("test");
        }

        [LoadFile("FileTests/test.txt")]
        public ZeResult LoadFileText(string actual)
        {            
            return actual.Is("test");
        }

        [LoadFile("FileTests/test.txt")]
        public ZeResult LoadFileByteArray(byte[] actual)
        {
            // This test looks skip the first 3 char to avoid the BOM (EF BB BF in hex)
            var expected = Encoding.ASCII.GetBytes("test");            
            return expected.SequenceEqual(actual.Skip(3)).True();
        }

        [LoadFile("FileTests/test.txt", "FileTests/test.txt")]
        public ZeResult LoadMultipleFileText(string actual1, string actual2)
        {
            return "test"
                .Is(actual1)
                .Is(actual2);
        }

        [LoadFile("FileTests/test.txt")]
        [LoadFile("FileTests/test.txt")]
        public ZeResult LoadFileTextWithMultipleActivations(string actual)
        {
            return actual.Is("test");
        }        
    }
}
