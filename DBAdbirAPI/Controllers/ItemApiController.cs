using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using DBAdbirAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using DBAdbir.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using DBAdbir;

namespace DBAdbirAPI.Controllers
{
    
    
    [ApiController]
    [Route("[controller]")]
    public class ItemApiController : ControllerBase
    {
        private readonly ItemApiContext _context;
        private readonly IMapper _mapper;

        public ItemApiController(ItemApiContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        

        //GET: ItemApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemVM>>> GetItem()
        {
            var items = await _context.Items.ToListAsync();
            return _mapper.Map<List<DBAdbir.Models.Item>, List<ItemVM>>(items);
        }

        // GET: ItemApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DBAdbir.Models.Item>> GetItem(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // POST: ItemApi
        [HttpPost]
        public async Task<ActionResult<DBAdbir.Models.Item>> PostItem(DBAdbir.Models.Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.ItemId }, item);
        }

        // PUT: ItemApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, DBAdbir.Models.Item item)
        {
            if (id != item.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else 
                { 
                    throw; 
                }
            }
            return NoContent();
        }

        // DELETE: ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DBAdbir.Models.Item>> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return item;
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemId == id);
        }
    }
}
