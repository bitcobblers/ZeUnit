
using HandlebarsDotNet;

public abstract class HandalbarsPart : IDocumentPart
{
    private HandlebarsTemplate<object, object>? template;

    protected void Compile(CompileSource rawHandlebars)
    {
        this.template = Handlebars.Compile(rawHandlebars.Load());
    }
    public string ToHtml(object data)
    {
        return this.template?.Invoke(data) ?? string.Empty;
    }
}
