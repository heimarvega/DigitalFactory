
using Entities;
using Facade;
using Microsoft.AspNetCore.Mvc;
using Model;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ApplicationDigitalFactory.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly IFacadePeople _facadePeople;

        public PeopleController(IRepository<People> repository)
        {
            _facadePeople = new FacadePeople(repository);
        }
        // GET: api/values
        [HttpGet]
        [Route("People")]
        public JsonResult Get()
        {
            return Json(_facadePeople.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string name)
        {
            return "value";
        }

        // GET api/People/byNameAndRegion?name=a&region=b
        [HttpGet("byNameAndRegion")]
        public JsonResult Get(string name, string region)
        {
            return Json(_facadePeople.GetAmountByNameAndRegion(name, region));
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
