using System;
using System.Collections.Generic;

namespace SmartGym.Domain.Entities
{
    public class TrainingCenter
    {
        protected TrainingCenter() { }

        private IList<Student> _students;

        private IList<PersonalTrainer> _personalTrainers;

        public TrainingCenter(string name, string address)
        {
            Name = name;
            Address = address;
            _students = new List<Student>();
            _personalTrainers = new List<PersonalTrainer>();
        }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public string  Address { get; private set; }
        public IReadOnlyCollection<Student> Students { get; private set; }
        public IReadOnlyCollection<PersonalTrainer> PersonalTrainers { get; private set; }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

    }
}
