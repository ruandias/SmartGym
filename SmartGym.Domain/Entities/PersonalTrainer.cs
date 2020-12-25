using SmartGym.Domain.Enums;
using SmartGym.Domain.ValueTypes;
using System.Collections.Generic;
using System.Linq;

namespace SmartGym.Domain.Entities
{
    public class PersonalTrainer : BaseEntity<int>
    {
        protected PersonalTrainer() { }

        private IList<Student> _students;

        public PersonalTrainer(int id, Name name) : base(id)
        {
            AddNotifications(name.contract);
            if(Valid)
            {
                Name = name;
                Status = EStatusPersonalTrainer.Active;
                _students = new List<Student>();
            }

        }

        public Name Name { get; private set; }
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