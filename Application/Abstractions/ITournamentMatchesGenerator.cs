namespace Application.Abstractions
{
    public interface ITournamentMatchesGenerator
    {
        Task Generate(Guid tournamentId);
    }
}
