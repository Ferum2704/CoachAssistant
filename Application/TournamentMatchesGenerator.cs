using Application.Abstractions;
using Domain.Entities;
using Domain.Enums;

namespace Application;

public class TournamentMatchesGenerator : ITournamentMatchesGenerator
{
    private readonly IUnitOfWork unitOfWork;

    private IReadOnlyList<Team> teams;
    private List<Match> matches;
    private int daysCount = 0;

    public TournamentMatchesGenerator(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task Generate(Guid tournamentId)
    {
        teams = (await unitOfWork.TournamentTeamRepository.GetAsync(x => x.TournamentId == tournamentId)).Select(x => x.Team).ToList();
        var teamCount = teams.Count;

        for (int round = 0; round < teamCount - 1; round++)
        {
            List<int> teamsPlayingToday = new List<int>();

            for (int i = 0; i < teamCount / 2; i++)
            {
                int homeTeamIndex = (round + i) % teamCount;
                int awayTeamIndex = (round - i + teamCount) % teamCount;

                if (i == 0) awayTeamIndex = teamCount - 1;

                if (teamsPlayingToday.Contains(homeTeamIndex) || teamsPlayingToday.Contains(awayTeamIndex))
                {
                    daysCount++;
                    teamsPlayingToday.Clear();
                }

                var homeTeam = teams[homeTeamIndex];
                var awayTeam = teams[awayTeamIndex];
                await InitializeMatch(tournamentId, homeTeam, awayTeam);

                teamsPlayingToday.Add(homeTeamIndex);
                teamsPlayingToday.Add(awayTeamIndex);
            }

            daysCount++;
        }

        int halfScheduleCount = matches.Count;

        for (int i = 0; i < halfScheduleCount; i++)
        {
            Match original = matches[i];

            await InitializeMatch(
                tournamentId, 
                original.MatchTeams.First(x => x.TeamType == MatchTeamType.Away).Team, 
                original.MatchTeams.First(x => x.TeamType == MatchTeamType.Home).Team);
        }
    }

    private async Task InitializeMatch(Guid tournamentId, Team homeTeam, Team awayTeam)
    {
        var homeClub = await unitOfWork.ClubRepository.GetByIdAsync(homeTeam.ClubId);

        var match = new Match()
        {
            Id = Guid.NewGuid(),
            StartTime = DateTime.Now.AddDays(daysCount + 1),
            Location = homeClub.Stadium,
            TournamentId = tournamentId
        };
        matches.Add(match);

        unitOfWork.MatchRepository.Add(match);
        await unitOfWork.SaveAsync();

        var homeMatchTeam = new MatchTeam()
        {
            Id = Guid.NewGuid(),
            TeamType = MatchTeamType.Home,
            TeamId = homeTeam.Id,
            Team = homeTeam,
            MatchId = match.Id
        };
        

        var awayMatchTeam = new MatchTeam()
        {
            Id = Guid.NewGuid(),
            TeamType = MatchTeamType.Away,
            TeamId = awayTeam.Id,
            Team = awayTeam,
            MatchId = match.Id
        };

        var matchTeams = new List<MatchTeam>(){ homeMatchTeam, awayMatchTeam };
        match.MatchTeams = matchTeams;

        unitOfWork.MatchTeamRepository.AddRange(new[] { homeMatchTeam, awayMatchTeam });
        await unitOfWork.SaveAsync();
    }
}
