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

        public StringBuilder GetSourceText(StringBuilder sb)
        {
            sb.Append($"public partial class {Symbol.Name} : DirectoryMapped {{");

            foreach(var child in Children)
            {
                sb.Append(child.GetSourceText(sb));
            }

            sb.Append('}');

            return sb;
        }

    }
}
    

