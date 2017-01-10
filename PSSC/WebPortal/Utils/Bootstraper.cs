using Data.MongoDb;
using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Utils
{
    //TODO: use Unity or other dependency inversion framework 
    //Works like this for demo purposes only
    public class Bootstraper
    {
    }

    public class BottstrapingResult
    {
        public BottstrapingResult(MongoDb mongoDb, CommandDispatcher dispatcher)
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