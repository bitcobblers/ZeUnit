public class TestRowTemplatePart : HandalbarsPart
{
    public TestRowTemplatePart()
    {
        this.Compile(
@"<div class='alert alert-{{status}}' role='alert'>   
    <h4>{{name}}</h4>
 </div>
<table class='table'>
{{#messages}}
    <tr>    
        <td>{{Message}}</td>
    </tr>
{{/messages}}
</table>
");
    }
}
