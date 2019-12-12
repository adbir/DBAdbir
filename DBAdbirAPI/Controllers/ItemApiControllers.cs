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

namespace DBAdbirAPI.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class ItemApiControllers : ControllerBase
    {
        private readonly ItemApiContext _context;
        private readonly IMapper _mapper;

        public ItemApiControllers(ItemApiContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        /*
        private static IEnumerable<King> KingArray;
       
        private static readonly string[] Names = new[]
        {
            "Edward", "William", "Björn", "Magrethe II", "Knud", "Edmont", "Christian", "Frederik"
        };
        private static readonly string[] Countries = new[]
        {
            "Denmark", "United Kingdom", "Sweden", "Hungary", "Germany"
        };
        private static readonly string[] Houses = new[]
        {
            "House of Wessex", "House of Denmark", "House of Normandy","House of Angevin","House of Plantagenet", "House of Lancaster"
        };
        private static readonly string[] Years = new[]
        {
            "1422-1461","1461-1483","1483","1483-1485","1485-1509"
        };
        private readonly ILogger<KingApiControllers> _logger;

        public KingApiControllers(ILogger<KingApiControllers> logger)
        {
            _logger = logger;
        }
        

        // GET: King
        [HttpGet]
        public IEnumerable<King> Get() 
        {
            
            var rng = new Random();
            KingArray = Enumerable.Range(1, 5).Select(index => new King
            {
                Id = index,
                Name = Names[rng.Next(Names.Length)],
                Country = Countries[rng.Next(Countries.Length)],
                House = Houses[rng.Next(Houses.Length)],
                Years = Years[index - 1]
            })
            .ToArray();
            return KingArray;
        }
        */

        //GET: King
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemVM>>> GetItem()
        {
            var items = await _context.Items.ToListAsync();
            return _mapper.Map<List<DBAdbir.Models.Item>, List<ItemVM>>(items);
        }

        // GET: Item/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {

        }

        // POST: Item
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: Item/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
