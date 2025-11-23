
namespace EmuLab.Common;

public interface IPlugin
{
    string name { get; }
    string description { get; }
    Version version { get; }
    string author { get; }
    void OnLoad(PluginContext Context);
    void Update(PluginContext Context);
}
