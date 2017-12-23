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

        public static Molecule[] GetDefaultCollection()
        {
            return new[]
            {
                new Molecule("a", AtomType.Vowel, AtomType.Vowel, 1, 6, 9),
                new Molecule("e", AtomType.Vowel, AtomType.Vowel, 1, 8, 5),
                new Molecule("i", AtomType.Vowel, AtomType.Vowel, 1, 6, 1),
                new Molecule("o", AtomType.Vowel, AtomType.Vowel, 0, 5, 2),
                new Molecule("u", AtomType.Vowel, AtomType.Vowel, 0, 4, 1),
                new Molecule("y", AtomType.Vowel, AtomType.Vowel, 1, 1, 0),
                new Molecule("b", AtomType.Consonant, AtomType.Consonant, 3, 1, 2),
                new Molecule("c", AtomType.Consonant, AtomType.Consonant, 0, 1, 0),
                new Molecule("d", AtomType.Consonant, AtomType.Consonant, 3, 3, 1),
                new Molecule("f", AtomType.Consonant, AtomType.Consonant, 5, 2, 3),
                new Molecule("g", AtomType.Consonant, AtomType.Consonant, 2, 2, 0),
                new Molecule("h", AtomType.Consonant, AtomType.Consonant, 2, 2, 0),
                new Molecule("j", AtomType.Consonant, AtomType.Consonant, 1, 0, 0),
                new Molecule("k", AtomType.Consonant, AtomType.Consonant, 3, 4, 5),
                new Molecule("m", AtomType.Consonant, AtomType.Consonant, 1, 2, 1),
                new Molecule("n", AtomType.Consonant, AtomType.Consonant, 2, 3, 2),
                new Molecule("p", AtomType.Consonant, AtomType.Consonant, 1, 1, 0),
                new Molecule("q", AtomType.Consonant, AtomType.Consonant, 4, 1, 1),
                new Molecule("r", AtomType.Consonant, AtomType.Consonant, 2, 4, 2),
                new Molecule("s", AtomType.Consonant, AtomType.Consonant, 1, 2, 4),
                new Molecule("t", AtomType.Consonant, AtomType.Consonant, 6, 4, 4),
                new Molecule("v", AtomType.Consonant, AtomType.Consonant, 4, 3, 1),
                new Molecule("w", AtomType.Consonant, AtomType.Consonant, 1, 1, 1),
                new Molecule("x", AtomType.Consonant, AtomType.Consonant, 2, 1, 1),
                new Molecule("y", AtomType.Consonant, AtomType.Consonant, 2, 0, 0),
                new Molecule("z", AtomType.Consonant, AtomType.Consonant, 2, 1, 1),
            };
        }
    }
}
