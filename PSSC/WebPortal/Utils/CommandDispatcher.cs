using EventSourcing.Handlers;
using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Utils
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly ICommandHandlerFactory factory;

        public CommandDispatcher(ICommandHandlerFactory factory)
        {
            this.factory = factory;
        }
        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = this.factory.Resolve<TCommand>();
            handler.Handle(command);
        }
    }
}