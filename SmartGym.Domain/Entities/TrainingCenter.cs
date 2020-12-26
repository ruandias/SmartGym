using SmartGym.Domain.ValueTypes;
using System.Collections.Generic;

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
            }


        }

        public CompanyName CompanyName { get; private set; }

        public virtual IEnumerable<Student> Students { get; }
        public virtual IEnumerable<PersonalTrainer> PersonalTrainers { get; }


    }
}
