﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DBAdbir.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required] public string Name { get; set; }
        public string Description { get; set; }

        public List<Item> Items { get; set; }

        public Category()
        { 
        }
    }
}
