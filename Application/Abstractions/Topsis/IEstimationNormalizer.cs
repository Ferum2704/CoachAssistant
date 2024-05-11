using Domain.Entities;

namespace Application.Abstractions.Topsis
{
    public interface IEstimationNormalizer
    {
        Dictionary<Player, Dictionary<Criterion, float>> NormalizeScores(Dictionary<Player, Dictionary<Criterion, float>> data);
    }
}
