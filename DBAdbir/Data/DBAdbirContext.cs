using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DBAdbir.Models;

namespace DBAdbir.Data
{
    public class DBAdbirContext : DbContext
    {
        public DBAdbirContext (DbContextOptions<DBAdbirContext> options)
            : base(options)
        {
        }

        public DbSet<DBAdbir.Models.Item> Item { get; set; }

        public DbSet<DBAdbir.Models.Category> Category { get; set; }
    }
}
