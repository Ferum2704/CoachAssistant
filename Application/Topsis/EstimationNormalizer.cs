using Application.Abstractions.Topsis;
using Domain.Entities;

namespace Application.Topsis
{
    public class EstimationNormalizer : IEstimationNormalizer
    {
        public Dictionary<Player, Dictionary<Criterion, float>> NormalizeScores(Dictionary<Player, Dictionary<Criterion, float>> data)
        {
            var criteriaMinMax = new Dictionary<Guid, (float min, float max)>();

            foreach (var playerData in data)
            {
                foreach (var criterionEntry in playerData.Value)
                {
                    var criterion = criterionEntry.Key;
                    var score = criterionEntry.Value;

                    if (!criteriaMinMax.ContainsKey(criterion.Id))
                    {
                        criteriaMinMax[criterion.Id] = (float.MaxValue, float.MinValue);
                    }

                    var (currentMin, currentMax) = criteriaMinMax[criterion.Id];

                    currentMin = Math.Min(currentMin, score);
                    currentMax = Math.Max(currentMax, score);

                    criteriaMinMax[criterion.Id] = (currentMin, currentMax);
                }
            }

            var normalizedData = new Dictionary<Player, Dictionary<Criterion, float>>();
            foreach (var playerData in data)
            {
                var normalizedScores = new Dictionary<Criterion, float>();
                foreach (var criterionEntry in playerData.Value)
                {
                    var criterion = criterionEntry.Key;
                    var score = criterionEntry.Value;
                    var (min, max) = criteriaMinMax[criterion.Id];

                    if (max != min)
                    {
                        if (criterion.ShouldBeMaximized)
                        {
                            normalizedScores[criterion] = (score - min) / (max - min);
                        }
                        else
                        {
                            normalizedScores[criterion] = (max - score) / (max - min);
                        }
                    }
                    else
                    {
                        normalizedScores[criterion] = 1;
                    }
                }
                normalizedData.Add(playerData.Key, normalizedScores);
            }

            return normalizedData;
        }
    }
}
