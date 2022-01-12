
using HandlebarsDotNet;

public abstract class HandalbarsPart : IDocumentPart
{
    private HandlebarsTemplate<object, object>? template;

    protected void Compile(string rawHandlebars)
    {
        this.template = Handlebars.Compile(rawHandlebars);
    }
    public string ToHtml(object data)
    {
        return this.template?.Invoke(data) ?? string.Empty;
    }
}
