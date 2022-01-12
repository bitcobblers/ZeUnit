public class ClassHeaderPart : HandalbarsPart
{
    public ClassHeaderPart()
    {
        this.Compile(@"<h2>{{name}}</h2>");
    }
}