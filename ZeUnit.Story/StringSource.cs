public class StringSource : CompileSource
{
    private readonly string source;

    public StringSource(string source)
    {
        this.source = source;
    }

    public override string Load() => this.source;
}
