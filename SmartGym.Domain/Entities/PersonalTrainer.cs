﻿using SmartGym.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace SmartGym.Domain.Entities
{
    public class PersonalTrainer
    {
        protected PersonalTrainer() { }

        private IList<Student> _students;

        public PersonalTrainer(string name, string address)
        {
            Name = name;
            Address = address;
            Status = EStatusPersonalTrainer.Active;
            _students = new List<Student>();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public EStatusPersonalTrainer Status { get; private set; }
        public IReadOnlyCollection<Student> Students { get { return _students.ToArray();  } }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }
    }
}