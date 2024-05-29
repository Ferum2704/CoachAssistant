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
        private readonly ITrainingRecordService trainingRecordService;
        private readonly IMapper mapper;

        public TrainingService(IMapper mapper, IUnitOfWork unitOfWork, ITrainingRecordService trainingRecordService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.trainingRecordService = trainingRecordService;
        }

        public async Task<TrainingViewModel> Add(TrainingModel model)
        {
            var training = mapper.Map<Training>(model);

            unitOfWork.TrainingRepository.Add(training);
            await unitOfWork.SaveAsync();

            await InitializeTrainingRecords(model.TeamId.Value, training.Id);

            return mapper.Map<TrainingViewModel>(training);
        }

        public async Task Delete(Guid id)
        {
            var training = await unitOfWork.TrainingRepository.GetByIdAsync(id);
            var trainingRecords = await unitOfWork.TrainingRecordRepository.GetAsync(x => x.TrainingId == id);

            await trainingRecordService.DeleteBulk(trainingRecords.Select(x => x.Id).ToList());

            unitOfWork.TrainingRepository.Remove(training);
            await unitOfWork.SaveAsync();
        }

        public Task DeleteBulk<TEntity>(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBulk(IReadOnlyCollection<Guid> IDs)
        {
            throw new NotImplementedException();
        }

        public async Task<TrainingViewModel> Edit(Guid id, TrainingModel model)
        {
            var training = await unitOfWork.TrainingRepository.GetByIdAsync(id);

            if (training is not null)
            {
                if (training.Name != model.Name)
                {
                    training.Name = model.Name;
                }
                else if (training.Description != model.Description)
                {
                    training.Description = model.Description;
                }
                else if (training.StartDate != model.StartDate)
                {
                    training.StartDate = model.StartDate;
                }
                else if (training.Duration != model.Duration)
                {
                    training.Duration = model.Duration;
                }

                unitOfWork.TrainingRepository.Update(training);
                await unitOfWork.SaveAsync();
            }

            return mapper.Map<TrainingViewModel>(training);
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
