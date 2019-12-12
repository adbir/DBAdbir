using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBAdbir.Models
{
    public interface IItemRepository
    {
        public void Save(Item it);
        public List<Item> Get();
        public Item Get(int ItemId);
        public void Delete(int ItemId);
        public List<Item> Find(string search);
    }
}
