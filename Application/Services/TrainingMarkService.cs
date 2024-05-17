using Application.Abstractions;
using Application.Services.IService;
using AutoMapper;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;
using Domain.Entities;

namespace Application.Services
{
    public class TrainingMarkService : ITrainingMarkService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TrainingMarkService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<TrainingMarkViewModel> Add(TrainingMarkModel model)
        {
            var trainingMark = mapper.Map<TrainingMark>(model);

            unitOfWork.TrainingMarkRepository.Add(trainingMark);
            await unitOfWork.SaveAsync();

            return mapper.Map<TrainingMarkViewModel>(trainingMark);
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBulk<TEntity>(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBulk(IReadOnlyCollection<Guid> IDs)
        {
            throw new NotImplementedException();
        }

        public Task Edit(Guid id, TrainingMarkModel model)
        {
            throw new NotImplementedException();
        }

        public Task<TrainingMarkViewModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<TrainingMarkViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
