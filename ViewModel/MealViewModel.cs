using Microsoft.EntityFrameworkCore;
using RenalTracker.Models;
using RenalTracker.ViewModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RenalTracker.ViewModel
{
    public class MealViewModel
    {
        [Key]
        public int MealId { get; set; }

        public int FdcId { get; set; }

        public int DateId { get; set; }

        public decimal Servings { get; set; }

        public BrandedFood BrandedFood { get; set; }

        public Food Food { get; set; }

        public virtual Day Day { get; set; }

        public double? Calories { get; set; }
        public double? Carbohydrates { get; set; }
        public double? Protein { get; set; }
        public double? Fat { get; set; }
        public double? Phosphorus { get; set; }
        public double? Potassium { get; set; }
        public double? Sodium { get; set; }
    }
}