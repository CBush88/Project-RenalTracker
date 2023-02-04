using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RenalTracker.Models;

namespace RenalTracker.Controllers
{
    public class MealController : Controller
    {
        private readonly FoodDbContext _context;

        public MealController(FoodDbContext context)
        {
            _context = context;
        }

        // GET: Meal
        public async Task<IActionResult> Index()
        {
            var foodDbContext = _context.Meals.Include(m => m.BrandedFood).Include(m => m.Day).Include(m => m.Food).Include(m => m.Food.FoodNutrients);
            List<Meal> meals = await foodDbContext.ToListAsync();
            return View(meals.Select(m => m.ToModel()));
        }

        // GET: Meal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Meals == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals
                .Include(m => m.BrandedFood)
                .Include(m => m.Day)
                .Include(m => m.Food)
                .ThenInclude(f => f.FoodNutrients)
                .FirstOrDefaultAsync(m => m.MealId == id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal.ToModel());
        }

        // GET: Meal/Create
        public IActionResult Create()
        {
            //ViewData["FdcId"] = new SelectList(_context.BrandedFoods, "FdcId", "FdcId");
            //ViewData["DateId"] = new SelectList(_context.Days, "DateId", "DateId");
            //ViewData["FdcId"] = new SelectList(_context.Foods, "FdcId", "Description");

            return Redirect("/FoodView?q=pop&numResults=100");
        }

        // POST: Meal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MealId,FdcId,DateId,Servings")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FdcId"] = new SelectList(_context.BrandedFoods, "FdcId", "FdcId", meal.FdcId);
            ViewData["DateId"] = new SelectList(_context.Days, "DateId", "DateId", meal.DateId);
            ViewData["FdcId"] = new SelectList(_context.Foods, "FdcId", "FdcId", meal.FdcId);
            return View(meal);
        }

        // GET: Meal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Meals == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals.FindAsync(id);
            if (meal == null)
            {
                return NotFound();
            }
            ViewData["FdcId"] = new SelectList(_context.BrandedFoods, "FdcId", "FdcId", meal.FdcId);
            ViewData["DateId"] = new SelectList(_context.Days, "DateId", "DateId", meal.DateId);
            ViewData["FdcId"] = new SelectList(_context.Foods, "FdcId", "FdcId", meal.FdcId);
            return View(meal);
        }

        // POST: Meal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MealId,FdcId,DateId,Servings")] Meal meal)
        {
            if (id != meal.MealId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealExists(meal.MealId))
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
            ViewData["FdcId"] = new SelectList(_context.BrandedFoods, "FdcId", "FdcId", meal.FdcId);
            ViewData["DateId"] = new SelectList(_context.Days, "DateId", "DateId", meal.DateId);
            ViewData["FdcId"] = new SelectList(_context.Foods, "FdcId", "FdcId", meal.FdcId);
            return View(meal);
        }

        // GET: Meal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Meals == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals
                .Include(m => m.BrandedFood)
                .Include(m => m.Day)
                .Include(m => m.Food)
                .FirstOrDefaultAsync(m => m.MealId == id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }

        // POST: Meal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Meals == null)
            {
                return Problem("Entity set 'FoodDbContext.Meals'  is null.");
            }
            var meal = await _context.Meals.FindAsync(id);
            if (meal != null)
            {
                _context.Meals.Remove(meal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealExists(int id)
        {
          return (_context.Meals?.Any(e => e.MealId == id)).GetValueOrDefault();
        }
    }
}
