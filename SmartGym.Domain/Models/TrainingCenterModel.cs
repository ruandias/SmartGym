
namespace SmartGym.Domain.Models
{
    public class TrainingCenterModel
    {
        public TrainingCenterModel(int id, string companyName)
        {
            Id = id;
            CompanyName = companyName;
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
    }

}
