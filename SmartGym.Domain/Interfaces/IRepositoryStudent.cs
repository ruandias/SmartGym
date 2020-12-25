using System.Collections.Generic;
using SmartGym.Domain.Entities;


namespace SmartGym.Domain.Interfaces
{
    public interface IRepositoryStudent
    {
        void Save(Student obj);

        void Remove(int id);

        Student GetById(int id);

        IList<Student> GetAll();
    }
}
