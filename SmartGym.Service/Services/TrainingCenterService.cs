using Flunt.Validations;
using SmartGym.Domain.Interfaces;
using SmartGym.Domain.Models;
using SmartGym.Infra.Shared.Contexts;
using SmartGym.Infra.Shared.Mapper;
using System.Collections.Generic;

namespace SmartGym.Service.Services
{
    public class TrainingCenterService : IServiceTrainingCenter
    {
        private readonly IRepositoryTrainingCenter _repositoryTrainingCenter;
        private readonly NotificationContext _notificationContext;

        public TrainingCenterService(IRepositoryTrainingCenter repositoryTrainingCenter, NotificationContext notificationContext)
        {
            _repositoryTrainingCenter = repositoryTrainingCenter;
            _notificationContext = notificationContext;
        }

        public IEnumerable<TrainingCenterModel> RecoverAll()
        {
            var trainingCenters = _repositoryTrainingCenter.GetAll();
            return trainingCenters.ConvertToTrainingCenters();
        }

        public TrainingCenterModel RecoverById(int id)
        {
            var trainingCenter = _repositoryTrainingCenter.GetById(id);
            return trainingCenter.ConvertToTrainingCenter();
        }

        public void Delete(int id) =>
            _repositoryTrainingCenter.Remove(id);

        public TrainingCenterModel Insert(CreateTrainingCenterModel trainingCenterModel)
        {
            var trainingCenter = trainingCenterModel.ConvertToTrainingCenterEntity();
            _notificationContext.AddNotifications(trainingCenter.Notifications);

            if (_notificationContext.Invalid)
                return default;

            _repositoryTrainingCenter.Save(trainingCenter);
            return trainingCenter.ConvertToTrainingCenter();
        }


        public TrainingCenterModel Update(int id, UpdateTrainingCenterModel trainingCenterModel)
        {
            if (id != trainingCenterModel.Id)
            {
                _notificationContext.AddNotifications(new Contract().AreNotEquals(id, trainingCenterModel.Id, nameof(id), "Training Center not found."));

                return default;
            }

            var trainingCenter = trainingCenterModel.ConvertToTrainingCenterEntity();
            _notificationContext.AddNotifications(trainingCenter.Notifications);

            if (_notificationContext.Invalid)
                return default;

            _repositoryTrainingCenter.Save(trainingCenter);
            return trainingCenter.ConvertToTrainingCenter();
        }
    }

}
