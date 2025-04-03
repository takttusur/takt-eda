using TaktTusur.Eda.Domain.Recipe;
using TaktTusur.Eda.Infrastructure.Contexts;

namespace TaktTusur.Eda.Api.Tests.TestData;

public static class MeasurementUnitsTestData
{
	public static Action<EdaDbContext> SeedMeasurementUnitsData(this Action<EdaDbContext>? seedData)
	{
		return (dbContext) =>
		{
			seedData?.Invoke(dbContext);

			dbContext.MeasurementUnits.AddRange(TestData);
			dbContext.SaveChanges();
		};
	}

	public static IEnumerable<MeasurementUnit> TestData { get; } = new[]
	{
		MeasurementUnit.Create("литр"),
		MeasurementUnit.Create("грамм"),
		MeasurementUnit.Create("килограмм"),
		MeasurementUnit.Create("миллиграмм"),
		MeasurementUnit.Create("фунт"),
		MeasurementUnit.Create("унция"),
		MeasurementUnit.Create("ядро"),
		MeasurementUnit.Create("килокалория"),
		MeasurementUnit.Create("миллилитр"),
		MeasurementUnit.Create("пинта"),
		MeasurementUnit.Create("галлон"),
		MeasurementUnit.Create("кварт"),
		MeasurementUnit.Create("таблетка"),
		MeasurementUnit.Create("капсула"),
		MeasurementUnit.Create("ампула")
	};
}