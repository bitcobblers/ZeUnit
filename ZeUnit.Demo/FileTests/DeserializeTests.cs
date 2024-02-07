﻿namespace ZeUnit.Demo.FileTests
{
    public class DeserializeTests
    {
        [LoadFile("FileTests/test.xml")]
        public ZeResult LoadFileSerializedXMLObject(SomePocoType actual)
        {
            return actual.Text.ShouldBe("test");
        }

        [LoadFile("FileTests/test.json")]
        public ZeResult LoadFileSerializedJsonObject(SomePocoType actual)
        {
            return actual.Text.ShouldBe("test");
        }
    }
}
