using SmartGym.Domain.Enums;
using SmartGym.Domain.Shared;
using SmartGym.Domain.Shared.Entities;
using SmartGym.Domain.ValueObjects;

namespace SmartGym.Domain.Entities
{
    public class Student : Entity
    {
        protected Student() { }

        public Student(string name, Address address)
        {
            Name = name;
            Address = address;
            Status = EStatusStudent.Active;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public EStatusStudent Status { get; private set; }

        public int IdTrainingCenter { get; private set; }
        public TrainingCenter TrainingCenter { get; private set; }

        public int IdPersonalTrainer { get; private set; }
        public PersonalTrainer PersonalTrainer { get; private set; }

    }
}