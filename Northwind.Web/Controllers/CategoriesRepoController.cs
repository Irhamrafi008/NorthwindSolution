using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Base;
using Northwind.Domain.Models;
using Northwind.Persistence;

namespace Northwind.Web.Controllers
{
    public class CategoriesRepoController : Controller
    {
        //private readonly NorthwindContext _context;
        private readonly IRepositoryManager _context;

        public CategoriesRepoController(IRepositoryManager context)
        {
            _context = context;
        }

        // GET: CategoryRepo
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoryRepository.GetAllCategories(false));
        }

        // GET: CategoryRepo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var category = await _context.Categories
            //    .FirstOrDefaultAsync(m => m.CategoryId == id);
            var categories = await _context.CategoryRepository.GetCategoryById((int)id, false) ;
            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        // GET: CategoryRepo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryRepo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,Description,Picture")] Category category)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(category);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                _context.CategoryRepository.insert(category);
                await _context.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: CategoryRepo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var category = await _context.Categories.FindAsync(id);
            var category = await _context.CategoryRepository.GetCategoryById((int)id, true);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryRepo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,Description,Picture")] Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(category);
                    //await _context.SaveChangesAsync();
                    _context.CategoryRepository.edit(category);
                    await _context.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!CategoryExists(category.CategoryId))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: CategoryRepo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var category = await _context.Categories
            //    .FirstOrDefaultAsync(m => m.CategoryId == id);
            var category = await _context.CategoryRepository.GetCategoryById((int)id, false);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: CategoryRepo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var category = await _context.Categories.FindAsync(id);
            //_context.Categories.Remove(category);
            //await _context.SaveChangesAsync();
            var category = await _context.CategoryRepository.GetCategoryById((int)id, false);
            _context.CategoryRepository.remove(category);
            await _context.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool CategoryExists(int id)
        //{
        //    return _context.Categories.Any(e => e.CategoryId == id);
        //}
    }
}
