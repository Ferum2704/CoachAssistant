using Application.Abstractions;
using Application.Services.IService;
using AutoMapper;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace Application.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TournamentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public Task<TournamentViewModel> Add(TournamentModel model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(Guid id, TournamentModel model)
        {
            throw new NotImplementedException();
        }

        public Task<TournamentViewModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
