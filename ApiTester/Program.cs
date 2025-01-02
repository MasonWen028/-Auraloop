using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace ApiTester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            ProcessFiles("H:\\Projects\\neteasecloudmusicapi\\module", "output");




            Dictionary<string, string> query = new Dictionary<string, string>();

            string crypto = "";
            query.Add("crypto", "weapi");
            query.Add("cookie", @"{
                __csrf: '6127b27f3167bc41f8b513fcca82ac0a',
                _ga: 'GA1.1.1235940712.1735628657',
                _gid: 'GA1.1.584389389.1735628657',
                _ga_MD3K4WETFE: 'GS1.1.1735628657.1.0.1735628657.0.0.0',
                NMTID: '00ORvYXH120Lmy-6EAzowxdp_ru_t0AAAGUHIcQsw'
             }");
            query.Add("ua", "");
            query.Add("proxy:", "");
            query.Add("realIP", "");
            query.Add("e_r:", "");

            Options options = new Options(query, crypto);

            string uri = "/api/album/new";

            string data = @"{
              limit: 30,
              offset: 0,
              total: true,
              area: 'ALL'
            }";

            RequestProvider request = new RequestProvider();

            request.SendRequest(uri, data, options);

            Console.ReadKey();
        }

        public static void ProcessFiles(string directoryPath, string outputDirectory)
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all JavaScript files in the directory
            var files = Directory.GetFiles(directoryPath, "*.js");

            foreach (var file in files)
            {
                Console.WriteLine($"Processing file: {Path.GetFileName(file)}");
                var content = File.ReadAllText(file);

                // Extract the subfolder name based on the file name (e.g., "login_qr_key" -> "login")
                var subfolderName = ExtractSubfolderName(Path.GetFileNameWithoutExtension(file));

                // Create subfolder
                var subfolderPath = Path.Combine(outputDirectory, subfolderName);
                Directory.CreateDirectory(subfolderPath);

                // Extract API details
                var apiDetails = ExtractApiDetails(content);

                // Generate C# models
                GenerateCSharpModels(apiDetails, subfolderPath, Path.GetFileNameWithoutExtension(file));
            }
        }

        private static string ExtractSubfolderName(string fileName)
        {
            // Extract the folder name by splitting the file name at the first underscore
            var parts = fileName.Split('_', 2);
            return parts.Length > 1 ? parts[0].ToLower() : "general";
        }

        private static ApiDetails ExtractApiDetails(string fileContent)
        {
            var apiDetails = new ApiDetails();

            // Regex to find URI
            var uriMatch = Regex.Match(fileContent, @"url\s*:\s*['""](?<uri>[^'""]+)['""]");
            if (uriMatch.Success)
            {
                apiDetails.Uri = uriMatch.Groups["uri"].Value;
            }

            // Regex to find Request Model
            var paramsMatch = Regex.Match(fileContent, @"params\s*:\s*(?<params>\{[^\}]*\})");
            if (paramsMatch.Success)
            {
                apiDetails.RequestModel = paramsMatch.Groups["params"].Value;
            }

            // Regex to find Response Model (assumed to be JSON structure in response handler)
            var responseMatch = Regex.Match(fileContent, @"return\s*request\([^,]+,\s*(?<response>\{[^\}]*\})");
            if (responseMatch.Success)
            {
                apiDetails.ResponseModel = responseMatch.Groups["response"].Value;
            }

            return apiDetails;
        }

        private static void GenerateCSharpModels(ApiDetails apiDetails, string outputDirectory, string fileName)
        {
            if (!string.IsNullOrEmpty(apiDetails.RequestModel))
            {
                var requestModel = ConvertToCSharpClass(apiDetails.RequestModel, fileName + "Request");
                File.WriteAllText(Path.Combine(outputDirectory, $"{fileName}Request.cs"), requestModel);
            }

            if (!string.IsNullOrEmpty(apiDetails.ResponseModel))
            {
                var responseModel = ConvertToCSharpClass(apiDetails.ResponseModel, fileName + "Response");
                File.WriteAllText(Path.Combine(outputDirectory, $"{fileName}Response.cs"), responseModel);
            }
        }

        private static string ConvertToCSharpClass(string jsonString, string className)
        {
            var jsonObject = JObject.Parse(jsonString);
            var properties = new List<string>();

            foreach (var property in jsonObject.Properties())
            {
                var type = GetCSharpType(property.Value.Type);
                properties.Add($"public {type} {property.Name} {{ get; set; }}");
            }

            return @$"
public class {className}
{{
    {string.Join(Environment.NewLine, properties)}
}}
";
        }

        private static string GetCSharpType(JTokenType tokenType)
        {
            return tokenType switch
            {
                JTokenType.Integer => "int",
                JTokenType.Float => "double",
                JTokenType.String => "string",
                JTokenType.Boolean => "bool",
                JTokenType.Array => "List<object>",
                JTokenType.Object => "object",
                _ => "string"
            };
        }

        public class ApiDetails
        {
            public string Uri { get; set; }
            public string RequestModel { get; set; }
            public string ResponseModel { get; set; }
        }
    }
}
