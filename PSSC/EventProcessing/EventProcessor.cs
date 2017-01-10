using Data;
using EventSourcing.Handlers;
using Messages;
using System;

namespace EventProcessing
{
    public class EventProcessor : IEventObserver
    {
        private readonly IEventDispatcher dispatcher;
        private Action unsubscribe;

        public EventProcessor(InMemoryEventStore store, IEventDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
            this.unsubscribe = store.Subscribe(this);
        }

        public void Notify<TEvent>(TEvent evt) where TEvent : IEvent
        {
            dispatcher.Send(evt);
        }
    }
}
