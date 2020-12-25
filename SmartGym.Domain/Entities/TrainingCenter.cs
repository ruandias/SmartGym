using System.Collections.Generic;

namespace SmartGym.Domain.Entities
{
    public class TrainingCenter : BaseEntity<int>
    {

        private IList<Student> _students;

        private IList<PersonalTrainer> _personalTrainers;
        protected TrainingCenter() { }


        public TrainingCenter(int id, string companyName) : base(id)
        {
            AddNotification(companyName, "CompanyName");

            if(Valid)
            {
                CompanyName = companyName;
                _students = new List<Student>();
                _personalTrainers = new List<PersonalTrainer>();
            }


        }

        public string CompanyName { get; private set; }
        public IReadOnlyCollection<Student> Students { get; private set; }
        public IReadOnlyCollection<PersonalTrainer> PersonalTrainers { get; private set; }

    }
}
