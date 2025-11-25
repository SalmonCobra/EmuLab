using System.Reflection;

namespace EmuLab.Common.Plugins;

public class PluginManager
{
    public static List<IPlugin> Instances { get; } = [];
    
    public static void LoadPlugins()
    {
        foreach (string pluginfile in Directory.GetFiles("Plugins", "*.dll"))
        {
            Assembly assembly = Assembly.LoadFrom(pluginfile);
            var pluginTypes = assembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (var pluginType in pluginTypes)
            {
                IPlugin instance = (IPlugin)Activator.CreateInstance(pluginType);
                Instances.Add(instance);
                Console.WriteLine($"Loaded plugin: {instance.Metadata.Name} v{instance.Metadata.Version} (by {instance.Metadata.Author})");
            }
        }
        Console.WriteLine();
    }

    public static void OnLoad()
    {
        foreach (IPlugin plugin in Instances)
            plugin.OnLoad(Core.Context);
    }

    public static void Update()
    {
        foreach (IPlugin plugin in Instances)
            plugin.Update(Core.Context);
    }
}