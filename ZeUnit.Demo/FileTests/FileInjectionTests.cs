using System.Text;

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

    [Singleton]
    public class FileInjectionTests
    {
        [LoadFile("FileTests/test.txt")]
        public ZeResult LoadFileStream(FileStream stream)
        {
            using var reader = new StreamReader(stream);
            return Ze.Is.Equal("test", reader.ReadToEnd());
        }

        [LoadFile("FileTests/test.txt")]
        public ZeResult LoadFileText(string actual)
        {            
            return Ze.Is.Equal("test", actual);
        }

        [LoadFile("FileTests/test.txt")]
        public ZeResult LoadFileByteArray(byte[] actual)
        {
            // This test looks skip the first 3 char to avoid the BOM (EF BB BF in hex)
            var expected = Encoding.ASCII.GetBytes("test");            
            return Ze.Is                                
                .True(expected.SequenceEqual(actual.Skip(3)));
        }

        [LoadFile("FileTests/test.txt", "FileTests/test.txt")]
        public ZeResult LoadMultipleFileText(string actual1, string actual2)
        {
            return Ze.Is
                .Equal("test", actual1)
                .Equal("test", actual2);
        }

        [LoadFile("FileTests/test.txt")]
        [LoadFile("FileTests/test.txt")]
        public ZeResult LoadFileTextWithMultipleActivations(string actual)
        {
            return Ze.Is.Equal("test", actual);
        }        
    }
}
