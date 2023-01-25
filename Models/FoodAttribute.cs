using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RenalTracker.Models;

[Table("food_attribute")]
public partial class FoodAttribute
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("fdc_id")]
    public int FdcId { get; set; }

    [Column("seq_num")]
    [Unicode(false)]
    public string? SeqNum { get; set; }

    [Column("food_attribute_type_id")]
    [Unicode(false)]
    public string? FoodAttributeTypeId { get; set; }

    [Column("name")]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("value")]
    public byte Value { get; set; }
}
