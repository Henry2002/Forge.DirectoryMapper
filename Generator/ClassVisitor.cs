using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Text;

namespace Generator
{
    public sealed class ClassVisitor
    {
        public ClassVisitor? Parent { get; set; }

        public List<ClassVisitor> Children { get; set; } = [];

        public INamedTypeSymbol Symbol { get; set; } 

        public StringBuilder AddSourceText(StringBuilder sb)
        {
            sb.AppendLine($"public partial class {Symbol.Name} : DirectoryMappedBase {{");


            sb.AppendLine($"static {Symbol.Name}() " +
                "{" +
                
                "}"
                );

            foreach(var child in Children)
            {
                child.AddSourceText(sb);
            }

            sb.AppendLine("}");

            return sb;
        }

    }
}
    

