using TaktTusur.Eda.Infrastructure.Contexts;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.Infrastructure.Repositories;

public class MeasurementUnitsRepository(EdaDbContext dbContext)
	: BaseRepository<MeasurementUnit>(dbContext), IMeasurementUnitsRepository
{
	public override IQueryable<MeasurementUnit> GetAll()
	{
		return dbContext.MeasurementUnits;
	}
}