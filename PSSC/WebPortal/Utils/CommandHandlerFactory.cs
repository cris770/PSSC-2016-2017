using EventSourcing.Exceptions;
using EventSourcing.Handlers;
using EventSourcing.Persistence;
using Messages;
using Models.Contexts.Deanship;
using Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Utils
{
    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly Dictionary<Type, Func<IHandler>> handlerFactories = new Dictionary<Type, Func<IHandler>>();

        public CommandHandlerFactory(IEventStore eventStore)
        {
            Func<IRepository> newTransientRepo = () => new Repository(eventStore);

            this.RegisterHandlerFactoryWithTypes(
                () => new StudyYearHandler(newTransientRepo()),
                typeof(CreateNewStudent), typeof(AddCourseForStudent));

       
        }

        private void RegisterHandlerFactoryWithTypes(Func<IHandler> handler, params Type[] types)
        {
            foreach (var type in types)
            {
                this.handlerFactories.Add(type, handler);
            }
        }

        public ICommandHandler<TCommand> Resolve<TCommand>() where TCommand : ICommand
        {
            if (this.handlerFactories.ContainsKey(typeof(TCommand)))
            {
                var handler = this.handlerFactories[typeof(TCommand)]() as ICommandHandler<TCommand>;
                if (handler != null)
                {
                    return handler;
                }
            }
            throw new NoCommandHandlerRegisteredException(typeof(TCommand));
        }
    }
}