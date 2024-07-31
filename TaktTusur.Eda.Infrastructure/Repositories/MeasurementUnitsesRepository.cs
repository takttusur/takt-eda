using TaktTusur.Eda.Infrastructure.Contexts;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.Infrastructure.Repositories;

public class MeasurementUnitsesRepository(EdaDbContext dbContext)
	: BaseRepository<MeasurementUnit>(dbContext), IMeasurementUnitsRepository
{
	public override IQueryable<MeasurementUnit> GetAll()
	{
		return dbContext.MeasurementUnits;
	}
}