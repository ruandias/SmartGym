using SmartGym.Domain.Enums;
using SmartGym.Domain.Shared.Entities;
using SmartGym.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace SmartGym.Domain.Entities
{
    public class PersonalTrainer : Entity
    {
        protected PersonalTrainer() { }

        private IList<Student> _students;

        public PersonalTrainer(string name, Address address)
        {
            Name = name;
            Address = address;
            Status = EStatusPersonalTrainer.Active;
            _students = new List<Student>();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public EStatusPersonalTrainer Status { get; private set; }
        public IReadOnlyCollection<Student> Students { get { return _students.ToArray();  } }
        public int IdTrainingCenter { get; private set; }
        public TrainingCenter TrainingCenter { get; private set; }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }
    }
}