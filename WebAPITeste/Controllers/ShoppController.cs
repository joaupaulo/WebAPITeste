using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPITeste.Models;
using WebAPITeste.Services;

namespace WebAPITeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppController : ControllerBase
    {
        private readonly StoreService _storeService;

        public ShoppController(StoreService booksService) =>
            _storeService = booksService;

        [HttpGet]
        public async Task<List<Shopp>> Get() =>
            await _storeService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Shopp>> Get(string id)
        {
            var item = await _storeService.GetAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Shopp newItem)
        {
            await _storeService.CreateAsync(newItem);

            return CreatedAtAction(nameof(Get), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Shopp updateItem)
        {
            var item = await _storeService.GetAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            updateItem.Id = item.Id;

            await _storeService.UpdateAsync(id, updateItem);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var item = await _storeService.GetAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            await _storeService.RemoveAsync(id);

            return NoContent();
        }
    }
}
