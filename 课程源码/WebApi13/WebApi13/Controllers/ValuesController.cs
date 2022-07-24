using Microsoft.AspNetCore.Mvc;
using WebApi13.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public ValuesController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("{id1}abc{id2}")]
        public string Get1(string id1)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost("{value1}")]
        public void Post([FromBody] string value,[FromRoute]string value1,[FromHeader]string value2)
        {
        }

        [HttpPost]
        public void Post([FromBody] ValuesModel value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [NonAction]
        public void Test()
        {

        }

    }
}
