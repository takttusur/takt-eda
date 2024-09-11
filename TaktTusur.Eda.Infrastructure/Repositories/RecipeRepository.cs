using Microsoft.EntityFrameworkCore;
using TaktTusur.Eda.Domain.Recipe;
using TaktTusur.Eda.Infrastructure.Contexts;

namespace TaktTusur.Eda.Infrastructure.Repositories;

public class RecipeRepository(EdaDbContext dbContext) : BaseRepository<Recipe>(dbContext), IRecipeRepository
{
	public override IQueryable<Recipe> GetAll()
	{
		return dbContext.Recipes;
	}
}