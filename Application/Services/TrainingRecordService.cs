using Application.Abstractions;
using Application.Emails;
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
        private readonly IEmailSender emailSender;

        public TrainingRecordService(IMapper mapper, IUnitOfWork unitOfWork, IEmailSender emailSender)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.emailSender = emailSender;
        }

        public Task<TrainingRecordViewModel> Add(TrainingRecordModel model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteBulk(IReadOnlyCollection<Guid> IDs)
        {
            var trainingMarks = await unitOfWork.TrainingMarkRepository.GetAsync(x => IDs.Contains(x.TrainingRecordId));
            var trainingRecords = await unitOfWork.TrainingRecordRepository.GetAsync(x => IDs.Contains(x.Id));

            unitOfWork.TrainingMarkRepository.RemoveRange(trainingMarks);
            unitOfWork.TrainingRecordRepository.RemoveRange(trainingRecords);

            await unitOfWork.SaveAsync();
        }

        public async Task<TrainingRecordViewModel> Edit(Guid id, TrainingRecordModel model)
        {
            var trainingRecord = await unitOfWork.TrainingRecordRepository.GetByIdAsync(id);

            if (trainingRecord != null)
            {
                if (model.Note is not null && trainingRecord.Note != model.Note)
                {
                    trainingRecord.Note = model.Note;
                }
                if (model.IsPresent.HasValue && trainingRecord.IsPresent != model.IsPresent)
                {
                    trainingRecord.IsPresent = model.IsPresent.Value;
                }

                unitOfWork.TrainingRecordRepository.Update(trainingRecord);
                await unitOfWork.SaveAsync();
            }

            return mapper.Map<TrainingRecordViewModel>(trainingRecord);
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

        public Task SendRecordByEmail(Guid recordId)
        {
            throw new NotImplementedException();
        }
    }
}
