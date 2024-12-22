using Microsoft.AspNetCore.Mvc;
using pertemuan2C_Lanjutan.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pertemuan2C_Lanjutan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CostomerService _costomerService;

        public CustomerController(CostomerService costomerService)
        {
            _costomerService = costomerService;
        }


        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get() 
        {

            var customerList = _costomerService.GetlistCustomer();
            return Ok(customerList);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
