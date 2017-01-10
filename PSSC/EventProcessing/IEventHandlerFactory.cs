using EventSourcing.Handlers;
using Messages;
using System.Collections.Generic;

namespace EventProcessing
{
    public interface IEventHandlerFactory
    {
        IEnumerable<IEventHandler<TEvent>> Resolve<TEvent>(TEvent evt) where TEvent : IEvent;
    }
}
