using SmartGym.Domain.Entities;

namespace SmartGym.Domain.Models
{
    public class StudentModel
    {
        public StudentModel(int id, string name, Address address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set;  }

    }
}
