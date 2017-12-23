using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RandomNameGenerator
{
    public class TextFileLetterGroupRepository : ILetterGroupRepository
    {
        public TextFileLetterGroupRepository()
        {
            var list = new List<LetterGroup>();

            var types = Enum.GetNames(typeof(LetterGroupType));

            LetterGroupType leadType = LetterGroupType.Vowel;
            LetterGroupType trailType = LetterGroupType.Vowel;
            using (var reader = new StreamReader(@"C:\ProjectFiles\RNG\TextFileLetterGroups.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Trim();

                    if (line.IsNullOrWhiteSpace())
                        continue;

                    if (line.ContainsAnElementOf(types))
                    {
                        var parts = line.Split(' ');
                        leadType = parts[0].To<LetterGroupType>();
                        trailType = parts[1].To<LetterGroupType>();
                        continue;
                    }

                    var args = line.Split(' ');
                    var value = args[0];
                    var leadWeight = args[1].To<int>();
                    var midWeight = args[2].To<int>();
                    var trailWeight = args[3].To<int>();

                    list.Add(new LetterGroup(value, leadType, trailType, leadWeight, midWeight, trailWeight));
                }
            }

            LetterGroupPool = list;
        }

        private void Process(string type, LetterGroupType lead, LetterGroupType trail)
        {

        }
         
        public IEnumerable<LetterGroup> LetterGroupPool { get; private set; }
    }
}
