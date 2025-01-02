using Microsoft.AspNetCore.Mvc;
using pertemuan2C_Lanjutan.Models.DB;
using pertemuan2C_Lanjutan.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pertemuan2C_Lanjutan.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
    public class ItemController : ControllerBase
    {


        private readonly ItemService _itemService;

        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }


        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {

            var itemList = _itemService.GetlistItem(); // mengambil data dari database
            return Ok(itemList);


        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var itemId = _itemService.DataId(id);
            if (itemId != null)
            {
                return Ok(itemId);
            }
            return NotFound("Not Found");
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post(Item item)
        {
            if (string.IsNullOrWhiteSpace(item.NamaItem) ||
               item.Qty <= 0 ||
               item.TglExpire == DateTime.MinValue ||
               string.IsNullOrWhiteSpace(item.Supplier))
            {
                return BadRequest("Field mandatory tidak boleh kosong.");
            }

            var InsertItem = _itemService.CreateItem(item);
            if (InsertItem)
            {
                return Ok("Insert Item Success");
            }
            return BadRequest("insert Item failed");

        }

        // PUT api/<CustomerController>/5
        [HttpPut]
        public IActionResult Put(Item item)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(item.NamaItem) ||
                  item.Qty <= 1 ||
                  item.TglExpire == DateTime.MinValue ||
                  string.IsNullOrWhiteSpace(item.Supplier))
                {
                    return BadRequest("Field mandatory tidak boleh kosong.");
                }

                var UpdateItem = _itemService.UpdateItem(item);
                if (UpdateItem)
                {
                    return Ok("Update Item Success");
                }

                return BadRequest("Update Item failed");

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
                var DeleteItem = _itemService.DeleteItem(id);
                if (DeleteItem)
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
