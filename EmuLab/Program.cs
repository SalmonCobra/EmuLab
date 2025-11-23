using EmuLab.Common;

namespace EmuLab;

class Program
{
    static void Main(string[] args)
    {
        PluginManager.LoadPlugins();
        PluginManager.OnLoad();
        PluginManager.Update();
    }
}