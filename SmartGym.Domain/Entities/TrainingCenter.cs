using SmartGym.Domain.Shared.Entities;
using System.Collections.Generic;

namespace SmartGym.Domain.Entities
{
    public class TrainingCenter : Entity
    {
        protected TrainingCenter() { }

        private IList<Student> _students;

        private IList<PersonalTrainer> _personalTrainers;

        public TrainingCenter(string companyName, Address address)
        {
            CompanyName = companyName;
            Address = address;
            _students = new List<Student>();
            _personalTrainers = new List<PersonalTrainer>();
        }

        public int Id { get; private set; }
        public string CompanyName { get; private set; }
        public Address  Address { get; private set; }
        public IReadOnlyCollection<Student> Students { get; private set; }
        public IReadOnlyCollection<PersonalTrainer> PersonalTrainers { get; private set; }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

    }
}
