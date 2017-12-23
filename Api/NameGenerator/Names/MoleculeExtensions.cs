using System.Linq;

namespace RNG.Names
{
    public static class MoleculeExtensions
    {
        public static Molecule GetRandomMolecule(this Molecule[] soundsGroup, AtomType leadingType, MoleculeWeightType weightType)
        {
            return soundsGroup
                .GetWeightedDictionary(leadingType, weightType)
                .GetRandomItem();
        }

        private static WeightedDictionary<Molecule> GetWeightedDictionary(this Molecule[] soundsGroup, AtomType atomType, MoleculeWeightType moleculeWeightType)
        {
            return soundsGroup
                .Where(t => t.LeadType == atomType)
                .ToArray()
                .ToWeightedDictionary(item => item.GetWeightForType(moleculeWeightType));
        }
    }
}
