using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DBAdbirAPI;

namespace DBAdbirAPI.Data
{
    public class DBAdbirAPIContext : DbContext
    {
        public DBAdbirAPIContext (DbContextOptions<DBAdbirAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Item> Item { get; set; }
    }
}
