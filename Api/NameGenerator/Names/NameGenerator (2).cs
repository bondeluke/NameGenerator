using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNameGenerator
{
    public class NameGenerator
    {
        private Random _random;
        private LetterGroupGenerator _letterGroupGenerator;
        private WeightedDictionary<LetterGroupType> _dict;

        public NameGenerator(Random random, LetterGroupGenerator letterGroupGenerator)
        {
            _random = random;
            _letterGroupGenerator = letterGroupGenerator;
            _dict = new[]{
                new Weighted<LetterGroupType>(LetterGroupType.Vowel, 1),
                new Weighted<LetterGroupType>(LetterGroupType.Consonant, 9)
            }.ToWeightedDictionary();
        }

        public string GenerateRandomName()
        {
            var groupLength = _random.Next(2, 6);

            var leadType = _dict.GetRandomItem(_random);

            var groups = new List<LetterGroup>
            {
                _letterGroupGenerator.GeneratorRandomLetterGroup(LetterGroupType.Consonant, WeightType.Lead)
            };

            for (int i = 1; i < groupLength; i++)
            {
                var leadTypeForNextGroup = groups.Last().TrailType.GetOpposite();
                var weightType = i == groupLength - 1 ? WeightType.Trail : WeightType.Mid;
                var nextGroup = _letterGroupGenerator.GeneratorRandomLetterGroup(leadTypeForNextGroup, weightType);
                groups.Add(nextGroup);
            }

            return groups
                .Select(g => g.Value)
                .StringJoin()
                .ToTitleCase();
        }

        public IEnumerable<string> GenerateRandomNames(Natural count)
        {
            var names = new HashSet<string>();

            while (names.Count < count.Value)
            {
                names.AddIfNotPresent(GenerateRandomName());
            }

            return names.OrderBy(name => name[0]).ThenBy(name => name.Length).ThenBy(name => name);
        }
    }
}
