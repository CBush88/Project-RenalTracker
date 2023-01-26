using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using RenalTracker.Models;
using RenalTracker.ViewModel;

namespace RenalTracker.Controllers
{
    public class FoodViewController : Controller
    {
        private readonly FoodDbContext dbContext = new FoodDbContext();

        public IActionResult Index(int id = 344604, int numResults = 25)
        {
            var tables = new FoodViewModel
            {
                BrandedFood = dbContext.BrandedFoods.Where(i => i.FdcId >= id && i.FdcId < id+numResults).ToList(),
                Food = dbContext.Foods.Where(i => i.FdcId >= id && i.FdcId < id+numResults).ToList(),
                FoodNutrient = null,
                Nutrient = null
                //FoodNutrient = dbContext.FoodNutrients.Where(i => i.FdcId == ).ToList(),
                //Nutrient = dbContext.Nutrients.Where().ToList()
            };

            //return View(tables);
            return tables != null ?
                View(tables) :
                Problem("Entity set 'tables' is null.");
        }
        public IActionResult Details(int? id)
        {
            if(id == null || dbContext == null)
            {
                return NotFound();
            }
            var table = new FoodViewModel();
            table.BrandedFood = dbContext.BrandedFoods.Where(i => i.FdcId == id).ToList();
            table.Food = dbContext.Foods.Where(i => i.FdcId == id).ToList();
            table.FoodNutrient = dbContext.FoodNutrients.Where(i => i.FdcId == id);
            table.Nutrient = dbContext.Nutrients;

            return View(table);
        }
    }
}
