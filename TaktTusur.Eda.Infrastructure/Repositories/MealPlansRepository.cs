using Microsoft.EntityFrameworkCore;
using TaktTusur.Eda.Domain.MealPlan;
using TaktTusur.Eda.Infrastructure.Contexts;

namespace TaktTusur.Eda.Infrastructure.Repositories;

public class MealPlansRepository(EdaDbContext dbContext) : BaseRepository<MealPlan>(dbContext), IMealPlanRepository
{
	public override IQueryable<MealPlan> GetAll(bool useTracking = false)
	{
		return useTracking ? dbContext.MealPlans : dbContext.MealPlans.AsNoTracking();
	}

	public MealPlan GetByGuid(Guid guid)
	{
		return dbContext.MealPlans
			.Include(x => x.Records).ThenInclude(x => x.Recipe)
			.Single(x => x.LongIdentifier == guid);
	}
}