using Application.Abstractions;
using Application.Services.IService;
using AutoMapper;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace Application.Services
{
    public class TrainingRecordService : ITrainingRecordService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TrainingRecordService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public Task<TrainingRecordViewModel> Add(TrainingRecordModel model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Edit(Guid id, TrainingRecordModel model)
        {
            var trainingRecord = await unitOfWork.TrainingRecordRepository.GetByIdAsync(id);

            if (trainingRecord != null)
            {
                if (model.Note is not null && trainingRecord.Note != model.Note)
                {
                    trainingRecord.Note = model.Note;
                }
                else if (model.IsPresent.HasValue && trainingRecord.IsPresent != model.IsPresent)
                {
                    trainingRecord.IsPresent = model.IsPresent.Value;
                }

                unitOfWork.TrainingRecordRepository.Update(trainingRecord);
                await unitOfWork.SaveAsync();
            }
        }

        public async Task<TrainingRecordViewModel> Get(Guid id)
        {
            var trainingRecord = await unitOfWork.TrainingRecordRepository.GetByIdAsync(id);

            return mapper.Map<TrainingRecordViewModel>(trainingRecord);
        }

        public Task<IReadOnlyCollection<TrainingRecordViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
