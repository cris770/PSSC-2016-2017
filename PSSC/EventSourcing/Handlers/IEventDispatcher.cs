using Messages;

namespace EventSourcing.Handlers
{
    public interface IEventDispatcher
    {
        void Send<TEvent>(TEvent evt) where TEvent : IEvent;
    }
}
