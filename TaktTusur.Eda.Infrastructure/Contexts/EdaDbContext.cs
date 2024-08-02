using Microsoft.EntityFrameworkCore;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.Infrastructure.Contexts;

public class EdaDbContext : DbContext
{
	public EdaDbContext(DbContextOptions<EdaDbContext> options) : base(options)
	{
	}

	public DbSet<MeasurementUnit> MeasurementUnits { get; protected set; }

	public DbSet<Ingredient> Ingredients { get; protected set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		var measurementUnits = modelBuilder.Entity<MeasurementUnit>();
		measurementUnits.ToTable("MeasurementUnits")
			.HasKey(x => x.Id);
		measurementUnits.Property(p => p.Id)
			.IsRequired()
			.HasColumnName("id");
		measurementUnits.Property(p => p.Name)
			.IsRequired()
			.HasColumnName("name");

		var ingredients = modelBuilder.Entity<Ingredient>();
		ingredients.ToTable("Ingredients")
			.HasKey(x => x.Id);
		ingredients.Property(x => x.Id)
			.IsRequired()
			.HasColumnName("id");
		ingredients.Property(x => x.Name)
			.IsRequired()
			.HasColumnName("name");

		var recipes = modelBuilder.Entity<Recipe>();
		recipes.ToTable("Recipes")
			.HasKey(x => x.Id);
		recipes.Property(x => x.Id)
			.IsRequired()
			.HasColumnName("id");
		recipes.Property(x => x.Name)
			.IsRequired()
			.HasColumnName("name");
		recipes.Property(x => x.TimeToCookInSeconds)
			.IsRequired()
			.HasColumnName("time_to_prepare_sec");
		recipes.Property(x => x.TimeToPrepareInSeconds)
			.IsRequired()
			.HasColumnName("time_to_cook_sec");
		recipes.Property(x => x.CookingGuideText)
			.HasColumnName("cooking_guide_text");
	}
}