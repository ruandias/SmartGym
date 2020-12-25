using SmartGym.Domain.Entities;
using SmartGym.Domain.Interfaces;
using SmartGym.Infra.Data.Context;
using System.Collections.Generic;


namespace SmartGym.Infra.Data.Repository
{
    public class StudentRepository : BaseRepository<Student, int>, IRepositoryStudent
    {
        public StudentRepository(SqlServerDbContext sqlServerDbContext) : base(sqlServerDbContext)
        {
        }

        public void Remove(int id) =>
            base.Delete(id);


        public void Save(Student obj)
        {
            if (obj.Id == 0)
                base.Insert(obj);
            else
                base.Update(obj, _sqlServerDbContext.Entry(obj).Property(prop => prop.Name));
        }

        public Student GetById(int id) =>
            base.Select(id);

        public IList<Student> GetAll() =>
            base.Select();

    }
}
