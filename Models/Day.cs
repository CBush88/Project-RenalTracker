using Microsoft.EntityFrameworkCore;
using RenalTracker.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RenalTracker.Models
{
    [Table("day")]
    public class Day
    {
        [Key]
        [Column("date_id")]
        public int DateId { get; set; }

        [DataType(DataType.Date)]
        [Column("date")]
        public DateTime Date { get; set; }

        [InverseProperty("Day")]
        public virtual IEnumerable<Meal> Meals { get; set; }

    }
}
