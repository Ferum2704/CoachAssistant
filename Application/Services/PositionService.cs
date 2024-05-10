using Application.Abstractions;
using Application.Services.IService;
using AutoMapper;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;
using Domain.Entities;

namespace Application.Services
{
    public class PositionService : IPositionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PositionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<PositionViewModel> Add(PositionModel model)
        {
            var position = mapper.Map<Position>(model);

            unitOfWork.PositionRepository.Add(position);
            await unitOfWork.SaveAsync();

            return mapper.Map<PositionViewModel>(position);
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(Guid id, PositionModel model)
        {
            throw new NotImplementedException();
        }

        public Task<PositionViewModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
