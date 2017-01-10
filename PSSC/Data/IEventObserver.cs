using Messages;

namespace Data
{
    public interface IEventObserver
    {
        void Notify<TEvent>(TEvent evt) where TEvent : IEvent;
    }
}
