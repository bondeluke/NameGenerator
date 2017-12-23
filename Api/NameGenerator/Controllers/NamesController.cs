using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RandomNameGenerator;
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
            var generator = new NameGenerator(null, null);

            var rules = new NamingRules();

            return generator.GenerateRandomNames(new Natural(3)).ToArray();
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
