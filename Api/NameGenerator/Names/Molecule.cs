using System;

namespace RNG.Names
{
    public enum AtomType
    {
        Vowel = 0,
        Consonant = 1
    }

    public enum PositionType
    {
        Beginning = 0,
        Middle = 1,
        End = 2
    }

    public class Molecule
    {
        public Molecule(string value, AtomType startsWith, AtomType endsWith, int leadWeight, int midWeight, int trailWeight)
        {
            Value = value;
            LeadType = startsWith;
            TrailType = endsWith;
            LeadWeight = leadWeight;
            MidWeight = midWeight;
            TrailWeight = trailWeight;
        }

        public string Value { get; }
        public AtomType LeadType { get; }
        public AtomType TrailType { get; }
        public int LeadWeight { get; }
        public int MidWeight { get; }
        public int TrailWeight { get; }

        public int GetWeight(PositionType weightType)
        {
            switch (weightType)
            {
                case PositionType.Beginning:
                    return LeadWeight;
                case PositionType.Middle:
                    return MidWeight;
                case PositionType.End:
                    return TrailWeight;
                default:
                    throw new Exception();
            }
        }

        public override string ToString()
        {
            return $"{Value} {LeadWeight} {MidWeight} {TrailWeight}";
        }
    }
}
