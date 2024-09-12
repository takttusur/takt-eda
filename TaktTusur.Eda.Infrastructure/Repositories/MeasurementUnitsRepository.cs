using Microsoft.EntityFrameworkCore;
using TaktTusur.Eda.Infrastructure.Contexts;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.Infrastructure.Repositories;

public class MeasurementUnitsRepository(EdaDbContext dbContext)
	: BaseRepository<MeasurementUnit>(dbContext), IMeasurementUnitsRepository
{
	public override IQueryable<MeasurementUnit> GetAll(bool useTracking = false)
	{
		return useTracking ? dbContext.MeasurementUnits : dbContext.MeasurementUnits.AsNoTracking();
	}
}