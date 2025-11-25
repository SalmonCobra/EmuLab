using EmuLab.Common;
using EmuLab.Common.Plugins;


namespace EmuLab;

class Program
{
    static void Main(string[] args)
    {
        PluginManager.LoadPlugins();
        PluginManager.OnLoad();
        PluginManager.Update();
        Console.WriteLine();
        Console.WriteLine(Core.Context.Services.Services[new ServiceId("MyPlugin", "MyPlugin")]);
    }
}