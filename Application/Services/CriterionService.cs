using Application.Abstractions;
using Application.Services.IService;
using AutoMapper;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;
using Domain.Entities;

namespace Application.Services
{
    public class CriterionService : ICriterionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CriterionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CriterionViewModel> Add(CriterionModel model)
        {
            var criterion = mapper.Map<Criterion>(model);

            unitOfWork.CriterionRepository.Add(criterion);
            await unitOfWork.SaveAsync();

            return mapper.Map<CriterionViewModel>(criterion);
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

        public Task Edit(Guid id, CriterionModel model)
        {
            throw new NotImplementedException();
        }

        public Task<CriterionViewModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<CriterionViewModel>> GetAll()
        {
            var criteria = await unitOfWork.CriterionRepository.GetAsync();

            return mapper.Map<IReadOnlyCollection<CriterionViewModel>>(criteria);
        }
    }
}
