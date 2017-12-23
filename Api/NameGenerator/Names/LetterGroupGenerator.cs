using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomNameGenerator
{
    public class LetterGroupGenerator
    {
        private readonly TextFileLetterGroupRepository _repository;
        private readonly Random _random;

        private readonly IDictionary<string, WeightedDictionary<LetterGroup>> _cache;

        public LetterGroupGenerator(TextFileLetterGroupRepository repository, Random random)
        {
            _repository = repository;
            _random = random;
            _cache = new Dictionary<string, WeightedDictionary<LetterGroup>>();
        }

        public LetterGroup GeneratorRandomLetterGroup(LetterGroupType letterGroupType, WeightType weightType)
        {
            return GetWeightedDictionary(letterGroupType, weightType).GetRandomItem(_random);
        }

        private WeightedDictionary<LetterGroup> GetWeightedDictionary(LetterGroupType letterGroupType, WeightType weightType)
        {
            var key = string.Format("{0}|{1}", letterGroupType, weightType);

            if (_cache.ContainsKey(key))
                return _cache[key];

            var dictionary = _repository.LetterGroupPool
                .Where(t => t.LeadType == letterGroupType)
                .ToWeightedDictionary(item => item.GetWeightForType(weightType));

            return _cache[key] = dictionary;
        }
    }
}
