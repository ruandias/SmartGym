using SmartGym.Domain.Enums;
using SmartGym.Domain.ValueTypes;

namespace SmartGym.Domain.Entities
{
    public class Student : BaseEntity<int>
    {

        public Student(int id, int personalTrainerId, int trainingCenterId , Name name) : base(id)
        {
            AddNotifications(name.contract);

            if (Valid)
            {

                Name = name;
                Status = EStatusStudent.Active;
                PersonalTrainerId = personalTrainerId;
                TrainingCenterId = trainingCenterId;
            }

        }
        protected Student() { }

        public Name Name { get; private set; }
        public EStatusStudent Status { get; private set; }

        public int TrainingCenterId { get; set; }
        public virtual TrainingCenter TrainingCenter {get; set;}

        public int PersonalTrainerId { get; set; }
        public virtual PersonalTrainer PersonalTrainer { get; set; }


    }
}