using Flunt.Validations;
using SmartGym.Domain.Interfaces;
using SmartGym.Domain.Models;
using Infra.Shared.Contexts;
using Infra.Shared.Mapper;
using System.Collections.Generic;

namespace SmartGym.Service.Services
{
    public class PersonalTrainerService : IServicePersonalTrainer
    {
        private readonly IRepositoryPersonalTrainer _repositoryPersonalTrainer;
        private readonly NotificationContext _notificationContext;

        public PersonalTrainerService(IRepositoryPersonalTrainer repositoryPersonalTrainer, NotificationContext notificationContext)
        {
            _repositoryPersonalTrainer = repositoryPersonalTrainer;
            _notificationContext = notificationContext;
        }

        public IEnumerable<PersonalTrainerModel> RecoverAll()
        {
            var personalTrainers = _repositoryPersonalTrainer.GetAll();
            return personalTrainers.ConvertToPersonalTrainers();
        }

        public PersonalTrainerModel RecoverById(int id)
        {
            var personalTrainer = _repositoryPersonalTrainer.GetById(id);
            return personalTrainer.ConvertToPersonalTrainer();
        }

        public void Delete(int id) =>
            _repositoryPersonalTrainer.Remove(id);

        public PersonalTrainerModel Insert(CreatePersonalTrainerModel personalTrainerModel)
        {
            var personalTrainer = personalTrainerModel.ConvertToPersonalTrainerEntity();
            _notificationContext.AddNotifications(personalTrainer.Notifications);

            if (_notificationContext.Invalid)
                return default;

            _repositoryPersonalTrainer.Save(personalTrainer);
            return personalTrainer.ConvertToPersonalTrainer();
        }


        public PersonalTrainerModel Update(int id, UpdatePersonalTrainerModel personalTrainerModel)
        {
            if (id != personalTrainerModel.Id)
            {
                _notificationContext.AddNotifications(new Contract().AreNotEquals(id, personalTrainerModel.Id, nameof(id), "Personal Trainer not found."));

                return default;
            }

            var personalTrainer = personalTrainerModel.ConvertToPersonalTrainerEntity();
            _notificationContext.AddNotifications(personalTrainer.Notifications);

            if (_notificationContext.Invalid)
                return default;

            _repositoryPersonalTrainer.Save(personalTrainer);
            return personalTrainer.ConvertToPersonalTrainer();
        }
    }
}
