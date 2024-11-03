namespace Forge.DirectoryMapper.Core;
public sealed class DirectoryMap
{
    public DirectoryMap? Parent { get; init; }

    public List<DirectoryMap> Children { get; init; } = [];

    public required string Name { get; init; }


}
