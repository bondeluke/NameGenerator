using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RNG.Names;

namespace RNG.Controllers
{
    [Route("api/names")]
    public class NamesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string[] Get()
        {
            var generator = new NameGeneratingService();

            var conditions = new NamingConditions()
            {
                MinimumGroups = 2,
                MaximumGroups = 6,
                NameCount = 50,
                Molecules = new[]
                {
                    new Molecule("ab", AtomType.Vowel, AtomType.Consonant, 2, 4, 2),
                    new Molecule("car", AtomType.Consonant, AtomType.Consonant, 1, 1, 2),
                    new Molecule("pr", AtomType.Consonant, AtomType.Consonant, 6, 1, 2),
                    new Molecule("ara", AtomType.Vowel, AtomType.Vowel, 6, 1, 2)
                }
            };

            return generator
                .GenerateRandomNames(conditions)
                .ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
