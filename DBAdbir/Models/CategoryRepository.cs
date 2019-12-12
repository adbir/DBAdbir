using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBAdbir.Data;

namespace DBAdbir.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DBAdbirContext _context;

        public CategoryRepository(DBAdbirContext context)
        {
            this._context = context;
        }
        public void Delete(int CategoryId)
        {
            _context.Category.Remove(this.Get(CategoryId));
        }

        public List<Category> Get()
        {
            return _context.Category.ToList();
        }

        public Category Get(int CategoryId)
        {
            return _context.Category.Find(CategoryId);
        }

        public void Save(Category it)
        {
            if (it.CategoryId == 0)
            {
                _context.Category.Add(it);
            }
            else
            {
                _context.Category.Update(it);
            }

            _context.SaveChanges();
        }
    }
}
