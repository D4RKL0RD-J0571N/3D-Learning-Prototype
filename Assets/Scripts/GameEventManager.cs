using System;
using System.Collections.Generic;

/// <summary>
/// Central hub for publishing and subscribing to game-wide events.
/// </summary>
public static class GameEventManager
{
    // Maps event types to the multicast relay that invokes all handlers.
    private static readonly Dictionary<Type, Action<GameEvent>> EventHandlers
        = new Dictionary<Type, Action<GameEvent>>();

    // Keeps track of original delegates so they can be removed correctly.
    private static readonly Dictionary<Delegate, Action<GameEvent>> HandlerLookup
        = new Dictionary<Delegate, Action<GameEvent>>();

    /// <summary>
    /// Subscribes a listener to events of type TEvent.
    /// </summary>
    /// <typeparam name="TEvent">Type of event to listen for.</typeparam>
    /// <param name="handler">Callback invoked when the event is published.</param>
    public static void Subscribe<TEvent>(Action<TEvent> handler)
        where TEvent : GameEvent
    {
        if (HandlerLookup.ContainsKey(handler))
            return;

        // Wrap the typed handler in an untyped relay.
        Action<GameEvent> relay = (e) => handler((TEvent)e);
        HandlerLookup[handler] = relay;

        if (EventHandlers.TryGetValue(typeof(TEvent), out var existing))
        {
            EventHandlers[typeof(TEvent)] = existing + relay;
        }
        else
        {
            EventHandlers[typeof(TEvent)] = relay;
        }
    }

    /// <summary>
    /// Unsubscribes a listener from events of type TEvent.
    /// </summary>
    /// <typeparam name="TEvent">Type of event to stop listening for.</typeparam>
    /// <param name="handler">The previously subscribed callback.</param>
    public static void Unsubscribe<TEvent>(Action<TEvent> handler)
        where TEvent : GameEvent
    {
        if (!HandlerLookup.TryGetValue(handler, out var relay))
            return;

        if (EventHandlers.TryGetValue(typeof(TEvent), out var existing))
        {
            var updated = existing - relay;
            if (updated == null)
                EventHandlers.Remove(typeof(TEvent));
            else
                EventHandlers[typeof(TEvent)] = updated;
        }

        HandlerLookup.Remove(handler);
    }

    /// <summary>
    /// Publishes an event instance to all subscribed listeners.
    /// </summary>
    /// <param name="eventInstance">The event object to broadcast.</param>
    public static void Publish(GameEvent eventInstance)
    {
        var type = eventInstance.GetType();
        if (EventHandlers.TryGetValue(type, out var handlers))
        {
            handlers.Invoke(eventInstance);
        }
    }

    /// <summary>
    /// Clears all subscriptions. Use with caution!
    /// </summary>
    public static void ClearAll()
    {
        EventHandlers.Clear();
        HandlerLookup.Clear();
    }
}

/// <summary>
/// Base class for all game events. 
/// Derive your custom event types from this.
/// </summary>
public abstract class GameEvent
{
    // You can add common event data here if needed.
}
