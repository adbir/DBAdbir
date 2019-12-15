using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace DBAdbir.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        [Required(ErrorMessage ="Du kan ikke sælge uden at navngive.")]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CreationDate { get; set; }
        public long Price { get; set; }
        public string Description { get; set; }

        public Item()
        { }

    }
}
