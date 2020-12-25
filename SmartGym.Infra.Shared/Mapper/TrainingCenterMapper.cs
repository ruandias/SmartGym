using SmartGym.Domain.Entities;
using SmartGym.Domain.Models;
using System.Collections.Generic;
using System.Linq;


namespace SmartGym.Infra.Shared.Mapper
{
    public static class TrainingCenterMapper
    {
        public static TrainingCenter ConvertToTrainingCenterEntity(this CreateTrainingCenterModel trainingCenterModel) =>
             new TrainingCenter(0, trainingCenterModel.CompanyName);

        public static TrainingCenter ConvertToTrainingCenterEntity(this UpdateTrainingCenterModel trainingCenterModel) =>
            new TrainingCenter(trainingCenterModel.Id, trainingCenterModel.CompanyName);

        public static IEnumerable<TrainingCenterModel> ConvertToTrainingCenters(this IList<TrainingCenter> trainingCenters) =>
            new List<TrainingCenterModel>(trainingCenters.Select(t => new TrainingCenterModel(t.Id, t.CompanyName.ToString())));

        public static TrainingCenterModel ConvertToTrainingCenter(this TrainingCenter trainingCenter) =>
            new TrainingCenterModel(trainingCenter.Id, trainingCenter.CompanyName.ToString());
    }
}
