using SmartGym.Domain.Entities;
using System.Collections.Generic;


namespace SmartGym.Domain.Interfaces
{
    public interface IRepositoryTrainingCenter
    {
        void Save(TrainingCenter obj);

        void Remove(int id);

        TrainingCenter GetById(int id);

        IList<TrainingCenter> GetAll();
    }
}
