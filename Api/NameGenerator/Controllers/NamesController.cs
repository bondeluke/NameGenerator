using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RNG.Names;

namespace RNG.Controllers
{
    [Route("api/names")]
    public class NamesController : Controller
    {
        private readonly NameGeneratingService _service;

        public NamesController(NameGeneratingService service)
        {
            _service = service;
        }

        [HttpGet]
        public string[] Get()
        {
            var conditions = new NamingConditions
            {
                MinimumGroups = 2,
                MaximumGroups = 7,
                NameCount = 100,
                Molecules = new[]
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
                }
            };

            return Post(conditions);
        }

        [HttpPost]
        public string[] Post([FromBody]NamingConditions conditions)
        {
            return _service
                .GenerateRandomNames(conditions)
                .ToArray();
        }
    }
}