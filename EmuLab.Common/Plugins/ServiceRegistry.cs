using System.Runtime.CompilerServices;

namespace EmuLab.Common.Plugins;

public class ServiceRegistry
{
    public Dictionary<ServiceId, object> Services { get; private set; } = new();

    public void RegisterService(ServiceId id, object service)
    {
        Services.TryAdd(id, service);
    }
}

public readonly record struct ServiceId(string Plugin, string ServiceName)
{
    public override string ToString() => $"{Plugin}:{ServiceName}";
}