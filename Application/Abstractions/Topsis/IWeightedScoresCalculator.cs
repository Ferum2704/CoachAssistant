using Domain.Entities;

namespace Application.Abstractions.Topsis
{
    public interface IWeightedScoresCalculator
    {
        Dictionary<Player, Dictionary<Criterion, float>> CalculateWeightedScores(
            Dictionary<Player, Dictionary<Criterion, float>> normalizedPlayerScores,
            Dictionary<Criterion, float> normalizedCriteriaWeights);
    }
}
