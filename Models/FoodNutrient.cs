using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RenalTracker.Models;

[Table("food_nutrient")]
public partial class FoodNutrient
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("fdc_id")]
    public int FdcId { get; set; }

    [Column("nutrient_id")]
    public short NutrientId { get; set; }

    [Column("amount")]
    public double Amount { get; set; }

    [Column("data_points")]
    [StringLength(1)]
    public string? DataPoints { get; set; }

    [Column("derivation_id")]
    public byte? DerivationId { get; set; }

    [Column("min")]
    [StringLength(1)]
    public string? Min { get; set; }

    [Column("max")]
    [StringLength(1)]
    public string? Max { get; set; }

    [Column("median")]
    [StringLength(1)]
    public string? Median { get; set; }

    [Column("footnote")]
    [StringLength(1)]
    public string? Footnote { get; set; }

    [Column("min_year_acquired")]
    [StringLength(1)]
    public string? MinYearAcquired { get; set; }

    [ForeignKey("FdcId")]
    [InverseProperty("FoodNutrients")]
    public virtual Food Fdc { get; set; } = null!;

    [ForeignKey("NutrientId")]
    [InverseProperty("FoodNutrients")]
    public virtual Nutrient Nutrient { get; set; } = null!;
}
