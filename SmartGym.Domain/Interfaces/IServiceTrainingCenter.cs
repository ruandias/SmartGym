using SmartGym.Domain.Models;
using System.Collections.Generic;


namespace SmartGym.Domain.Interfaces
{
    public class IServiceTrainingCenter
    {
        TrainingCenterModel Insert(CreateTrainingCenterModel trainingCenterModel);

        TrainingCenterModel Update(int id, UpdateTrainingCenterModel trainingCenterModel);

        void Delete(int id);

        TrainingCenterModel RecoverById(int id);

        IEnumerable<TrainingCenterModel> RecoverAll();
    }
}
