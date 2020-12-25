using System.Collections.Generic;
using SmartGym.Domain.Models;


namespace SmartGym.Domain.Interfaces
{
    public interface IServicePersonalTrainer
    {
        PersonalTrainerModel Insert(CreatePersonalTrainerModel personalTrainerModel);

        PersonalTrainerModel Update(int id, UpdatePersonalTrainerModel personalTrainerModel);

        void Delete(int id);

        PersonalTrainerModel RecoverById(int id);

        IEnumerable<PersonalTrainerModel> RecoverAll();
    }
}
