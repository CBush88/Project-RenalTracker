using RenalTracker.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace RenalTracker.Models
{
    static class ToMealViewModel
    {
        public static MealViewModel ToModel(this Meal meal)
        {
            double Carbohydrates = (meal.Food.FoodNutrients.SingleOrDefault(fn => fn.NutrientId == 1005) != null) ? meal.Food.FoodNutrients.Single(fn => fn.NutrientId == 1005).Amount : 0.0;
            double Protein = (meal.Food.FoodNutrients.SingleOrDefault(fn => fn.NutrientId == 1003) != null) ? meal.Food.FoodNutrients.Single(fn => fn.NutrientId == 1003).Amount : 0.0;
            double Fat = (meal.Food.FoodNutrients.SingleOrDefault(fn => fn.NutrientId == 1004) != null) ? meal.Food.FoodNutrients.Single(fn => fn.NutrientId == 1004).Amount : 0.0;
            double CalculatedCalories = (Carbohydrates * 4) + (Protein * 4) + (Fat * 9);
            return new MealViewModel()
            {
                MealId = meal.MealId,
                FdcId = meal.FdcId,
                DateId = meal.DateId,
                Servings = meal.Servings,
                BrandedFood = meal.BrandedFood,
                Food = meal.Food,
                Day = meal.Day,
                Calories = (double)meal.Servings * ((meal.Food.FoodNutrients.SingleOrDefault(fn => fn.NutrientId == 1008) != null) ? meal.Food.FoodNutrients.Single(fn => fn.NutrientId == 1008).Amount : CalculatedCalories),
                Carbohydrates = (double)meal.Servings * Carbohydrates,
                Protein = (double)meal.Servings * Protein,
                Fat = (double) meal.Servings * Fat,
                Phosphorus = (double)meal.Servings * ((meal.Food.FoodNutrients.SingleOrDefault(fn => fn.NutrientId == 1091) != null) ? meal.Food.FoodNutrients.Single(fn => fn.NutrientId == 1091).Amount : 0.0),
                Potassium = (double)meal.Servings * ((meal.Food.FoodNutrients.SingleOrDefault(fn => fn.NutrientId == 1092) != null) ? meal.Food.FoodNutrients.Single(fn => fn.NutrientId == 1092).Amount : 0.0),
                Sodium = (double)meal.Servings * ((meal.Food.FoodNutrients.SingleOrDefault(fn => fn.NutrientId == 1093) != null) ? meal.Food.FoodNutrients.Single(fn => fn.NutrientId == 1093).Amount : 0.0)

            };
        }
    }
    [Table("meal")]
    public class Meal
    {
        [Key]
        [Column("meal_id")]
        public int MealId { get; set; }

        [Column("fdc_id")]
        public int FdcId { get; set; }

        [Column("date_id")]
        public int DateId { get; set; }

        [Column("servings")]
        public decimal Servings { get; set; }

        [ForeignKey("FdcId")]
        public BrandedFood BrandedFood { get; set; }

        [ForeignKey("FdcId")]
        public Food Food { get; set; }

        [ForeignKey("DateId")]
        public virtual Day Day { get; set; }
    }
}
