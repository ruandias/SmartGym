using SmartGym.Domain.Entities;
using SmartGym.Domain.Interfaces;
using SmartGym.Infra.Data.Context;
using System.Collections.Generic;


namespace SmartGym.Infra.Data.Repository
{
    public class TrainingCenterRepository : BaseRepository<TrainingCenter, int>, IRepositoryTrainingCenter
    {
        public TrainingCenterRepository(SqlServerDbContext sqlServerDbContext) : base(sqlServerDbContext)
        {
        }

        public void Remove(int id) =>
            base.Delete(id);


        public void Save(TrainingCenter obj)
        {
            if (obj.Id == 0)
                base.Insert(obj);
            else
                base.Update(obj, _sqlServerDbContext.Entry(obj).Property(prop => prop.CompanyName));
        }

        public TrainingCenter GetById(int id) =>
            base.Select(id);

        public IList<TrainingCenter> GetAll() =>
            base.Select();

    }

}
