namespace EmuLab.Common.Plugins;

public class PluginContext
{
    public EventBus Events = new EventBus();
    public ServiceRegistry Services = new ServiceRegistry();
}