using Application.Abstractions;
using Domain.Entities;
using Domain.Enums;

namespace Application;

public class TournamentMatchesGenerator : ITournamentMatchesGenerator
{
    private readonly IUnitOfWork unitOfWork;

    // Dictionary to track the last match date for each team
    private Dictionary<Guid, DateTime> _teamLastMatchDates = new Dictionary<Guid, DateTime>();

    public TournamentMatchesGenerator(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task Generate(Guid tournamentId)
    {
        var teams = (await unitOfWork.TournamentTeamRepository.GetAsync(x => x.TournamentId == tournamentId)).Select(x => x.Team).ToList();

        var matches = new List<Match>();

        foreach (var homeTeam in teams)
        {
            foreach (var awayTeam in teams.Where(t => t.Id != homeTeam.Id))
            {
                matches.Add(CreateMatch(homeTeam, awayTeam, tournamentId, MatchTeamType.Home, MatchTeamType.Away));
            }
        }

        // Save matches ensuring no team plays twice in one day
        foreach (var match in matches)
        {
            AdjustMatchDate(match);
            unitOfWork.MatchRepository.Add(match);
            await unitOfWork.SaveAsync();
        }
    }

    private Match CreateMatch(Team homeTeam, Team awayTeam, Guid tournamentId, MatchTeamType homeTeamType, MatchTeamType awayTeamType)
    {
        var match = new Match
        {
            Id = Guid.NewGuid(),
            TournamentId = tournamentId,
            Location = homeTeam.Club.Stadium,
            MatchTeams = new List<MatchTeam>()
        };

        match.MatchTeams.Add(new MatchTeam
        {
            Id = Guid.NewGuid(),
            MatchId = match.Id,
            TeamId = homeTeam.Id,
            TeamType = homeTeamType
        });

        match.MatchTeams.Add(new MatchTeam
        {
            Id = Guid.NewGuid(),
            MatchId = match.Id,
            TeamId = awayTeam.Id,
            TeamType = awayTeamType
        });

        return match;
    }

    // Adjusts the match start time to ensure no team plays more than once per day
    private void AdjustMatchDate(Match match)
    {
        DateTime earliestDate = DateTime.Now.AddDays(1); // Start from tomorrow

        foreach (var matchTeam in match.MatchTeams)
        {
            if (_teamLastMatchDates.TryGetValue(matchTeam.TeamId, out DateTime lastDate))
            {
                DateTime nextAvailableDate = lastDate.AddDays(1);
                if (nextAvailableDate > earliestDate)
                {
                    earliestDate = nextAvailableDate;
                }
            }
        }

        // Set the match start time to the determined earliest date
        match.StartTime = earliestDate;

        // Update last match dates for both teams
        foreach (var matchTeam in match.MatchTeams)
        {
            _teamLastMatchDates[matchTeam.TeamId] = earliestDate;
        }
    }
}
