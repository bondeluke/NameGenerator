using System;

namespace RNG.Names
{
    public enum AtomType
    {
        Vowel = 0,
        Consonant = 1
    }

    public enum MoleculeWeightType
    {
        Lead = 0,
        Mid = 1,
        Trail = 2
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

        public int GetWeightForType(MoleculeWeightType weightType)
        {
            switch (weightType)
            {
                case MoleculeWeightType.Lead:
                    return LeadWeight;
                case MoleculeWeightType.Mid:
                    return MidWeight;
                case MoleculeWeightType.Trail:
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
