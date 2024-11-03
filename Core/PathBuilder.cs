using System.Text;

namespace Forge.DirectoryMapper.Core;
public sealed class PathBuilder
{

    readonly StringBuilder _builder = new();

    public PathBuilder(string start)
    {
        _builder.Append(start);  
    }
    public void Push(string toAdd)
    {
        _builder.Append($"{Path.DirectorySeparatorChar}{toAdd}");
    }

    public void Pop()
    {
        int lastSeperatorIndex = 0 ;

        for (int i = 0; i < _builder.Length; i++)
        {
            if (_builder[i] == Path.DirectorySeparatorChar)
            {
                lastSeperatorIndex = i;
            }
        }

        _builder.Remove(lastSeperatorIndex, _builder.Length - 1);

    }

    public override string ToString()
    {
        return _builder.ToString();
    }
}
