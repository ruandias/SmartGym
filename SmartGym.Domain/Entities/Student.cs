using SmartGym.Domain.Enums;

namespace SmartGym.Domain.Entities
{
    public class Student
    {
        protected Student() { }

        public Student(string name, string address)
        {
            Name = name;
            Address = address;
            Status = EStatusStudent.Active;
        }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public EStatusStudent Status { get; private set; }
    }
}