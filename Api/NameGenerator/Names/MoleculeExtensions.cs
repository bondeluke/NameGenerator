using System.Linq;

namespace RNG.Names
{
    public static class MoleculeExtensions
    {
        public static Molecule GetRandom(this Molecule[] soundsGroup, AtomType leadAtom, PositionType position)
        {
            return soundsGroup
                .Where(t => t.LeadType == leadAtom)
                .ToWeightedDictionary(item => item.GetWeight(position))
                .GetRandomItem();
        }
    }
}
