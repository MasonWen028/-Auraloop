using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class ModelGenerator
    {
        public static void GenerateRequestModel(string filePath, string className, string outputDir)
        {
            string content = File.ReadAllText(filePath);
            content = RemoveComments(content); // 忽略注释

            // 提取数据键值对
            var (dataKeys, dataValues) = ExtractDataKeys(content);

            // 生成 RequestModel 内容
            string classContent = GenerateRequestModel(className, dataKeys, dataValues);

            // 保存文件
            string outputPath = Path.Combine(outputDir, $"{className}.cs");
            File.WriteAllText(outputPath, classContent);
            Console.WriteLine($"Generated model: {outputPath}");
        }

        private static string RemoveComments(string content)
        {
            return Regex.Replace(content, @"//.*", "").Trim();
        }

        private static (string[], Dictionary<string, string>) ExtractDataKeys(string content)
        {
            var match = Regex.Match(content, @"const data\s*=\s*\{([\s\S]*?)\}");
            if (!match.Success) return (null, null);

            string dataContent = match.Groups[1].Value;

            var keyMatches = Regex.Matches(dataContent, @"(\w+)\s*:\s*([^,}]+)");
            string[] keys = new string[keyMatches.Count];
            var values = new Dictionary<string, string>();

            for (int i = 0; i < keyMatches.Count; i++)
            {
                string key = keyMatches[i].Groups[1].Value.Trim();
                string value = keyMatches[i].Groups[2].Value.Trim();

                keys[i] = key;
                values[key] = value;
            }

            return (keys, values);
        }

        private static string GenerateRequestModel(string className, string[] dataKeys, Dictionary<string, string> dataValues)
        {
            string properties = dataKeys != null && dataKeys.Length > 0
                ? string.Join(Environment.NewLine,
                    dataKeys.Select(key =>
                    {
                        string jsonKey = ToCamelCase(key);
                        string value = dataValues.ContainsKey(key) ? dataValues[key] : null;
                        string type = InferType(key, value);
                        return $@"    [JsonProperty(""{jsonKey}"")]
    public {type} {FormatToPascalCase(key)} {{ get; set; }}";
                    }))
                : "// No data fields found";

            return $@"
using Newtonsoft.Json;

public class {className}
{{
{properties}
}}
";
        }

        private static string InferType(string key, string value)
        {
            if (key.ToLower().Contains("time") || key.ToLower().Contains("date"))
                return "long";

            if (!string.IsNullOrEmpty(value))
            {
                if (value == "true" || value == "false")
                    return "bool";

                if (int.TryParse(value, out _))
                    return "int";

                if (double.TryParse(value, out _))
                    return "double";
            }

            return "string";
        }

        private static string ToCamelCase(string text)
        {
            if (string.IsNullOrEmpty(text) || text.Length < 2)
                return text.ToLower();

            return char.ToLower(text[0]) + text.Substring(1);
        }

        private static string FormatToPascalCase(string text)
        {
            var parts = text.Split('_');
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = char.ToUpper(parts[i][0]) + parts[i].Substring(1).ToLower();
            }
            return string.Join("", parts);
        }
    }

    public static class RequestModelBatchGenerator
    {
        public static void GenerateRequestModels(string inputDir, string outputDir)
        {
            // Ensure the output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Get all .js files from the input directory
            var jsFiles = Directory.GetFiles(inputDir, "*.js", SearchOption.AllDirectories);

            foreach (var filePath in jsFiles)
            {
                try
                {
                    Console.WriteLine($"Processing: {filePath}");

                    // Extract file name without extension for class name
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    string className = FormatToPascalCase(fileName) + "RequestModel";

                    // Determine the subfolder based on the prefix
                    string prefix = GetPrefix(fileName);
                    string subFolder = Path.Combine(outputDir, prefix);

                    // Ensure the subfolder exists
                    if (!Directory.Exists(subFolder))
                    {
                        Directory.CreateDirectory(subFolder);
                    }

                    // Read file content
                    string content = File.ReadAllText(filePath);
                    content = RemoveComments(content); // Remove comments

                    // Extract data keys and values
                    var (dataKeys, dataValues) = ExtractDataKeys(content);

                    // Generate RequestModel class
                    string classContent = GenerateRequestModel(className, dataKeys, dataValues);

                    // Save to the subfolder
                    string outputFilePath = Path.Combine(subFolder, $"{className}.cs");
                    File.WriteAllText(outputFilePath, classContent);

                    Console.WriteLine($"Generated model: {outputFilePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
                }
            }
        }

        private static string GetPrefix(string fileName)
        {
            // Extract the prefix before the first underscore (_) or use the entire name
            int underscoreIndex = fileName.IndexOf('_');
            return underscoreIndex > 0 ? fileName.Substring(0, underscoreIndex) : fileName;
        }

        private static string RemoveComments(string content)
        {
            return Regex.Replace(content, @"//.*(\r?\n|\r)", "").Trim();
        }

        private static (string[], Dictionary<string, string>) ExtractDataKeys(string content)
        {
            // Match the object defined as `const data = { ... }`
            var match = Regex.Match(content, @"const\s+data\s*=\s*\{([\s\S]*?)\}");
            if (!match.Success) return (null, null);

            string dataContent = match.Groups[1].Value;

            // Match properties with key-value pairs or shorthand syntax
            var keyMatches = Regex.Matches(dataContent, @"(?:(\w+)\s*:\s*([^,}]+)|(\w+))");
            var keys = new List<string>();
            var values = new Dictionary<string, string>();

            foreach (Match keyMatch in keyMatches)
            {
                if (keyMatch.Groups[1].Success) // Explicit property (key: value)
                {
                    string key = keyMatch.Groups[1].Value.Trim();
                    string value = keyMatch.Groups[2].Value.Trim();

                    // Ensure valid field names
                    if (IsValidFieldName(key))
                    {
                        keys.Add(key);
                        values[key] = value;
                    }
                }
                else if (keyMatch.Groups[3].Success) // Shorthand property
                {
                    string key = keyMatch.Groups[3].Value.Trim();

                    // Ensure valid field names
                    if (IsValidFieldName(key))
                    {
                        keys.Add(key);
                        values[key] = key; // Value is the same as the key for shorthand
                    }
                }
            }

            return (keys.ToArray(), values);
        }

        private static bool IsValidFieldName(string fieldName)
        {
            // Exclude literals like "true", "false", or numeric values
            return !string.IsNullOrEmpty(fieldName) &&
                   !Regex.IsMatch(fieldName, @"^\d+$") && // Exclude purely numeric keys
                   !fieldName.Equals("true", StringComparison.OrdinalIgnoreCase) &&
                   !fieldName.Equals("false", StringComparison.OrdinalIgnoreCase);
        }

        private static string GenerateRequestModel(string className, string[] dataKeys, Dictionary<string, string> dataValues)
        {
            var uniqueFields = new HashSet<string>(); // Track unique fields
            string properties = dataKeys != null && dataKeys.Length > 0
                ? string.Join(Environment.NewLine,
                    dataKeys.Select(key =>
                    {
                        if (!uniqueFields.Add(key)) // Skip if field already exists
                            return null;

                        string jsonKey = ToCamelCase(key);
                        string value = dataValues.ContainsKey(key) ? dataValues[key] : null;
                        string type = InferType(key, value);
                        return $@"    [JsonProperty(""{jsonKey}"")]
    public {type} {FormatToPascalCase(key)} {{ get; set; }}";
                    }).Where(p => !string.IsNullOrEmpty(p))) // Remove null entries
                : "// No data fields found";

            return $@"
using Newtonsoft.Json;

public class {className}
{{
{properties}
}}
";
        }

        private static string InferType(string key, string value)
        {
            if (key.ToLower().Contains("no") || key.ToLower().Contains("size") || key.ToLower().Contains("count"))
                return "int";

            if (key.ToLower().Contains("time") || key.ToLower().Contains("date"))
                return "long";

            // Handle default values (e.g., || true)
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Contains("||"))
                {
                    var parts = value.Split(new[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var part in parts)
                    {
                        string trimmedPart = part.Trim();
                        if (trimmedPart.Equals("true", StringComparison.OrdinalIgnoreCase) ||
                            trimmedPart.Equals("false", StringComparison.OrdinalIgnoreCase))
                        {
                            return "bool"; // Default to bool if one part is true/false
                        }
                        if (int.TryParse(trimmedPart, out _))
                        {
                            return "int"; // Default to int if one part is numeric
                        }
                    }
                }

                if (value == "true" || value == "false")
                    return "bool";

                if (int.TryParse(value, out _))
                    return "int";

                if (double.TryParse(value, out _))
                    return "double";
            }

            return "string";
        }

        private static string ToCamelCase(string text)
        {
            if (string.IsNullOrEmpty(text) || text.Length < 2)
                return text.ToLower();

            return char.ToLower(text[0]) + text.Substring(1);
        }

        private static string FormatToPascalCase(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            // Split words based on underscores, spaces, or transition from lowercase to uppercase
            var parts = Regex.Split(text, @"(?<!^)(?=[A-Z])|[_\s]+")
                             .Where(p => !string.IsNullOrEmpty(p)) // Remove empty parts
                             .Select(p => char.ToUpper(p[0]) + p.Substring(1).ToLower()); // Capitalize each part

            return string.Concat(parts); // Combine parts into PascalCase
        }
    }

    public static class ApiModelBatchGenerator
    {
        public static void GenerateApiModels(string inputDir, string outputDir)
        {
            // Get all .js files from the input directory
            var jsFiles = Directory.GetFiles(inputDir, "*.js", SearchOption.AllDirectories);

            foreach (var filePath in jsFiles)
            {
                try
                {
                    Console.WriteLine($"Processing: {filePath}");

                    // Extract file name without extension for class name
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    string className = FormatToPascalCase(fileName) + "ApiModel";

                    // Determine the subfolder based on the prefix
                    string prefix = GetPrefix(fileName);
                    string subFolder = Path.Combine(outputDir, prefix);

                    // Ensure the subfolder exists
                    if (!Directory.Exists(subFolder))
                    {
                        Directory.CreateDirectory(subFolder);
                    }

                    // Read file content
                    string content = File.ReadAllText(filePath);
                    content = RemoveComments(content); // Remove comments

                    // Extract ApiEndpoint, OptionType, and dynamic fields
                    string apiEndpoint = ExtractApiEndpoint(content);
                    string optionType = ExtractOptionType(content);
                    var dynamicFields = ExtractDynamicFields(apiEndpoint);

                    // Check if there is a `data` object
                    bool hasDataObject = ContainsDataObject(content);
                    string requestModelClassName = hasDataObject ? className.Replace("ApiModel", "RequestModel") : null;

                    // Replace `{dynamic}` with actual field names in ApiEndpoint
                    string updatedApiEndpoint = ReplaceDynamicPlaceholders(apiEndpoint, dynamicFields);

                    // Generate ApiModel class
                    string classContent = GenerateApiModel(className, dynamicFields, updatedApiEndpoint, optionType, requestModelClassName);

                    // Save to the subfolder
                    string outputFilePath = Path.Combine(subFolder, $"{className}.cs");
                    File.WriteAllText(outputFilePath, classContent);

                    Console.WriteLine($"Generated ApiModel: {outputFilePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
                }
            }
        }

        private static string GetPrefix(string fileName)
        {
            // Extract the prefix before the first underscore (_) or use the entire name
            int underscoreIndex = fileName.IndexOf('_');
            return underscoreIndex > 0 ? fileName.Substring(0, underscoreIndex) : fileName;
        }

        private static string RemoveComments(string content)
        {
            return Regex.Replace(content, @"//.*(\r?\n|\r)", "").Trim();
        }

        private static string ExtractApiEndpoint(string content)
        {
            var match = Regex.Match(content, @"request\(\s*`([^`]+)`");
            return match.Success ? match.Groups[1].Value : null;
        }

        private static string ExtractOptionType(string content)
        {
            var match = Regex.Match(content, @"createOption\(.*?,\s*['""]([^'""]+)['""]\)");
            return match.Success ? match.Groups[1].Value : null;
        }

        private static List<string> ExtractDynamicFields(string apiEndpoint)
        {
            if (string.IsNullOrEmpty(apiEndpoint)) return new List<string>();

            // Match dynamic fields in the API endpoint (e.g., ${query.id})
            var matches = Regex.Matches(apiEndpoint, @"\$\{query\.([\w]+)\}");
            return matches.Cast<Match>().Select(m => m.Groups[1].Value).ToList();
        }

        private static bool ContainsDataObject(string content)
        {
            // Check if a `data` object is defined in the code
            return Regex.IsMatch(content, @"const\s+data\s*=\s*\{");
        }

        private static string ReplaceDynamicPlaceholders(string apiEndpoint, List<string> dynamicFields)
        {
            if (string.IsNullOrEmpty(apiEndpoint)) return apiEndpoint;

            // Replace placeholders like ${query.id} with {id}
            foreach (var field in dynamicFields)
            {
                apiEndpoint = apiEndpoint.Replace($"${{query.{field}}}", $"{{{field}}}");
            }

            return apiEndpoint;
        }

        private static string GenerateApiModel(string className, List<string> dynamicFields, string apiEndpoint, string optionType, string requestModelClassName)
        {
            // Generate dynamic fields
            string dynamicFieldsProperty = dynamicFields.Count > 0
                ? string.Join(Environment.NewLine, dynamicFields.Select(field =>
                    $@"    public string {FormatToPascalCase(field)} {{ get; set; }}"))
                : null;

            // Generate request model field
            string requestModelProperty = !string.IsNullOrEmpty(requestModelClassName)
                ? $@"    public {requestModelClassName} Data {{ get; set; }}"
                : null;

            // Combine properties
            string combinedProperties = string.Join(Environment.NewLine, new[] { dynamicFieldsProperty, requestModelProperty }.Where(p => !string.IsNullOrEmpty(p)));

            return $@"
public class {className}
{{
    public string ApiEndpoint {{ get; set; }} = ""{apiEndpoint}"";

    public string OptionType {{ get; set; }} = {(string.IsNullOrEmpty(optionType) ? "null" : $"\"{optionType}\"")};

{combinedProperties}
}}
";
        }

        private static string FormatToPascalCase(string text)
        {
            var parts = Regex.Split(text, @"(?<!^)(?=[A-Z])|[_\s]+")
                         .Where(p => !string.IsNullOrEmpty(p))
                         .Select(p => char.ToUpper(p[0]) + p.Substring(1).ToLower());

            return string.Concat(parts);
        }
    }

public class ControllerGenerator
    {
        private readonly string _outputDirectory;
        private readonly string _namespace;

        public ControllerGenerator(string outputDirectory, string @namespace)
        {
            _outputDirectory = outputDirectory;
            _namespace = @namespace;
        }

        public void GenerateControllersFromJsFiles(IEnumerable<string> jsFilePaths)
        {
            // Group files by the controller name (e.g., files starting with "login" go into "LoginController")
            var groupedFiles = jsFilePaths.GroupBy(GetControllerName);

            foreach (var group in groupedFiles)
            {
                var controllerName = group.Key;
                var actions = group.Select(file => ExtractActionFromFile(file));

                // Generate the controller code
                var controllerCode = GenerateControllerCode(controllerName, actions);

                // Save the generated code to a file
                var outputFilePath = Path.Combine(_outputDirectory, $"{controllerName}Controller.cs");
                File.WriteAllText(outputFilePath, controllerCode);
            }
        }

        private string GetControllerName(string jsFilePath)
        {
            // Extract the controller name from the filename (e.g., "login_cell_phone.js" -> "LoginController")
            var fileName = Path.GetFileNameWithoutExtension(jsFilePath);
            var controllerName = fileName.Split('_')[0]; // Take the first part of the filename
            return char.ToUpper(controllerName[0]) + controllerName.Substring(1); // Capitalize
        }

        private (string ActionName, string Route, string ApiEndpoint, string OptionType, string RequestModelType) ExtractActionFromFile(string jsFilePath)
        {
            // Extract action information based on the filename
            var fileName = Path.GetFileNameWithoutExtension(jsFilePath);

            // Generate route from the JS file name
            var route = fileName.Replace("_", "/").ToLower();

            // Generate PascalCase action name
            var actionName = ToPascalCase(fileName.Replace("_", " "));

            // Extract ApiEndpoint and OptionType from the JS file
            var apiEndpoint = ExtractApiEndpointFromJsFile(jsFilePath);
            var optionType = ExtractOptionTypeFromJsFile(jsFilePath);

            // Determine RequestModel type from the JS file name
            var requestModelType = $"{string.Join("", fileName.Split('_').Select(p => char.ToUpper(p[0]) + p.Substring(1)))}RequestModel";

            return (actionName, route, apiEndpoint, optionType, requestModelType);
        }

        private static string ExtractApiEndpoint(string content)
        {
            var match = Regex.Match(content, @"request\(\s*`([^`]+)`");
            return match.Success ? match.Groups[1].Value : null;
        }

        private string ExtractApiEndpointFromJsFile(string jsFilePath)
        {
            // Read the JavaScript file and extract the endpoint from lines like:
            // return request(`/api/aidj/content/rcmd/info`, data, createOption(query));
            var fileContent = File.ReadAllText(jsFilePath);
            var match = Regex.Match(fileContent, @"`([^`]*)`");
            if (jsFilePath.Contains("login.js"))
            {

            }
            return match.Success ? match.Groups[1].Value : "";
        }

        private string ExtractOptionTypeFromJsFile(string jsFilePath)
        {
            // Extract OptionType from the JS file, assuming it's a fixed value or follows a pattern
            var fileContent = File.ReadAllText(jsFilePath);
            var match = Regex.Match(fileContent, @"createOption\(([^)]*)\)");
            return match.Success ? "weapi" : "";
        }

        private string ToPascalCase(string input)
        {
            // Convert string to PascalCase
            if (string.IsNullOrEmpty(input)) return input;
            return string.Join("", input.Split(' ').Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
        }

        private string GenerateControllerCode(string controllerName, IEnumerable<(string ActionName, string Route, string ApiEndpoint, string OptionType, string RequestModelType)> actions)
        {
            var sb = new StringBuilder();

            // Generate the controller class
            sb.AppendLine("using Microsoft.AspNetCore.Mvc;");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine();
            sb.AppendLine($"namespace {_namespace}");
            sb.AppendLine("{");
            sb.AppendLine($"    [ApiController]");
            sb.AppendLine($"    public class {controllerName}Controller : Controller");
            sb.AppendLine("    {");
            sb.AppendLine($"        private readonly GenericService _genericService;");
            sb.AppendLine();
            sb.AppendLine($"        public {controllerName}Controller(GenericService genericService)");
            sb.AppendLine("        {");
            sb.AppendLine("            _genericService = genericService;");
            sb.AppendLine("        }");

            // Generate actions
            foreach (var (actionName, route, apiEndpoint, optionType, requestModelType) in actions)
            {
                sb.AppendLine();
                sb.AppendLine($"        [HttpPost]");
                sb.AppendLine($"        [Route(\"{route}\")]");
                sb.AppendLine($"        public async Task<IActionResult> {actionName}()");
                sb.AppendLine("        {");
                sb.AppendLine("            try");
                sb.AppendLine("            {");
                sb.AppendLine($"                var apiModel = new ApiModel");
                sb.AppendLine("                {");
                sb.AppendLine($"                    ApiEndpoint = \"{apiEndpoint}\",");
                sb.AppendLine($"                    OptionType = \"{optionType}\",");
                sb.AppendLine($"                    Data = new {requestModelType}()");
                sb.AppendLine("                    {");
                sb.AppendLine("                        // Replace with actual data if needed");
                sb.AppendLine("                    }");
                sb.AppendLine("                };");
                sb.AppendLine();
                sb.AppendLine("                var result = await _genericService.HandleRequestAsync(apiModel);");
                sb.AppendLine("                return Ok(result.data);");
                sb.AppendLine("            }");
                sb.AppendLine("            catch (Exception ex)");
                sb.AppendLine("            {");
                sb.AppendLine("                return StatusCode(500, new { Message = ex.Message });");
                sb.AppendLine("            }");
                sb.AppendLine("        }");
            }

            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }

}
