using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using pertemuan2C_Lanjutan.Models.DB;
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

            var customerList = _costomerService.GetlistCustomer(); // mengambil data dari database
            return Ok(customerList);

         
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customerId = _costomerService.DataId(id);
            if (customerId !=  null)
            {
                return Ok (customerId);
            }
            return NotFound("Not Found");
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            var InsertCustomer = _costomerService.CreateCustomer(customer);
            if (InsertCustomer)
            {
                return Ok("Insert Customer Success");
            }
            return BadRequest("insert cutomer failed");

        }

        // PUT api/<CustomerController>/5
        [HttpPut]
        public IActionResult Put(Customer customer)
        {
            try
            {
                var UpdateCustomer = _costomerService.UpdateCustomer(customer);
                if (UpdateCustomer)
                {
                    return Ok("Update Customer Success");
                }

                return BadRequest("Update Customer failed");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message.ToString());
                throw;
            }
        }


        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Deletecustomer = _costomerService.DeleteCutomer(id);
                if (Deletecustomer)
                {
                    return Ok("Delete Data Sucess");
                }
                return NotFound("Data Tidak Ditemukan");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
                throw;
            }
        }
    }
}
