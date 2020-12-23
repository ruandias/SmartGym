using SmartGym.Domain.Enums;
using SmartGym.Domain.Shared;
using SmartGym.Domain.Shared.Entities;
using SmartGym.Domain.ValueObjects;

namespace SmartGym.Domain.Entities
{
    public class Student : Entity
    {
        protected Student() { }

        public Student(Name name, Address address)
        {
            Name = name;
            Address = address;
            Status = EStatusStudent.Active;
        }

        public long Id { get; private set; }
        public Name Name { get; private set; }
        public Address Address { get; private set; }
        public EStatusStudent Status { get; private set; }
    }
}