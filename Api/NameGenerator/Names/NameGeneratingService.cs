using System;
using System.Collections.Generic;
using System.Linq;

namespace RNG.Names
{
    public class NameGeneratingService
    {
        private static readonly Random Random = new Random(DateTime.Now.GetHashCode() + 1);

        public string GenerateRandomName(NamingConditions c)
        {
            var groupLength = Random.Next(c.MinimumGroups, c.MaximumGroups);

            var groups = new List<Molecule>
            {
                c.Molecules.GetRandomMolecule(AtomType.Consonant, MoleculeWeightType.Lead)
            };

            for (var i = 1; i < groupLength; i++)
            {
                var leadTypeForNextGroup = groups.Last().TrailType.GetOpposite();
                var weightType = i == groupLength - 1 ? MoleculeWeightType.Trail : MoleculeWeightType.Mid;
                var nextGroup = c.Molecules.GetRandomMolecule(leadTypeForNextGroup, weightType);
                groups.Add(nextGroup);
            }

            return groups
                .Select(g => g.Value)
                .StringJoin()
                .ToTitleCase();
        }

        public string[] GenerateRandomNames(NamingConditions conditions)
        {
           return conditions
                .NameCount
                .Select(i => GenerateRandomName(conditions))
                .Distinct()
                .ToArray();
        }
    }
}
