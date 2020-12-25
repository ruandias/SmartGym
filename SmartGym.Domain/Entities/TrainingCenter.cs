using System.Collections.Generic;

namespace SmartGym.Domain.Entities
{
    public class TrainingCenter : BaseEntity<int>
    {
        protected TrainingCenter() { }

        private IList<Student> _students;

        private IList<PersonalTrainer> _personalTrainers;

        public TrainingCenter(string companyName)
        {
            CompanyName = companyName;
            _students = new List<Student>();
            _personalTrainers = new List<PersonalTrainer>();
        }

        public string CompanyName { get; private set; }
        public IReadOnlyCollection<Student> Students { get; private set; }
        public IReadOnlyCollection<PersonalTrainer> PersonalTrainers { get; private set; }

    }
}
