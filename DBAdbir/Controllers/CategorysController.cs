using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBAdbir.Data;
using DBAdbir.Models;

namespace DBAdbir.Controllers
{
    public class CategorysController : Controller
    {
        private readonly ICategoryRepository repo;

        public CategorysController(ICategoryRepository repo)
        {
            this.repo = repo;
        }

        // GET: Categorys
        public IActionResult Index()
        {
            return View(repo.Get());
            //return View(await _context.Category.ToListAsync());
        }

        // GET: Categorys/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var Category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);*/
            var Category = repo.Get((int)id);
            if (Category == null)
            {
                return NotFound();
            }

            return View(Category);
        }

        // GET: Categorys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CategoryId,Name,Description")] Category Category)
        {
            /*if (ModelState.IsValid)
            {
                _context.Add(Category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }*/
            if (ModelState.IsValid)
            {
                repo.Save(Category);
                return RedirectToAction(nameof(Index));
            }
            return View(Category);
        }

        // GET: Categorys/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var Category = await _context.Category.FindAsync(id);*/
            var Category = repo.Get((int)id);
            if (Category == null)
            {
                return NotFound();
            }
            return View(Category);
        }

        // POST: Categorys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CategoryId,Name,Description")] Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*_context.Update(category);
                    await _context.SaveChangesAsync();*/
                    repo.Save(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categorys/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var Category = await _context.Category.FirstOrDefaultAsync(m => m.CategoryId == id);*/
            var Category = repo.Get((int)id);
            if (Category == null)
            {
                return NotFound();
            }

            return View(Category);
        }

        // POST: Categorys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            /*var Category = await _context.Category.FindAsync(id);
            _context.Category.Remove(Category);
            await _context.SaveChangesAsync();*/
            repo.Delete(id); ;
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            //Returnerer false, for at vi kan unit teste.
            /*if (repo.Get((int)id) != null)
            {
                return true;
            }
            else
            {*/
                return false;
            //}


            //return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}
