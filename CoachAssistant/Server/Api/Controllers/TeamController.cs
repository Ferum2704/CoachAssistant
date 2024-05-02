using Application.Features.Club;
using Application.Identity;
using AutoMapper;
using CoachAssistant.Server.Api.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoachAssistant.Server.Api.Controllers
{
    [Route("api/coaching-system/team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public TeamController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        [Authorize(Roles = $"{nameof(ApplicationUserRole.Coach)}")]
        [HttpPost]
        public async Task<IActionResult> PostTeam(TeamClubModel model)
        {
            var command = mapper.Map<AddTeamClubCommand>(model);

            await mediator.Publish(command);

            return Ok();
        }
    }
}
