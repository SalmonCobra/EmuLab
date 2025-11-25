using System.Collections.Frozen;
using System.Runtime.CompilerServices;

namespace EmuLab.Common.Plugins;

public sealed class PluginMetadata(string name, Version version, string author, string description, Dictionary<string, Version>? optionalDependencies = null, Dictionary<string, Version>? requiredDependencies = null)
{
    public string Name { get; } = name;
    public string Author { get; } = author;
    public string Description { get; } = description;
    public Version Version { get; } = version;
    public Dictionary<string, Version> OptionalDependencies { get; } = optionalDependencies ?? new();
    public Dictionary<string, Version> RequiredDependencies { get; } = requiredDependencies ?? new();
}
