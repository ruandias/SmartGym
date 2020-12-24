using System;
using SmartGym.Domain.Shared.ValueObjects;

namespace SmartGym.Domain.Shared.Entities
{
    public abstract class Entity : ValueObject
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
