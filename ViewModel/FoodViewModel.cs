using RenalTracker.Models;

namespace RenalTracker.ViewModel
{
    public class FoodViewModel
    {
        public IEnumerable<Food> Food { get; set; }
        public IEnumerable<BrandedFood> BrandedFood { get; set; }
        public IEnumerable<FoodNutrient>? FoodNutrient { get; set; }
        public IEnumerable<Nutrient>? Nutrient { get; set; }
    }
}
