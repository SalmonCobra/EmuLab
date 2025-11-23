namespace EmuLab.Common;

public class EventBus : IEventBus
{
    private readonly Dictionary<Type, List<Delegate>> _handlers = new();

    public void Subscribe<TEvent>(Action<TEvent> handler)
    {
        if (!_handlers.TryGetValue(typeof(TEvent),  out var list))
        {
            list = new List<Delegate>();
            _handlers[typeof(TEvent)] = list;
        }
        list.Add(handler);
    }

    public void Publish<TEvent>(TEvent @event)
    {
        if (_handlers.TryGetValue(typeof(TEvent), out var list))
        {
            foreach (var @delegate in list)
            {
                ((Action<TEvent>)@delegate)(@event);
            }
        }
    }

    public void Unsubscribe<TEvent>(Action<TEvent> handler)
    {
        if (_handlers.TryGetValue(typeof(TEvent), out var list))
        {
            list.Remove(handler);
            if (list.Count == 0)
                _handlers.Remove(typeof(TEvent));
        }
    }
}