using Messages;

namespace EventSourcing.Handlers
{
    public interface IEventHandler<in TEvent> : IHandler where TEvent : IEvent
    {
        void Handle(TEvent cmd);

    }
}
