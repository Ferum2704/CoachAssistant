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

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(Guid id, PositionCriteriaModel model)
        {
            throw new NotImplementedException();
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
