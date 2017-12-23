using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNameGenerator
{
    class Program
    {
        static void Main2(string[] args)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());

            var lgRepo = new TextFileLetterGroupRepository();

            var legGen = new LetterGroupGenerator(lgRepo, random);

            var gen = new NameGenerator(random, legGen);

            var totalPossibilities = 0;
            for (int groupLength = 3; groupLength < 6; groupLength++)
            {
                totalPossibilities += CountNames(groupLength, lgRepo.LetterGroupPool, LetterGroupType.Vowel) +
                    CountNames(groupLength, lgRepo.LetterGroupPool, LetterGroupType.Consonant);
            }

            var desiredCount = 100000.ToNatural();

            var wordsEnumerable = new FileInfo(@"C:\Users\Luke\Downloads\scowl-2015.08.24\final\english-words.10").GetLines().Select(l => l.Trim()).Concat(
                new FileInfo(@"C:\Users\Luke\Downloads\scowl-2015.08.24\final\english-words.20").GetLines().Select(l => l.Trim())).Concat(
                new FileInfo(@"C:\Users\Luke\Downloads\scowl-2015.08.24\final\english-words.35").GetLines().Select(l => l.Trim()));
            var words = new HashSet<string>(wordsEnumerable.Select(w => w.ToTitleCase()));

            var names = gen.GenerateRandomNames(desiredCount);

            List<string> modifiedNames;
            var count = CountNamesThatAreWords(words, names, out modifiedNames);

            var preamble = new string[] 
            { string.Format("FYI, this list is only {0:.#####}% of the {1:n0} total possible name combinations based on your configuration.",
                (double)desiredCount.Value * 100 / (double)totalPossibilities, totalPossibilities),
                string.Format("Also, {0:.#####}% ({1}) of these {2:n0} names are actually words in the dictionary (size = {3:n0}).", (double)count * 100 / (double)desiredCount.Value, count, desiredCount.Value, words.Count)
            };

            preamble.Concat(names).SaveToFile(@"C:\ProjectFiles\RNG\Names.txt");
        }

        static int CountNames(int groupLength, IEnumerable<LetterGroup> groups, LetterGroupType leadType)
        {
            if (groupLength == 0)
                return 1;

            var count = 0;
            foreach (var trailType in EnumHelper.Enumerate<LetterGroupType>())
            {
                count += groups.Count(lg => lg.LeadType == leadType && lg.TrailType == trailType) * CountNames(groupLength - 1, groups, trailType.GetOpposite());
            }

            return count;
        }

        static int CountNamesThatAreWords(ICollection<string> words, IEnumerable<string> names, out List<string> modifiedNames)
        {
            var count = 0;
            modifiedNames = new List<string>();
            foreach (var name in names)
            {
                var modifier = string.Empty;

                if (words.Contains(name))
                {
                    count++;
                    modifier = "(dictionary word!)";
                }
                modifiedNames.Add(string.Format("{0} {1}", name, modifier));
            }

            return count;
        }
    }
}
