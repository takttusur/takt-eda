using Microsoft.EntityFrameworkCore;
using TaktTusur.Eda.Domain.MealPlan;
using TaktTusur.Eda.Domain.Recipe;
using TaktTusur.Eda.Infrastructure.Converters;

namespace TaktTusur.Eda.Infrastructure.Contexts;

public class EdaDbContext : DbContext
{
	public EdaDbContext(DbContextOptions<EdaDbContext> options) : base(options)
	{
	}

	public DbSet<MeasurementUnit> MeasurementUnits { get; protected set; }

	public DbSet<Ingredient> Ingredients { get; protected set; }

	public DbSet<Recipe> Recipes { get; protected set; }

	public DbSet<RecipeIngredient> RecipeIngredients { get; protected set; }

	public DbSet<MealPlan> MealPlans { get; protected set; }

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
			.IsRequired()
			.HasColumnName("cooking_guide");
		recipes.Property(x => x.Revision)
			.IsRequired()
			.HasDefaultValue(0)
			.HasColumnName("revision");
		recipes.HasMany(x => x.Ingredients)
			.WithOne(x => x.Recipe)
			.HasForeignKey("recipe_id")
			.OnDelete(DeleteBehavior.Restrict);

		var recipeIngredient = modelBuilder.Entity<RecipeIngredient>();
		recipeIngredient.ToTable("RecipesIngredients")
			.HasKey(x => x.Id);
		recipeIngredient.Property(x => x.Id)
			.IsRequired()
			.HasColumnName("id");
		recipeIngredient.Property(x => x.AmountPerPerson)
			.IsRequired()
			.HasColumnName("amount_per_person");

		recipeIngredient.HasOne(e => e.Ingredient)
			.WithMany()
			.HasForeignKey("ingredient_id")
			.OnDelete(DeleteBehavior.Restrict);

		recipeIngredient.HasOne(e => e.Units)
			.WithMany()
			.HasForeignKey("measurement_units_id")
			.OnDelete(DeleteBehavior.Restrict);

		var mealPlan = modelBuilder.Entity<MealPlan>();
		mealPlan.ToTable("MealPlans")
			.HasKey(x => x.Id);
		mealPlan.Property(x => x.Id)
			.IsRequired()
			.HasColumnName("id");
		mealPlan.Property(x => x.LongIdentifier)
			.IsRequired()
			.HasColumnName("long_identifier");
		mealPlan.Property(x => x.Revision)
			.IsRequired()
			.HasColumnName("revision");
		mealPlan.Ignore(x => x.Records);
	}

	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
	{
		base.ConfigureConventions(configurationBuilder);
		configurationBuilder.Properties<DateTimeOffset>()
			.HaveConversion<DateTimeOffsetUniversalTimeConverter>();
	}
}