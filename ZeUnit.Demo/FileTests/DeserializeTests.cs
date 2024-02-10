namespace ZeUnit.Demo.FileTests
{
    public class DeserializeTests
    {
        [LoadFile("FileTests/test.xml")]
        public Ze LoadFileSerializedXMLObject(SomePocoType actual)
        {
            return actual.Text.Is("test");
        }

        [LoadFile("FileTests/test.json")]
        public Ze LoadFileSerializedJsonObject(SomePocoType actual)
        {
            return actual.Text.Is("test");
        }
    }
}
