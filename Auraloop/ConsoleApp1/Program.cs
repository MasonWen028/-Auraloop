using ConsoleApp1;
using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

class Program
{

    // Generate a method from an ApiModel class
    static string GenerateMethodFromClass(string filePath)
    {
        string classContent = File.ReadAllText(filePath);

        // Extract class name
        string className = Path.GetFileNameWithoutExtension(filePath);
        if (string.IsNullOrEmpty(className)) return null;

        // Extract the Data field and its type (RequestModel)
        var match = Regex.Match(classContent, @"public\s+(\w+)\s+Data\s+\{");
        if (!match.Success) return null;

        string requestModelType = match.Groups[1].Value;

        // Generate method name
        string methodName = className.Replace("ApiModel", "");
        methodName = methodName.Substring(0, 1).ToUpper() + methodName.Substring(1);

        // Generate method signature
        return $@" Task<ApiResponse> {methodName}Async({className} requestModel);";
    }

    // 生成接口内容
    static string GenerateInterfaceContent(string interfaceName, string[] methods)
    {
        string methodsContent = string.Join(Environment.NewLine, methods);

        return $@"
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Models.Dtos;

public interface {interfaceName}
{{
{methodsContent}
}}
";
    }

    private static string FormatToPascalCase1(string text)
    {
        var parts = Regex.Split(text, @"(?<!^)(?=[A-Z])|[_\s]+")
                     .Where(p => !string.IsNullOrEmpty(p))
                     .Select(p => char.ToUpper(p[0]) + p.Substring(1).ToLower());

        return string.Concat(parts);
    }

    static void Main(string[] args)
    {
        var c = new ControllerGenerator("controllers", "NeteaseCloudMusicApi_SDK.Controllers");

        var jsFiles = Directory.GetFiles("H:\\Projects\\neteasecloudmusicapi\\module", "*.js", SearchOption.AllDirectories);
        c.GenerateControllersFromJsFiles(jsFiles);

        return;
        string apiModelsDir = "ApiModels";
        //string requestModelsDir = "RequestModels";
        //RequestModelBatchGenerator.GenerateRequestModels(@"H:\\Projects\\neteasecloudmusicapi\\module", requestModelsDir);
        //ApiModelBatchGenerator.GenerateApiModels(@"H:\\Projects\\neteasecloudmusicapi\\module", apiModelsDir);
        //return;

        //// 设置输入和输出目录
        //string inputDir = @"H:\\Projects\\neteasecloudmusicapi\\module"; // 替换为你的模块文件夹路径
        string outputDir = "Interface";           // 替换为生成的 C# 文件存放目录
        
        

        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // 遍历每个一级子目录
        var subDirectories = Directory.GetDirectories(apiModelsDir);
        foreach (var subDirectory in subDirectories)
        {
            string subFolderName = FormatToPascalCase1( Path.GetFileName(subDirectory)); // 一级子目录名
            string interfaceName = $"I{subFolderName.Replace("ApiModel","")}Service"; // 接口名

            // 获取子目录下的所有 .cs 文件
            var csFiles = Directory.GetFiles(subDirectory, "*.cs", SearchOption.TopDirectoryOnly);
            var methods = csFiles.Select(GenerateMethodFromClass).Where(m => !string.IsNullOrEmpty(m)).ToArray();

            // 如果没有方法，跳过
            if (methods.Length == 0) continue;

            // 生成接口内容
            string interfaceContent = GenerateInterfaceContent(interfaceName, methods);

            // 保存接口文件
            string outputFilePath = Path.Combine(outputDir, $"{interfaceName}.cs");
            File.WriteAllText(outputFilePath, interfaceContent);
            Console.WriteLine($"Generated: {outputFilePath}");
        }

        return;
        //// 创建根目录
        //if (!Directory.Exists(requestModelsDir)) Directory.CreateDirectory(requestModelsDir);
        //if (!Directory.Exists(apiModelsDir)) Directory.CreateDirectory(apiModelsDir);

        //// 遍历所有 .js 文件
        //var jsFiles = Directory.GetFiles(inputDir, "*.js", SearchOption.AllDirectories);

        //foreach (var filePath in jsFiles)
        //{
        //    try
        //    {
        //        Console.WriteLine($"Processing file: {filePath}");
        //        string content = File.ReadAllText(filePath);

        //        // 使用正则提取信息
        //        string apiEndpoint = ExtractApiEndpoint(content);
        //        (string[] dataKeys, Dictionary<string, string> dataValues) = ExtractDataKeys(content);
        //        string optionType = ExtractOptionType(content);

        //        // 如果 API 地址为空，跳过文件
        //        if (apiEndpoint == null)
        //        {
        //            Console.WriteLine($"Skipping file: {filePath} (No API endpoint found)");
        //            continue;
        //        }

        //        // 根据文件名生成子目录和类名
        //        string moduleName = Path.GetFileNameWithoutExtension(filePath);
        //        string subFolder = GetSubFolderName(moduleName);
        //        string formattedRequestModelName = FormatToPascalCase(moduleName) + "RequestModel";
        //        string formattedApiModuleName = FormatToPascalCase(moduleName) + "ApiModule";

        //        // 创建子目录
        //        string requestModelPath = Path.Combine(requestModelsDir, subFolder);
        //        string apiModelPath = Path.Combine(apiModelsDir, subFolder);
        //        if (!Directory.Exists(requestModelPath)) Directory.CreateDirectory(requestModelPath);
        //        if (!Directory.Exists(apiModelPath)) Directory.CreateDirectory(apiModelPath);

        //        // 生成 C# 类文件内容
        //        string requestModelContent = GenerateRequestModel(formattedRequestModelName, dataKeys, dataValues);
        //        string apiModuleContent = GenerateApiModule(formattedApiModuleName, apiEndpoint, formattedRequestModelName, optionType);

        //        // 保存文件
        //        string requestModelFilePath = Path.Combine(requestModelPath, $"{formattedRequestModelName}.cs");
        //        string apiModelFilePath = Path.Combine(apiModelPath, $"{formattedApiModuleName}.cs");
        //        File.WriteAllText(requestModelFilePath, requestModelContent);
        //        File.WriteAllText(apiModelFilePath, apiModuleContent);

        //        Console.WriteLine($"Generated RequestModel: {requestModelFilePath}");
        //        Console.WriteLine($"Generated ApiModule: {apiModelFilePath}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
        //    }
        //}
    }

    // 提取 API 地址
    static string ExtractApiEndpoint(string content)
    {
        var match = Regex.Match(content, @"request\(\s*`([^`]+)`");
        return match.Success ? match.Groups[1].Value : null;
    }

    // 提取 data 字段
    static (string[], Dictionary<string, string>) ExtractDataKeys(string content)
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

    // 提取 createOption 参数
    static string ExtractOptionType(string content)
    {
        var match = Regex.Match(content, @"createOption\(.*?,\s*['""]([^'""]+)['""]\)");
        return match.Success ? match.Groups[1].Value : null;
    }

    // 根据文件名确定子目录
    static string GetSubFolderName(string moduleName)
    {
        var parts = moduleName.Split('_');
        return parts.Length > 0 ? FormatToPascalCase(parts[0]) : "Default";
    }

    // 格式化为 PascalCase
    static string FormatToPascalCase(string text)
    {
        var parts = text.Split('_');
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i] = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(parts[i].ToLower());
        }
        return string.Join("", parts);
    }

    // 生成 RequestModel 类内容
    static string GenerateRequestModel(string className, string[] dataKeys, Dictionary<string, string> dataValues)
    {
        // 构造属性部分，包含 JsonProperty 注解和推断的类型
        string properties = dataKeys != null && dataKeys.Length > 0
            ? string.Join(Environment.NewLine,
                Array.ConvertAll(dataKeys, key =>
                {
                    string jsonKey = key.ToLower();
                    string type = InferType(key, dataValues.ContainsKey(key) ? dataValues[key] : null);
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

    static string InferType(string key, string value)
    {
        // 检查字段名，优先匹配常见类型
        if (key.ToLower().Contains("limit") || key.ToLower().Contains("offset") || key.ToLower().Contains("count"))
            return "int";

        if (key.ToLower().Contains("time") || key.ToLower().Contains("date"))
            return "long"; // 时间戳通常使用 long

        // 检查字段值
        if (!string.IsNullOrEmpty(value))
        {
            // 布尔值
            if (value == "true" || value == "false")
                return "bool";

            // 整数
            if (int.TryParse(value, out _))
                return "int";

            // 浮点数
            if (double.TryParse(value, out _))
                return "double";
        }

        // 默认返回 string
        return "string";
    }

    // 生成 ApiModule 类内容
    static string GenerateApiModule(string className, string apiEndpoint, string requestModelName, string optionType)
    {
        string optionTypeLine = optionType != null
            ? $"    public string OptionType {{ get; set; }} = \"{optionType}\";"
            : "// No option type specified";

        return $@"
public class {className}
{{
    public string ApiEndpoint {{ get; set; }} = ""{apiEndpoint}"";
    public {requestModelName} Data {{ get; set; }} = new {requestModelName}();
{optionTypeLine}
}}
";
    }
}