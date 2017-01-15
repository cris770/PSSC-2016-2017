using Data.MongoDb;
using EventProcessing;
using Messages;

namespace WebClient.Utils
{
    //TODO: use Unity or other dependency inversion framework 
    //Works like this for demo purposes only
    public class Bootstraper
    {
        public static BootstrapingResult Bootstrap()
        {
            var store = new Data.InMemoryEventStore();
            var handlerFactory = new CommandHandlerFactory(store);
            var dispatcher = new CommandDispatcher(handlerFactory);

            var mongoDb = new MongoDb();
            var eventHandlerFactory = new EventHandlerFactory(store, dispatcher, mongoDb);
            var eventDispatcher = new EventDispatcher(eventHandlerFactory);
            var eventProcessor = new EventProcessor(store, eventDispatcher);
            return new BootstrapingResult(mongoDb, dispatcher);
        }
    }

    public class BootstrapingResult
    {
        public BootstrapingResult(MongoDb mongoDb, CommandDispatcher dispatcher)
        {
            this.MongoDb = mongoDb;
            this.dispatcher = dispatcher;
        }
        private readonly CommandDispatcher dispatcher;
        public MongoDb MongoDb { get; private set; }

        public void Send<TCommand>(TCommand cmd) where TCommand : ICommand
        {
            dispatcher.Send(cmd);
        }
    }
}