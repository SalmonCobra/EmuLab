
namespace EmuLab.Common.Plugins;

public interface IPlugin
{
    PluginMetadata Metadata { get; }
    void OnLoad(PluginContext Context);
    void Update(PluginContext Context);
}
