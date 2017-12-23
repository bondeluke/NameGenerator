namespace RNG.Names
{
    public interface INameGenerator
    {
        string[] GetNames(NamingRules rules);
    }

    public class NameGenerator : INameGenerator
    {
        public string[] GetNames(NamingRules rules)
        {
            return new[] {"Pablo"};
        }
    }
}