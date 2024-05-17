﻿using Application.Abstractions;
using Application.Services.IService;
using AutoMapper;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace Application.Services
{
    public class MatchService : IMatchService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MatchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public Task<MatchViewModel> Add(MatchModel model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(Guid id, MatchModel model)
        {
            throw new NotImplementedException();
        }

        public Task<MatchViewModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<MatchViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
