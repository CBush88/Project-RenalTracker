using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RenalTracker.Models;

[Table("food")]
public partial class Food
{
    [Key]
    [Column("fdc_id")]
    public int FdcId { get; set; }

    [Column("data_type")]
    [Unicode(false)]
    public string? DataType { get; set; }

    [Column("description")]
    [Unicode(false)]
    public string? Description { get; set; }

    [Column("food_category_id")]
    [Unicode(false)]
    public string? FoodCategoryId { get; set; }

    [Column("publication_date", TypeName = "date")]
    public DateTime? PublicationDate { get; set; }
}
