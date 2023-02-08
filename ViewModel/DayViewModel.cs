using System.ComponentModel.DataAnnotations;
using RenalTracker.Models;

namespace RenalTracker.ViewModel
{
    public class DayViewModel
    {
        [Key]
        public int DateId { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<MealViewModel>? Meals { get; set; }
        
    }
}
