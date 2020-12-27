using SmartGym.Domain.ValueTypes;
using System.Collections.Generic;
using System.Linq;

namespace SmartGym.Domain.Entities
{
    public class TrainingCenter : BaseEntity<int>
    {

        protected TrainingCenter() { }

        public TrainingCenter(int id, CompanyName companyName) : base(id)
        {
            AddNotifications(companyName.contract);

            if (Valid)
            {
                CompanyName = companyName;
                this.Students = new List<Student>();
                this.PersonalTrainers = new List<PersonalTrainer>();

            }


        }

        public CompanyName CompanyName { get; private set; }

        public virtual ICollection<Student> Students { get; private set; }
        public virtual ICollection<PersonalTrainer> PersonalTrainers { get; private set; }

    }
}
