using System.Linq;

namespace RNG.Names
{
    public static class MoleculeExtensions
    {
        public static Molecule GetRandom(this Molecule[] soundsGroup, AtomType leadingType, PositionType weightType)
        {
            return soundsGroup
                .GetWeightedDictionary(leadingType, weightType)
                .GetRandomItem();
        }

        private static WeightedDictionary<Molecule> GetWeightedDictionary(this Molecule[] soundsGroup, AtomType atomType, PositionType positionType)
        {
            return soundsGroup
                .Where(t => t.LeadType == atomType)
                .ToArray()
                .ToWeightedDictionary(item => item.GetWeight(positionType));
        }
    }
}
