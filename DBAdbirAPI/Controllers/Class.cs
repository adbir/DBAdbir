using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBAdbirAPI.Controllers
{
    public class Class
    {
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
    }
}
