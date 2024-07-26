using Microsoft.EntityFrameworkCore;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.DataAccess.Contexts;

public class EdaDbContext : DbContext
{
	public DbSet<Recipe> Recipes { get; protected set; }

	public DbSet<Ingredient> Ingredients { get; protected set; }

	public DbSet<MeasurementUnit> MeasurementUnits { get; protected set; }

	public DbSet<RecipeIngredient> RecipeIngredients { get; protected set; }

	public EdaDbContext()
	{
	}
}