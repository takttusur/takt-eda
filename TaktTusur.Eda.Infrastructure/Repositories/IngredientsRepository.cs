using Microsoft.EntityFrameworkCore;
using TaktTusur.Eda.Domain.Recipe;
using TaktTusur.Eda.Infrastructure.Contexts;

namespace TaktTusur.Eda.Infrastructure.Repositories;

public class IngredientsRepository(EdaDbContext dbContext)
	: BaseRepository<Ingredient>(dbContext), IIngredientsRepository
{
	public override IQueryable<Ingredient> GetAll(bool useTracking = false)
	{
		return useTracking ? dbContext.Ingredients : dbContext.Ingredients.AsNoTracking();
	}
}