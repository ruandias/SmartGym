using SmartGym.Domain.Entities;
using SmartGym.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Shared.Mapper
{
    public static class PersonalTrainerMapper
    {
        public static PersonalTrainer ConvertToPersonalTrainerEntity(this CreatePersonalTrainerModel personalTrainerModel) =>
             new PersonalTrainer(0, personalTrainerModel.TrainingCenterId, personalTrainerModel.Name);

        public static PersonalTrainer ConvertToPersonalTrainerEntity(this UpdatePersonalTrainerModel personalTrainerModel) =>
            new PersonalTrainer(personalTrainerModel.Id, personalTrainerModel.TrainingCenterId,personalTrainerModel.Name);

        public static IEnumerable<PersonalTrainerModel> ConvertToPersonalTrainers(this IList<PersonalTrainer> personalTrainers) =>
            new List<PersonalTrainerModel>(personalTrainers.Select(s => new PersonalTrainerModel(s.Id, s.Name.ToString())));

        public static PersonalTrainerModel ConvertToPersonalTrainer(this PersonalTrainer personalTrainer) =>
            new PersonalTrainerModel(personalTrainer.Id, personalTrainer.Name.ToString());
    }
}
