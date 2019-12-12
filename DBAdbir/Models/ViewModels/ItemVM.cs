using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace DBAdbir.Models.ViewModels
{
    public class ItemVM
    {
        public int ItemId {get; set;}
        public string Name { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        
        public ItemVM()
        {
        }
    }

    
}
