using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RenalTracker.Models;

[Table("food_update_log_entry")]
public partial class FoodUpdateLogEntry
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("description")]
    [Unicode(false)]
    public string? Description { get; set; }

    [Column("last_updated", TypeName = "date")]
    public DateTime LastUpdated { get; set; }
}
