using Application.Abstractions.Lineup;
using Application.Abstractions;
using Application.Services.IService;
using AutoMapper;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;
using Domain.Entities;

namespace Application.Services
{
    public class ActionTypeService : IActionTypeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ActionTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ActionTypeViewModel> Add(ActionTypeModel model)
        {
            var actionType = mapper.Map<ActionType>(model);

            unitOfWork.ActionTypeRepository.Add(actionType);
            await unitOfWork.SaveAsync();

            return mapper.Map<ActionTypeViewModel>(actionType);
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(Guid id, ActionTypeModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ActionTypeViewModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<ActionTypeViewModel>> GetAll()
        {
            var actionTypes = await unitOfWork.ActionTypeRepository.GetAsync();

            return mapper.Map<IReadOnlyCollection<ActionTypeViewModel>>(actionTypes);
        }
    }
}
