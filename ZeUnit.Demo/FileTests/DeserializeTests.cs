namespace ZeUnit.Demo.FileTests
{
    public class DeserializeTests
    {
        [LoadFile("FileTests/tes2t.xml")]
        public ZeResult LoadFileSerializedXMLObject(SomePocoType actual)
        {
            return Ze.Is.Equal("test", actual.Text);
        }

        [LoadFile("FileTests/test.json")]
        public ZeResult LoadFileSerializedJsonObject(SomePocoType actual)
        {
            return Ze.Is.Equal("test", actual.Text);
        }
    }
}
