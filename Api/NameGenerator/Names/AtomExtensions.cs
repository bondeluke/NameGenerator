namespace RNG.Names
{
    public static class AtomExtensions
    {
        public static AtomType GetOpposite(this AtomType value)
        {
            return (AtomType)(((int)value + 1) % 2);
        }
    }
}
