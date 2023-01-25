using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RenalTracker.Models;

[Table("microbe")]
public partial class Microbe
{
    [Key]
    [Column("id")]
    public byte Id { get; set; }

    [Column("foodId")]
    public int FoodId { get; set; }

    [Column("method")]
    [Unicode(false)]
    public string Method { get; set; } = null!;

    [Column("microbe_code")]
    [Unicode(false)]
    public string MicrobeCode { get; set; } = null!;

    [Column("min_value")]
    public int MinValue { get; set; }

    [Column("max_value")]
    [Unicode(false)]
    public string? MaxValue { get; set; }

    [Column("uom")]
    [Unicode(false)]
    public string? Uom { get; set; }
}
