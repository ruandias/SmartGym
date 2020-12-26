using SmartGym.Domain.Enums;
using SmartGym.Domain.ValueTypes;

namespace SmartGym.Domain.Entities
{
    public class Student : BaseEntity<int>
    {

        public Student(int id, Name name) : base(id)
        {
            AddNotifications(name.contract);

            if (Valid)
            {

                Name = name;
                Status = EStatusStudent.Active;
            }

        }
        protected Student() { }

        public Name Name { get; private set; }
        public EStatusStudent Status { get; private set; }

        public int TrainingCenterId { get; private set; }
        public virtual TrainingCenter TrainingCenter { get; private set; }

        public int PersonalTrainerId { get; private set; }

        public virtual PersonalTrainer PersonalTrainer { get; private set; }


    }
}