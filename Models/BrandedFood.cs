using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RenalTracker.Models;

[Table("branded_food")]
public partial class BrandedFood
{
    [Key]
    [Column("fdc_id")]
    public int FdcId { get; set; }

    [Column("brand_owner")]
    [Unicode(false)]
    public string? BrandOwner { get; set; }

    [Column("brand_name")]
    [Unicode(false)]
    public string? BrandName { get; set; }

    [Column("subbrand_name")]
    [Unicode(false)]
    public string? SubbrandName { get; set; }

    [Column("gtin_upc")]
    public long? GtinUpc { get; set; }

    [Column("ingredients")]
    [Unicode(false)]
    public string? Ingredients { get; set; }

    [Column("not_a_significant_source_of")]
    [Unicode(false)]
    public string? NotASignificantSourceOf { get; set; }

    [Column("serving_size")]
    public double? ServingSize { get; set; }

    [Column("serving_size_unit")]
    [Unicode(false)]
    public string? ServingSizeUnit { get; set; }

    [Column("household_serving_fulltext")]
    [Unicode(false)]
    public string? HouseholdServingFulltext { get; set; }

    [Column("branded_food_category")]
    [Unicode(false)]
    public string? BrandedFoodCategory { get; set; }

    [Column("data_source")]
    [Unicode(false)]
    public string? DataSource { get; set; }

    [Column("package_weight")]
    [Unicode(false)]
    public string? PackageWeight { get; set; }

    [Column("modified_date", TypeName = "date")]
    public DateTime? ModifiedDate { get; set; }

    [Column("available_date", TypeName = "date")]
    public DateTime? AvailableDate { get; set; }

    [Column("market_country")]
    [Unicode(false)]
    public string? MarketCountry { get; set; }

    [Column("discontinued_date")]
    [Unicode(false)]
    public string? DiscontinuedDate { get; set; }

    [Column("preparation_state_code")]
    [Unicode(false)]
    public string? PreparationStateCode { get; set; }

    [Column("trade_channel")]
    [Unicode(false)]
    public string? TradeChannel { get; set; }

    [Column("short_description")]
    [Unicode(false)]
    public string? ShortDescription { get; set; }
}
