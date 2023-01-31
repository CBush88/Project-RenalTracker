using RenalTracker.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace RenalTracker.Models
{
    [Table("meals")]
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
        public double Servings { get; set; }

        [ForeignKey("FdcId")]
        public BrandedFood BrandedFood { get; set; }

        [ForeignKey("FdcId")]
        public Food Food { get; set; }

        [ForeignKey("DateId")]
        public virtual Day Day { get; set; }
    }
}
