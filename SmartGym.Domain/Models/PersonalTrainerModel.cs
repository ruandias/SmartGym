﻿namespace SmartGym.Domain.Models
{
    class PersonalTrainerModel
    {
        public PersonalTrainerModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
