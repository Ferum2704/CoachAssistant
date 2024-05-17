using Application.Abstractions;
using Application.Services.IService;
using AutoMapper;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;
using Domain.Entities;

namespace Application.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TrainingService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<TrainingViewModel> Add(TrainingModel model)
        {
            var training = mapper.Map<Training>(model);

            unitOfWork.TrainingRepository.Add(training);
            await unitOfWork.SaveAsync();

            await InitializeTrainingRecords(model.TeamId.Value, training.Id);

            return mapper.Map<TrainingViewModel>(training);
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(Guid id, TrainingModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<TrainingViewModel> Get(Guid id)
        {
            var training = await unitOfWork.TrainingRepository.GetByIdAsync(id);

            return mapper.Map<TrainingViewModel>(training);
        }

        public Task<IReadOnlyCollection<TrainingViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        private async Task InitializeTrainingRecords(Guid teamId, Guid trainingId)
        {
            var players = await unitOfWork.PlayerRepository.GetAsync(x => x.TeamId ==  teamId);

            var trainingRecords = players.Select(x => new TrainingRecord
            {
                Id = Guid.NewGuid(),
                TrainingId = trainingId,
                PlayerId = x.Id
            });

            foreach (var record in trainingRecords)
            {
                unitOfWork.TrainingRecordRepository.Add(record);
            }

            await unitOfWork.SaveAsync();
        }
    }
}
