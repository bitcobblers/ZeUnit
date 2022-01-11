namespace ZeUnit.Demo.FileTests
{
    public class DeserializeTests
    {
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
