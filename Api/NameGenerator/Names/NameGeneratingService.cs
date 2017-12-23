using System;
using System.Linq;

namespace RNG.Names
{
    public class NameGeneratingService
    {
        private static readonly Random Random = new Random(DateTime.Now.GetHashCode() + 1);

        public string[] GenerateRandomNames(NamingConditions conditions)
        {
            return conditions
                .TotalNames
                .Enumerate<string>((i, c, p) => GetName(conditions))
                .Distinct()
                .OrderBy(n => n)
                .ToArray();
        }

        private string GetName(NamingConditions conditions)
        {
            return conditions.NameComponentCount
                .Enumerate<string>((i, c, p) => GetComponent(conditions))
                .StringJoin(" ");
        }

        private string GetComponent(NamingConditions c)
        {
            return Random.Next(c.MinimumGroups, c.MaximumGroups)
                .Enumerate<Molecule>((i, count, p) =>
                {
                    if (i == 0)
                        return c.Molecules
                            .ToWeightedDictionary(m => m.GetWeight(PositionType.Beginning))
                            .GetRandomItem();

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