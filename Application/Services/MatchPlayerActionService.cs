﻿using Application.Abstractions;
using Application.Services.IService;
using AutoMapper;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;
using Domain.Entities;

namespace Application.Services
{
    public class MatchPlayerActionService : IMatchPlayerActionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MatchPlayerActionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<MatchPlayerActionViewModel> Add(MatchPlayerActionModel model)
        {
            var action = mapper.Map<MatchPlayerAction>(model);

            unitOfWork.MatchPlayerActionRepository.Add(action);
            await unitOfWork.SaveAsync();

            return mapper.Map<MatchPlayerActionViewModel>(action);
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

        public async Task<MatchPlayerActionViewModel> Edit(Guid id, MatchPlayerActionModel model)
        {
            var playerAction = await unitOfWork.MatchPlayerActionRepository.GetByIdAsync(id);

            if (playerAction.ActionNumber != model.ActionNumber)
            {
                playerAction.ActionNumber = model.ActionNumber;
                unitOfWork.MatchPlayerActionRepository.Update(playerAction);
                await unitOfWork.SaveAsync();
            }

            return mapper.Map<MatchPlayerActionViewModel>(playerAction);
        }

        public Task<MatchPlayerActionViewModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<MatchPlayerActionViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
