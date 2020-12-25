using System.Collections.Generic;
using SmartGym.Domain.Entities;


namespace SmartGym.Domain.Interfaces
{
    public interface IRepositoryPersonalTrainer
    {
        void Save(PersonalTrainer obj);

        void Remove(int id);

        PersonalTrainer GetById(int id);

        IList<PersonalTrainer> GetAll();
    }
}
