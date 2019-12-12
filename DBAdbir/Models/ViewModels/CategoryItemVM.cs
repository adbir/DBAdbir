using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBAdbir.Models.ViewModels
{
    public class CategoryItemVM
    {
        public Item Item { get; set; }
        public SelectList CategorySelectList { get; set; }

        public CategoryItemVM()
        { 
        }
    }
}
