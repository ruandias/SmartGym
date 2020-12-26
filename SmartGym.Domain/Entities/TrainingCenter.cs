using SmartGym.Domain.ValueTypes;
using System.Collections.Generic;
using System.Linq;

namespace SmartGym.Domain.Entities
{
    public class TrainingCenter : BaseEntity<int>
    {

        protected TrainingCenter() { }

        private IList<Student> _students;
        private IList<PersonalTrainer> _personalTrainers;



        public TrainingCenter(int id, CompanyName companyName) : base(id)
        {
            AddNotifications(companyName.contract);

            if (Valid)
            {
                CompanyName = companyName;
                _students = new List<Student>();
                _personalTrainers = new List<PersonalTrainer>();
            }


        }

        public CompanyName CompanyName { get; private set; }

        public IReadOnlyCollection<Student> Students { get { return _students.ToArray(); } }
        public virtual IReadOnlyCollection<PersonalTrainer> PersonalTrainers { get { return _personalTrainers.ToArray(); } }


    }
}
