using FluentAssertions;
using TaktTusur.Eda.Api.Tests.Helpers;
using TaktTusur.Eda.Api.Tests.Infrastructure;
using TaktTusur.Eda.Api.Tests.TestData;
using TaktTusur.Eda.Application.ViewModels;
using TaktTusur.Eda.Infrastructure.Contexts;

namespace TaktTusur.Eda.Api.Tests.Controllers;

public class MealPlanControllerTests : TestsBase
{
	public const string BASE_URL = "api/v1/MealPlan";

	[SetUp]
	public void SetUp()
	{
		var seedData = IngredientsTestData
			.SeedIngredientsData(null)
			.SeedMeasurementUnitsData()
			.SeedRecipesData()
			.SeedMealPlansData();

		WebAppFactory = CustomWebApplicationFactory<Program>
			.CreateWithInMemoryDb<Program, EdaDbContext>(seedData);
	}

	[Test]
	public async Task GetMealPlansTest()
	{
		var testGuids = MealPlanTestData.TestData.Value
			.Select(x => x.LongIdentifier)
			.ToArray();
		var firstPlan = MealPlanTestData.TestData.Value.First();
		var client = WebAppFactory!.CreateClient();

		var response = await client.GetStringAsync($"{BASE_URL}");
		var data = response.FromJson<ListResponse<MealPlanShortViewModel>>();

		data!.TotalCount
			.Should()
			.Be(6);
		data!.Data
			.Should()
			.HaveCount(6);
		data!.Skip
			.Should()
			.Be(0);
		data!.Take
			.Should()
			.Be(10);
		data!.Data
			.Select(x => x.LongIdentifier)
			.ToArray()
			.Should()
			.BeEquivalentTo(testGuids);

		var testPlan = data!.Data.First();
		testPlan.LongIdentifier
			.Should()
			.Be(firstPlan.LongIdentifier);
		testPlan.Revision
			.Should()
			.Be(firstPlan.Revision);
	}

	[Test]
	public async Task GetMealPlansTest_WithParams()
	{
		var client = WebAppFactory!.CreateClient();

		var response = await client.GetStringAsync($"{BASE_URL}?take=2&skip=0");
		var data = response.FromJson<ListResponse<MealPlanShortViewModel>>();

		data!.TotalCount
			.Should()
			.Be(6);
		data!.Data
			.Should()
			.HaveCount(2);
		data!.Skip
			.Should()
			.Be(0);
		data!.Take
			.Should()
			.Be(2);
	}

	[Test]
	public async Task GetSingle_ByGuid()
	{
		var firstPlan = MealPlanTestData.TestData.Value.First();
		var firstRecord = firstPlan.Records.First();
		var client = WebAppFactory!.CreateClient();

		var response = await client.GetStringAsync($"{BASE_URL}/{firstPlan.LongIdentifier}");
		var data = response.FromJson<MealPlanFullViewModel>();

		data!.LongIdentifier
			.Should()
			.Be(firstPlan.LongIdentifier);
		data!.Revision
			.Should()
			.Be(firstPlan.Revision);
		data!.CreatedAt
			.Should()
			.Be(firstPlan.CreatedAt);
		data!.UpdatedAt
			.Should()
			.Be(firstPlan.UpdatedAt);
		data!.Days
			.Should()
			.BeEquivalentTo(firstPlan.Records.Select(r => r.DateUtc).Distinct());
		data!.Records
			.Should()
			.HaveCount(firstPlan.Records.Count);

		var record = data!.Records.First(x => x.Id == firstRecord.Id);
		record.RecipeId
			.Should()
			.Be(firstRecord.Recipe.Id);
		record.RecipeName
			.Should()
			.Be(firstRecord.Recipe.Name);
		record.EatingTime
			.Should()
			.Be(firstRecord.EatingTime);
		record.AmountOfPeople
			.Should()
			.Be(firstRecord.AmountOfPeople);
		record.TimeToCookInSeconds
			.Should()
			.Be(firstRecord.Recipe.TimeToCookInSeconds);
		record.TimeToPrepareInSeconds
			.Should()
			.Be(firstRecord.Recipe.TimeToPrepareInSeconds);
		record.DateUtc
			.Should()
			.Be(firstRecord.DateUtc);
	}
}