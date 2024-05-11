using Application.Abstractions.Topsis;
using Domain.Entities;

namespace Application.Topsis
{
    public class CriteriaWeightNormalizer : ICriteriaWeightNormalizer
    {
        public Dictionary<Criterion, float> NormalizeWeights(Position position)
        {
            var totalWeight = position.PositionCriteria.Sum(pc => pc.Weight);
            var normalizedWeights = new Dictionary<Criterion, float>();

            foreach (var pc in position.PositionCriteria)
            {
                var normalizedWeight = pc.Weight / totalWeight;
                normalizedWeights.Add(pc.Criterion, normalizedWeight);
            }

            return normalizedWeights;
        }
    }
}
