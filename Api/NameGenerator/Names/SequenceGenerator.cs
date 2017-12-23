using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomNameGenerator
{
    public class SequenceGenerator
    {
        private readonly Random _random;
        private readonly WeightedDictionary<LetterGroupType> _dict;

        public SequenceGenerator(Random random)
        {
            _random = random;
            _dict = new[]{
                new Weighted<LetterGroupType>(LetterGroupType.Vowel, 1),
                new Weighted<LetterGroupType>(LetterGroupType.Consonant, 9)
            }.ToWeightedDictionary();
        }

        public IEnumerable<LetterGroupType> GenerateRandomSequence()
        {
            var seqLength = _random.Next(3, 6);

            var seq = new LetterGroupType[seqLength];

            seq[0] = _dict.GetRandomItem(_random);

            for (int i = 1; i < seqLength; i++)
            {
                seq[i] = seq[i - 1].GetOpposite();
            }

            return seq;
        }
    }
}
