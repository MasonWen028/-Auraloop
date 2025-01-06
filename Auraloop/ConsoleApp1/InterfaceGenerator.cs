using System;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class InterfaceGenerator
{
    public static void GenerateInterfaces(string sourceFolder, string targetFolder)
    {
        if (!Directory.Exists(sourceFolder) || !Directory.Exists(targetFolder))
        {
            Console.WriteLine("Source or target folder does not exist.");
            return;
        }

        foreach (var file in Directory.GetFiles(sourceFolder, "*.cs"))
        {
            var sourceCode = File.ReadAllText(file);
            var tree = CSharpSyntaxTree.ParseText(sourceCode);
            var root = tree.GetCompilationUnitRoot();

            // Find all class declarations
            var classes = root.DescendantNodes()
                .OfType<ClassDeclarationSyntax>()
                .Where(c => c.Modifiers.Any(SyntaxKind.PublicKeyword));

            foreach (var classDeclaration in classes)
            {
                // Extract class name
                var className = classDeclaration.Identifier.Text;

                // Skip classes that don't end with "Controller"
                if (!className.EndsWith("Controller", StringComparison.OrdinalIgnoreCase))
                    continue;

                // Generate interface name: Remove "Controller" and convert to camel case
                var baseName = className.Substring(0, className.Length - "Controller".Length); // Remove "Controller"
                var interfaceName = "I" + ToCamelCase(baseName) + "Service";

                // Extract public methods (excluding constructors)
                var methods = classDeclaration.Members
                    .OfType<MethodDeclarationSyntax>()
                    .Where(m => m.Modifiers.Any(SyntaxKind.PublicKeyword))
                    .Select(m =>
                    {
                        // Remove attributes like [FromBody] or [FromQuery]
                        var parameters = m.ParameterList.Parameters
                            .Select(p => p.WithAttributeLists(SyntaxFactory.List<AttributeListSyntax>()));

                        // Standardize return type as Task<ApiResponse>
                        var returnType = SyntaxFactory.ParseTypeName("Task<ApiResponse>");

                        return SyntaxFactory.MethodDeclaration(returnType, m.Identifier)
                            .WithParameterList(SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList(parameters)))
                            .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
                    });

                // Create interface declaration
                var interfaceDeclaration = SyntaxFactory.InterfaceDeclaration(interfaceName)
                    .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                    .WithMembers(SyntaxFactory.List<MemberDeclarationSyntax>(methods));

                // Wrap in namespace if applicable
                var namespaceDeclaration = root.DescendantNodes()
                    .OfType<NamespaceDeclarationSyntax>()
                    .FirstOrDefault();

                var interfaceNamespace = namespaceDeclaration != null
                    ? SyntaxFactory.NamespaceDeclaration(namespaceDeclaration.Name)
                        .WithMembers(SyntaxFactory.SingletonList<MemberDeclarationSyntax>(interfaceDeclaration))
                    : (MemberDeclarationSyntax)interfaceDeclaration;

                // Add custom using statements and remove unwanted ones
                var usingStatements = root.Usings
                    .Where(u => !u.Name.ToString().Equals("Microsoft.AspNetCore.Mvc", StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // Add the required using statement for response models
                usingStatements.Add(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("NeteaseCloudMusicSDK.Models.Response")));

                // Create a compilation unit for the interface
                var compilationUnit = SyntaxFactory.CompilationUnit()
                    .WithUsings(SyntaxFactory.List(usingStatements))
                    .WithMembers(SyntaxFactory.SingletonList(interfaceNamespace))
                    .NormalizeWhitespace();

                // Save the interface to the target folder
                var interfaceCode = compilationUnit.ToFullString();
                var outputFilePath = Path.Combine(targetFolder, $"{interfaceName}.cs");
                File.WriteAllText(outputFilePath, interfaceCode);

                Console.WriteLine($"Generated {interfaceName} in {outputFilePath}");
            }
        }

        Console.WriteLine("Interface generation completed.");
    }

    /// <summary>
    /// Converts a string to camel case format.
    /// Example: "Activate" -> "Activate", "activate" -> "Activate".
    /// </summary>
    private static string ToCamelCase(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        // Convert the first character to uppercase
        return char.ToUpper(input[0]) + input.Substring(1);
    }
}
