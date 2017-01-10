using EventSourcing.Domain;
using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Persistence
{
    public interface IEventStore
    {
        IEnumerable<IEvent> GetByStreamId(StreamIdentifier streamId);
        void Save(List<EventStoreStream> newEvents);
    }
}
