using EventSourcing.Domain;
using System;

namespace EventSourcing.Exceptions
{
    [Serializable]
    public class EventStreamNotFoundException : EventSourceException
    {
        public EventStreamNotFoundException(StreamIdentifier identifier)
            : base($"Stream Not Found Id: {identifier.Value}")
        {
        }
    }
}