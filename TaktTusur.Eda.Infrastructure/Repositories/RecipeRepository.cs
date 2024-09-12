using Microsoft.EntityFrameworkCore;
using TaktTusur.Eda.Domain.Recipe;
using TaktTusur.Eda.Infrastructure.Contexts;

namespace TaktTusur.Eda.Infrastructure.Repositories;

public class RecipeRepository(EdaDbContext dbContext) : BaseRepository<Recipe>(dbContext), IRecipeRepository
{
	public override IQueryable<Recipe> GetAll(bool useTracking = false)
	{
		return useTracking ? dbContext.Recipes : dbContext.Recipes.AsNoTracking();
	}

	public override Recipe? GetById(long id)
	{
		return base.GetById(id,
			r => r.Include(x => x.Ingredients).ThenInclude(x => x.Ingredient),
			r => r.Include(x => x.Ingredients).ThenInclude(x => x.Units));
	}
}