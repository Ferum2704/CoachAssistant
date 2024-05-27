using Application.Abstractions;
using Application.Services.IService;
using AutoMapper;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;
using Domain.Entities;

namespace Application.Services
{
    public class PositionCriteriaService : IPositionCriteriaService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PositionCriteriaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<PositionCriteriaViewModel> Add(PositionCriteriaModel model)
        {
            var positionCriteria = mapper.Map<PositionCriteria>(model);

            unitOfWork.PositionCriteriaRepository.Add(positionCriteria);
            await unitOfWork.SaveAsync();

            return mapper.Map<PositionCriteriaViewModel>(positionCriteria);
        }

        public async Task Delete(Guid id)
        {
            var positionCriterion = await unitOfWork.PositionCriteriaRepository.GetByIdAsync(id);

            if (positionCriterion is not null)
            {
                unitOfWork.PositionCriteriaRepository.Remove(positionCriterion);
                await unitOfWork.SaveAsync();
            }
        }

        public Task DeleteBulk<TEntity>(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBulk(IReadOnlyCollection<Guid> IDs)
        {
            throw new NotImplementedException();
        }

        public async Task<PositionCriteriaViewModel> Edit(Guid id, PositionCriteriaModel model)
        {
            var positionCriterion = await unitOfWork.PositionCriteriaRepository.GetByIdAsync(id);

            if (positionCriterion is not null)
            {
                if (positionCriterion.Weight != model.Weight)
                {
                    positionCriterion.Weight = model.Weight;
                }

                unitOfWork.PositionCriteriaRepository.Update(positionCriterion);

                await unitOfWork.SaveAsync();
            }

            return mapper.Map<PositionCriteriaViewModel>(positionCriterion);
        }

        public Task<PositionCriteriaViewModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<PositionCriteriaViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
