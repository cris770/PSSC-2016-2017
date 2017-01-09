using Messages;

namespace EventSourcing.Handlers
{
    public interface ICommandHandler<in TCommand> : IHandler where TCommand : ICommand
    {
        void Handle(TCommand cmd);
    }
}
