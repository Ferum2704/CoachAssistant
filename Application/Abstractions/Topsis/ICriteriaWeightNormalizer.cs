using Domain.Entities;

namespace Application.Abstractions.Topsis
{
    public interface ICriteriaWeightNormalizer
    {
        Dictionary<Criterion, float> NormalizeWeights(Position position);
    }
}
