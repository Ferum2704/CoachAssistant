using Application.Services.IService;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace Application.Services
{
    public class TrainingRecordService : ITrainingRecordService
    {
        public Task<TrainingRecordViewModel> Add(TrainingRecordModel model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(Guid id, TrainingRecordModel model)
        {
            throw new NotImplementedException();
        }

        public Task<TrainingRecordViewModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
