using System;

namespace Models.Common
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        public TId Id { get; protected set; }
        protected Entity(TId id)
        {
            if(object.Equals(id, default(TId)))
            {
                throw new ArgumentException("The Id cannot be the type's default value", "id");
            }
            this.Id = id;
        }

        public override bool Equals(object other)
        {
            var result = base.Equals(other);
            if(other != null && other is Entity<TId>)
            {
                result = this.Equals(other as Entity<TId>);
            }
            return result;
        }
        public bool Equals(Entity<TId> other)
        {
            bool result = false;
            if (other != null)
            {
                result = this.Id.Equals(other.Id);
            }
            return result;
        }
    }
}
