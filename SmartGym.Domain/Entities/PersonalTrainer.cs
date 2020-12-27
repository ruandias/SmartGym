using SmartGym.Domain.Enums;
using SmartGym.Domain.ValueTypes;
using System.Collections.Generic;

namespace SmartGym.Domain.Entities
{
    public class PersonalTrainer : BaseEntity<int>
    {
        protected PersonalTrainer() { }

        public PersonalTrainer(int id, int trainingCenterId, Name name) : base(id)
        {
            AddNotifications(name.contract);
            if(Valid)
            {
                Name = name;
                Status = EStatusPersonalTrainer.Active;
                this.Students = new List<Student>();
                TrainingCenterId = trainingCenterId;
            }

        }

        public Name Name { get; private set; }
        public EStatusPersonalTrainer Status { get; private set; }

        public virtual ICollection<Student> Students { get; private set; }

        public int TrainingCenterId { get; set; }
        public virtual TrainingCenter TrainingCenter { get; set; }

    }
}