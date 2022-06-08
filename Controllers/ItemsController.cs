using Microsoft.AspNetCore.Mvc;
using Scycare.Apis.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Scycare.Models;

namespace Scycare.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : Controller
    {
        private readonly IItemRepository itemRepository;
        public ItemsController(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllItemsAsync()
        {
            try
            {
                return Ok(await itemRepository.GetAllItemsAsync());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }

        }


        [HttpGet("{Id:Guid}")]
        public async Task<ActionResult<ItemModel>> GetItemAsync(Guid Id)
        {
            try
            {
               var result = await itemRepository.GetItemAsync(Id);
                if (result == null)
                {
                    return NotFound();  
                }
                return result;  
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }

        }

        [HttpPost]
        public async Task<ActionResult<ItemModel>> InsertItemAsync(ItemModel itemModel)
        {
            try
            {
                if (itemModel == null)
                {
                    return BadRequest();
                }
                var itemInserted = await itemRepository.InsertItemAsync(itemModel);
             
                return itemInserted;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }

        }

        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> DeleteAsync(Guid Id)
        {
            try
            {
                await itemRepository.DeleteAsync(Id);
                return StatusCode(StatusCodes.Status200OK);
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
