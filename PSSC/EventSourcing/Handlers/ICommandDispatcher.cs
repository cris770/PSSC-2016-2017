
using Messages;

namespace EventSourcing.Handlers
{
    public interface ICommandDispatcher
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
