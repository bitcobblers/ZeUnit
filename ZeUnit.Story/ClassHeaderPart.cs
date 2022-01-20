public class ClassHeaderPart : HandalbarsPart
{
    public ClassHeaderPart()
    {
        this.Compile(new StringSource(@"<h2>{{name}}</h2>"));
    }
}
///test