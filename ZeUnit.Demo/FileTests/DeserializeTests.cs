namespace ZeUnit.Demo.FileTests
{
    public class DeserializeTests
    {
        [LoadFile("FileTests/test.xml")]
        public Fact LoadFileSerializedXMLObject(SomePocoType actual)
        {
            return actual.Text.Is("test");
        }

        [LoadFile("FileTests/test.json")]
        public Fact LoadFileSerializedJsonObject(SomePocoType actual)
        {
            return actual.Text.Is("test");
        }
    }
}
