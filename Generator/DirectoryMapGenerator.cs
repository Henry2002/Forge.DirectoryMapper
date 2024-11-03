using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generator
{

    [Generator]
    public class DirectoryMapGenerator : IIncrementalGenerator
    {

        const string DirectoryMappedAtrributeSource = """
                        namespace Forge.DirectoryMapper;

                        [AttributeUsage(AttributeTargets.Class)]
                        public class DirectoryMappedAttribute : Attribute;
            """;
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            context.RegisterPostInitializationOutput(ctx => ctx.AddSource(
                "DirectoryMappedAttribute.g.cs", 
                SourceText.From(DirectoryMappedAtrributeSource,
                Encoding.UTF8)));


            var directoriesToMap = context.SyntaxProvider
                 .CreateSyntaxProvider(
                     predicate: static (s, _) => IsSyntaxTargetForGeneration(s),
                     transform: static (ctx, _) => GetSemanticTargetForGeneration(ctx))
                 .Where(static m => m is not null);

            context.RegisterSourceOutput(directoriesToMap,
                static (spc, source) => spc.AddSource(
                    $"{source.Symbol.Name}.g.cs",
                    source.GetSourceText(new StringBuilder()).ToString()));
        }


        static bool IsSyntaxTargetForGeneration(SyntaxNode node)
        {
            return node is ClassDeclarationSyntax { AttributeLists.Count: > 0 };

        }

        static ClassVisitor? GetSemanticTargetForGeneration(GeneratorSyntaxContext context)
        {
            var classDeclarationSyntax = (ClassDeclarationSyntax)context.Node;

            foreach (var attributeListSyntax in classDeclarationSyntax.AttributeLists)
            {
                foreach (var attributeSyntax in attributeListSyntax.Attributes)
                {
                    if (context.SemanticModel.GetSymbolInfo(attributeSyntax).Symbol is not IMethodSymbol attributeSymbol)
                    {
                        continue;
                    }

                    var attributeContainingTypeSymbol = attributeSymbol.ContainingType;
                    var fullName = attributeContainingTypeSymbol.ToDisplayString();

                    if (fullName == "Forge.DirectoryMapper.DirectoryMappedAttribute")
                    {
                        return GetGeneratedDirectoryMap(context.SemanticModel, classDeclarationSyntax);
                    }
                }
            }


            return null;
        }

        static ClassVisitor? GetGeneratedDirectoryMap(SemanticModel semanticModel, SyntaxNode classDeclarationSyntax)
        {
            if (semanticModel.GetDeclaredSymbol(classDeclarationSyntax) is not INamedTypeSymbol classSymbol)
            {
                return null;
            }

            var className = classSymbol.ToString();

            var root = new ClassVisitor()
            {
                Symbol = classSymbol,
                Parent = null,
            };

            var leaf = root;

            var dfsStack = new Stack<INamedTypeSymbol>();

            while (dfsStack.Count > 0)
            {
                var toEvaluate = dfsStack.Pop();

                var isPartial = toEvaluate.DeclaringSyntaxReferences
                    .Any(syntax => syntax.GetSyntax() is BaseTypeDeclarationSyntax declaration
                    && declaration.Modifiers
                        .Any(modifier => modifier.IsKind(SyntaxKind.PartialKeyword)));

                if (!isPartial) continue;

                while (!SymbolEqualityComparer.Default.Equals(toEvaluate.ContainingSymbol, leaf.Symbol))
                {
                    leaf = leaf.Parent;

                    if (leaf is null) break;
                }

                if (leaf is null) break;

                leaf.Children.Add(new ClassVisitor
                {
                    Parent = leaf,
                    Symbol = toEvaluate,
                });


                foreach (var node in toEvaluate.GetMembers().Where(member => member is INamedTypeSymbol))
                {
                    dfsStack.Push((INamedTypeSymbol)node);
                }

            }

            return root;

        }

    }
}
