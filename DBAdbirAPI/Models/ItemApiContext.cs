using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBAdbirAPI.Models
{
    public class ItemApiContext : DbContext
    {
        public ItemApiContext(DbContextOptions<ItemApiContext> options) : base(options)
        { }

        public DbSet<DBAdbir.Models.Item> Items { get; set; }
    }
}
