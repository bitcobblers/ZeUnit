using System.Text;

namespace ZeUnit.Story
{

    public class StoryReporter : IZeReporter
    {
        private readonly string fileName;
        private readonly List<(ZeTest, Ze)> tests = new List<(ZeTest, Ze)>();

        public StoryReporter(string fileName = "story.html")
        {
            this.fileName = fileName;            
        }

        public void OnNext((ZeTest, Ze) value)
        {
            this.tests.Add(value);
        }

        public void OnCompleted()
        {
            var report = new StringBuilder();
            
            report.AppendLine("<html>");
            report.AppendLine("<head>");
            report.AppendLine("<title>ZeUnit - Test Run</title>");
            report.AppendLine("<link href='https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css' rel='stylesheet' integrity='sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC' crossorigin='anonymous'>");
            report.AppendLine("</head>");
            report.AppendLine("  <body class='container'>");

            var headerTemplate = new ClassHeaderPart();
            var testTemplate = new TestRowTemplatePart();

            // build the js and Css content,
            foreach (var group in tests.GroupBy(n => n.Item1.Class, n => n))
            {
                report.Append(headerTemplate.ToHtml(new { name = group.Key!.FullName }));
                foreach (var item in group)
                {
                    report.Append(testTemplate.ToHtml(new {
                        name = item.Item1.Method!.Name,
                        status = item.Item2.State == ZeStatus.Passed ? "success" : "danger",
                        messages = item.Item2.Select(m => new { message = m.Message }).ToArray()
                    }));
                }
                
            }            
            report.AppendLine("  </body>");
            report.AppendLine("</html>");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            File.WriteAllText(fileName, report.ToString());
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }   
    }
}