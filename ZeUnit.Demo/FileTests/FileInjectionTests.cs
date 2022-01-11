using System.Text;

namespace ZeUnit.Demo.FileTests
{
    public class SerializedType
    {
        public string Text { get; set; }
    }

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
            // this test looks tricky because of the BOM (EF BB BF in hex)
            var expected = Encoding.ASCII.GetBytes("test");
            var actualWithOutBom = actual.Skip(3);
            return Ze.Is                                
                .True(expected.SequenceEqual(actualWithOutBom));
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


        [LoadFile("FileTests/test.xml")]
        public ZeResult LoadFileSerializedXMLObject(SerializedType actual)
        {
            return Ze.Is.Equal("test", actual.Text);
        }

        [LoadFile("FileTests/test.json")]
        public ZeResult LoadFileSerializedJsonObject(SerializedType actual)
        {
            return Ze.Is.Equal("test", actual.Text);
        }
    }
}
