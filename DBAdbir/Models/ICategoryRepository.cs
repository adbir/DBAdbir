using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBAdbir.Models
{
    public interface ICategoryRepository
    {
        public void Save(Category it);
        public List<Category> Get();
        public Category Get(int CategoryId);
        public void Delete(int CategoryId);
    }
}
