using TaktTusur.Eda.DataAccess.Contexts;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.DataAccess.Repositories;

public class MeasurementUnitRepository(EdaDbContext dbContext)
	: BaseRepository<MeasurementUnit>(dbContext), IMeasurementUnitRepository
{
	public override IQueryable<MeasurementUnit> GetAll()
	{
		return dbContext.MeasurementUnits;
	}
}