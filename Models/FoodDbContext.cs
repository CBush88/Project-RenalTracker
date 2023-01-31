using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RenalTracker.Models;

namespace RenalTracker.Models;

public partial class FoodDbContext : DbContext
{
    public FoodDbContext()
    {
    }

    public FoodDbContext(DbContextOptions<FoodDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BrandedFood> BrandedFoods { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<FoodAttribute> FoodAttributes { get; set; }

    public virtual DbSet<FoodNutrient> FoodNutrients { get; set; }

    public virtual DbSet<FoodUpdateLogEntry> FoodUpdateLogEntries { get; set; }

    public virtual DbSet<Microbe> Microbes { get; set; }

    public virtual DbSet<Nutrient> Nutrients { get; set; }
    public virtual DbSet<Meal> Meals { get; set; }
    public virtual DbSet<Day> DailyIntakes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=laptop-4r12q4c8;Initial Catalog=FoodDB;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BrandedFood>(entity =>
        {
            entity.Property(e => e.FdcId).ValueGeneratedNever();

            entity.HasOne(d => d.Fdc).WithOne(p => p.BrandedFood)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_branded_food_food");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.Property(e => e.FdcId).ValueGeneratedNever();
        });

        modelBuilder.Entity<FoodAttribute>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Fdc).WithMany(p => p.FoodAttributes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_food_attribute_food");
        });

        modelBuilder.Entity<FoodNutrient>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Fdc).WithMany(p => p.FoodNutrients)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_food_nutrient_food");

            entity.HasOne(d => d.Nutrient).WithMany(p => p.FoodNutrients)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_food_nutrient_nutrient");
        });

        modelBuilder.Entity<FoodUpdateLogEntry>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Nutrient>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Meal>(entity =>
        {
            entity.Property(e => e.MealId).ValueGeneratedOnAdd();
            entity.HasOne(d => d.Day).WithMany(m => m.Meals)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_meal_daily_intake");
        });

        modelBuilder.Entity<Day>(entity =>
        {
            entity.Property(e => e.DateId).HasDefaultValue((int) (DateTime.Now - DateTime.Parse("1-1-2023")).Days);
            entity.HasMany(d => d.Meals).WithOne(m => m.Day)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_daily_intake_meal");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<RenalTracker.Models.Day> DailyIntake { get; set; } = default!;
}
