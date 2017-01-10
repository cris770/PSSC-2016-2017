using EventSourcing.Handlers;
using Messages;

namespace WebClient.Utils
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<TCommand> Resolve<TCommand>() where TCommand : ICommand;
    }
}
