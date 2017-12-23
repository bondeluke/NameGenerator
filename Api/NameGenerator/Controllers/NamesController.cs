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
                TotalNames = 200,
                NameComponentCount = 2,
                Molecules = Molecule.GetDefaultCollection()
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