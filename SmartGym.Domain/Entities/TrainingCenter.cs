using System;
using System.Collections.Generic;

namespace SmartGym.Domain.Entities
{
    public class TrainingCenter
    {
        protected TrainingCenter() { }

        public TrainingCenter(string name, string address)
        {
            Name = name;
            Address = address;
            Students = new List<Student>();
            PersonalTrainers = new List<PersonalTrainer>();

        }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public string  Address { get; private set; }
        public List<Student> Students { get; private set; }
        public List<PersonalTrainer> PersonalTrainers { get; private set; }


    }
}
