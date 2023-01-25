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
    public class BrandedFoodController : Controller
    {
        private readonly FoodDbContext _context;

        public BrandedFoodController(FoodDbContext context)
        {
            _context = context;
        }

        // GET: BrandedFood
        public async Task<IActionResult> Index()
        {
              return _context.BrandedFoods != null ? 
                          View(await _context.BrandedFoods.ToListAsync()) :
                          Problem("Entity set 'FoodDbContext.BrandedFoods'  is null.");
        }

        // GET: BrandedFood/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BrandedFoods == null)
            {
                return NotFound();
            }

            var brandedFood = await _context.BrandedFoods
                .FirstOrDefaultAsync(m => m.FdcId == id);
            if (brandedFood == null)
            {
                return NotFound();
            }

            return View(brandedFood);
        }

        // GET: BrandedFood/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BrandedFood/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FdcId,BrandOwner,BrandName,SubbrandName,GtinUpc,Ingredients,NotASignificantSourceOf,ServingSize,ServingSizeUnit,HouseholdServingFulltext,BrandedFoodCategory,DataSource,PackageWeight,ModifiedDate,AvailableDate,MarketCountry,DiscontinuedDate,PreparationStateCode,TradeChannel,ShortDescription")] BrandedFood brandedFood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brandedFood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brandedFood);
        }

        // GET: BrandedFood/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BrandedFoods == null)
            {
                return NotFound();
            }

            var brandedFood = await _context.BrandedFoods.FindAsync(id);
            if (brandedFood == null)
            {
                return NotFound();
            }
            return View(brandedFood);
        }

        // POST: BrandedFood/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FdcId,BrandOwner,BrandName,SubbrandName,GtinUpc,Ingredients,NotASignificantSourceOf,ServingSize,ServingSizeUnit,HouseholdServingFulltext,BrandedFoodCategory,DataSource,PackageWeight,ModifiedDate,AvailableDate,MarketCountry,DiscontinuedDate,PreparationStateCode,TradeChannel,ShortDescription")] BrandedFood brandedFood)
        {
            if (id != brandedFood.FdcId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brandedFood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandedFoodExists(brandedFood.FdcId))
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
            return View(brandedFood);
        }

        // GET: BrandedFood/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BrandedFoods == null)
            {
                return NotFound();
            }

            var brandedFood = await _context.BrandedFoods
                .FirstOrDefaultAsync(m => m.FdcId == id);
            if (brandedFood == null)
            {
                return NotFound();
            }

            return View(brandedFood);
        }

        // POST: BrandedFood/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BrandedFoods == null)
            {
                return Problem("Entity set 'FoodDbContext.BrandedFoods'  is null.");
            }
            var brandedFood = await _context.BrandedFoods.FindAsync(id);
            if (brandedFood != null)
            {
                _context.BrandedFoods.Remove(brandedFood);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandedFoodExists(int id)
        {
          return (_context.BrandedFoods?.Any(e => e.FdcId == id)).GetValueOrDefault();
        }
    }
}
