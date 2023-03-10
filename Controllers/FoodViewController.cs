using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using RenalTracker.Models;
using RenalTracker.ViewModel;

namespace RenalTracker.Controllers
{
    public class FoodViewController : Controller
    {
        private readonly FoodDbContext _dbContext;
        public FoodViewController(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IActionResult Index(string q, int numResults = 25)
        {
            if(q == null)
            {
                return View();
            }
            List<Food> food = _dbContext.Foods.Where(i => i.Description.Contains(q)).Take(numResults).ToList();
            List<BrandedFood> bf = new();

            food.ForEach(i =>
            {
                bf.Add(_dbContext.BrandedFoods.Where(j => j.FdcId == i.FdcId).SingleOrDefault());
            });



            var tables = new FoodViewModel
            {
                Food = food,
                BrandedFood = bf,
                FoodNutrient = null,
                Nutrient = null
                //BrandedFood = _dbContext.BrandedFoods.Where(i => i.FdcId >= id && i.FdcId < id+numResults).ToList(),
                //Food = _dbContext.Foods.Where(i => i.FdcId >= id && i.FdcId < id+numResults).ToList(),
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
            if(id == null || _dbContext == null)
            {
                return NotFound();
            }
            var table = new FoodViewModel();
            table.BrandedFood = _dbContext.BrandedFoods.Where(i => i.FdcId == id).ToList();
            table.Food = _dbContext.Foods.Where(i => i.FdcId == id).ToList();
            table.FoodNutrient = _dbContext.FoodNutrients.Where(i => i.FdcId == id);
            table.Nutrient = _dbContext.Nutrients;

            return View(table);
        }
    }
}
