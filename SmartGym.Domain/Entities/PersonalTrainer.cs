using SmartGym.Domain.Enums;
using System.Collections.Generic;

namespace SmartGym.Domain.Entities
{
    public class PersonalTrainer
    {
        protected PersonalTrainer() { }

        public PersonalTrainer(string name, string address)
        {
            Name = name;
            Address = address;
            Status = EStatusPersonalTrainer.Active;
            Students = new List<Student>();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public EStatusPersonalTrainer Status { get; private set; }
        public List<Student> Students { get; private set; }
    }
}