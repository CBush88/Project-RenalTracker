using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RenalTracker.Models;

[Table("nutrient")]
public partial class Nutrient
{
    [Key]
    [Column("id")]
    public short Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("unit_name")]
    [StringLength(50)]
    public string UnitName { get; set; } = null!;

    [Column("nutrient_nbr")]
    public double? NutrientNbr { get; set; }

    [Column("rank")]
    public double? Rank { get; set; }

    [InverseProperty("Nutrient")]
    public virtual ICollection<FoodNutrient> FoodNutrients { get; } = new List<FoodNutrient>();
}
