
namespace SmartGym.Domain.Models
{
    public class UpdateStudentModel
    {
        public int Id { get; set; }
        public int PersonalTrainerId { get; set; }
        public int TrainingCenterId { get; set; }
        public string Name { get; set; }
    }
}
