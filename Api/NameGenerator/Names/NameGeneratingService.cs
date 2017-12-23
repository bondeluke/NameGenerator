using System;
using System.Linq;

namespace RNG.Names
{
    public class NameGeneratingService
    {
        private static readonly Random Random = new Random(DateTime.Now.GetHashCode() + 1);

        public string[] GenerateRandomNames(NamingConditions conditions)
        {
            var leaders = conditions
                .Molecules
                .ToWeightedDictionary(m => m.GetWeight(PositionType.Beginning));

            return conditions
                .TotalNames
                .Enumerate<string>((i, c, p) => GetName(conditions, leaders))
                .Distinct()
                .OrderBy(n => n)
                .ToArray();
        }

        private string GetName(NamingConditions conditions, WeightedDictionary<Molecule> leaders)
        {
            return conditions.NameComponentCount
                .Enumerate<string>((i, c, p) => GetComponent(conditions, leaders))
                .StringJoin(" ");
        }

        private string GetComponent(NamingConditions c, WeightedDictionary<Molecule> leaders)
        {
            return Random.Next(c.MinimumGroups, c.MaximumGroups)
                .Enumerate<Molecule>((i, count, p) =>
                {
                    if (i == 0)
                        return leaders.GetRandomItem();

                    var leadType = p.LeadType.GetOpposite();

                    var weightType = i == count - 1
                        ? PositionType.End
                        : PositionType.Middle;

                    return c.Molecules.GetRandom(leadType, weightType);
                })
                .Select(m => m.Value)
                .StringJoin()
                .ToTitleCase();
        }
    }
}