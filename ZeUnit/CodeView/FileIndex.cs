using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ZeUnit.CodeView
{
    
    public class IndexValues : List<(string Name, int Index, int Location, Match Match)>
    {
        public IndexValues(Regex match, string code, string defaultValue = null)
        {
            var matches = match.Matches(code);
            this.AddRange(matches.Any()
                ? matches.Select((n, i) => (n.Groups[1].Value, i, n.Groups[1].Index, n)).ToArray()
                : defaultValue != null
                    ? new (string, int, int, Match)[] { (defaultValue, 0, 0, null!) }
                    : Array.Empty<(string, int, int, Match)>());
        }
        public int GetLastIndex((string, int, int Location, Match) lookup)
        {
            return this.Aggregate(0, (value, item) => item.Location < lookup.Location ? item.Index + 1 : value);
        }
        public string GetLast((string, int, int Location, Match) lookup) 
        { 
            return this.Aggregate(string.Empty, (value, item) => item.Location < lookup.Location ? item.Name : value);
        }
    }

    public class ZeCodeSolutionProvider
    {
        private IFileInfo solution;
        public ZeCodeSolutionProvider()
        {
            var dir = new DirectoryInfo(Environment.CurrentDirectory);
            var found = false;

            while (!found && dir != null)
            {
                Provider = new PhysicalFileProvider(dir.FullName);
                solution = Provider.GetDirectoryContents(string.Empty)
                    .FirstOrDefault(x => x.PhysicalPath.EndsWith("sln"))!;
                found = solution!= null;
                dir = dir.Parent;
            }
            Console.WriteLine("Solution Path:" + solution?.PhysicalPath);
        }

        public IFileProvider Provider { get; private set; }

        public ICollection<IFileInfo> Code()
        {
            ICollection<IFileInfo> files = new List<IFileInfo>();
            GetFiles(new FileInfo(solution.PhysicalPath).Directory.FullName, files);
            return files;
        }
        private void GetFiles(string path, ICollection<IFileInfo> files)
        {
            IFileProvider provider = new PhysicalFileProvider(path);

            var contents = provider.GetDirectoryContents("");

            foreach (var content in contents)
            {
                if (content.IsDirectory)
                {
                    GetFiles(content.PhysicalPath, files);
                }
                else if (content.Name.ToLower().EndsWith(".cs"))
                {
                    files.Add(content);
                }
            }
        }
    }

    public class FileIndexParser
    {
        private string defaultNamespace = "test";
        private string defaultClass = "Program";

        private static Regex newlineRegex = new Regex(@"(\n)");
        private static Regex namespaceRegex = new Regex(@"namespace (.*)[;?]");
        private static Regex classRegex = new Regex(@" class (\w*)");
        private static Regex factRegex = new Regex(@"public (.*[<?]Fact[>?]|Fact) (.*)\((.*)\)");

        public IEnumerable<MethodCodeInfo> ReadTest(IFileInfo sourceCode)
        {
                                    
            using var reader = new StreamReader(sourceCode.CreateReadStream(), Encoding.UTF8);
            var code = reader.ReadToEnd();
            var lines = new IndexValues(newlineRegex, code);
            var namespaces = new IndexValues(namespaceRegex, code, defaultNamespace);
            var classes = new IndexValues(classRegex, code, defaultClass);
            var methods = new IndexValues(factRegex, code);  

            foreach (var  method in methods) 
            {
                var currentNameSpace = namespaces.GetLast(method);
                var currentClass = classes.GetLast(method);
                var line = lines.GetLastIndex(method) + 1;
                var methodName = method.Match.Groups[2].Value;
                var methodLifetype = method.Match.Groups[1].Value;
                var methodRequires = (method.Match.Groups[3].Value ?? "").Split(",").Select(n=>n.Trim()).ToArray();

                yield return new MethodCodeInfo(
                    sourceCode.PhysicalPath,
                    line,
                    currentNameSpace,
                    currentClass,
                    methodName,
                    methodLifetype,
                    methodRequires);
            }
        }
    }
}
