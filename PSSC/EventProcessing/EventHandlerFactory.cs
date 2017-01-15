using Data.MongoDb;
using EventSourcing.Handlers;
using EventSourcing.Persistence;
using Messages;
using Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProcessing
{
    public class EventHandlerFactory : IEventHandlerFactory
    {
        private readonly Dictionary<Type, List<Func<IHandler>>> handlerFactories = new Dictionary<Type, List<Func<IHandler>>>();

        public EventHandlerFactory(IEventStore eventStore, ICommandDispatcher dispatcher, MongoDb mongo)
        {
            RegisterHandlerFactories(eventStore, dispatcher, mongo);
        }

        private void RegisterHandlerFactories(IEventStore eventStore, ICommandDispatcher dispatcher, MongoDb mongo)
        {
            this.RegisterHandlerFactoryWithTypes(
                () => new StudyYearEventHandler(mongo),
                typeof(StudentCreated), typeof(CourseAddedForStudent));
        }

        private void RegisterHandlerFactoryWithTypes(Func<IHandler> handler, params Type[] types)
        {
            foreach (var type in types)
            {
                this.handlerFactories.Add(type, new List<Func<IHandler>> { handler });
            }
        }

        public IEnumerable<IEventHandler<TEvent>> Resolve<TEvent>(TEvent evt) where TEvent : IEvent
        {
            var evtType = evt.GetType();
            if (this.handlerFactories.ContainsKey(evtType))
            {
                var factories = this.handlerFactories[evtType];
                return factories.Select(h => (IEventHandler<TEvent>)h());
            }
            return new List<IEventHandler<TEvent>>();
        }
    }
}
