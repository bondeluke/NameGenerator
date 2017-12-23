using System;

namespace RandomNameGenerator
{
    public enum LetterGroupType
    {
        Vowel = 0,
        Consonant = 1
    }
    public enum WeightType
    {
        Lead = 0,
        Mid = 1,
        Trail = 2
    }

    public class LetterGroup
    {
        public LetterGroup(string value, LetterGroupType startsWith, LetterGroupType endsWith, int leadWeight, int midWeight, int trailWeight)
        {
            Value = value;
            LeadType = startsWith;
            TrailType = endsWith;
            LeadWeight = leadWeight;
            MidWeight = midWeight;
            TrailWeight = trailWeight;
        }

        public string Value { get; private set; }
        public LetterGroupType LeadType { get; private set; }
        public LetterGroupType TrailType { get; private set; }
        public int LeadWeight { get; private set; }
        public int MidWeight { get; private set; }
        public int TrailWeight { get; private set; }

        public int GetWeightForType(WeightType type)
        {
            switch (type)
            {
                case WeightType.Lead:
                    return LeadWeight;
                case WeightType.Mid:
                    return MidWeight;
                case WeightType.Trail:
                    return TrailWeight;
                default:
                    throw new Exception();
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Value, LeadWeight, MidWeight, TrailWeight);
        }
    }
}
