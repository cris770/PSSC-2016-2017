using EventSourcing.Domain;
using System;

namespace EventSourcing.Persistence
{
    public interface IRepository
    {
        T GetById<T>(Guid id) where T : EventStream, new();

        void Save(params EventStream[] streamItems);
    }
}
