using FluentAssertions;
using TaktTusur.Eda.Api.Tests.Helpers;
using TaktTusur.Eda.Api.Tests.Infrastructure;
using TaktTusur.Eda.Api.Tests.TestData;
using TaktTusur.Eda.Application.ViewModels;
using TaktTusur.Eda.Infrastructure.Contexts;

namespace TaktTusur.Eda.Api.Tests.Controllers;

[TestFixture]
public class RecipeControllerTests : TestsBase
{
	public const string BASE_URL = "api/v1/Recipe";

	[SetUp]
	public void SetUp()
	{
		var seedData = IngredientsTestData
			.SeedIngredientsData(null)
			.SeedMeasurementUnitsData()
			.SeedRecipesData();
		WebAppFactory = CustomWebApplicationFactory<Program>
			.CreateWithInMemoryDb<Program, EdaDbContext>(seedData);
	}

	[Test]
	public async Task GetRecipesTest()
	{
		var client = WebAppFactory!.CreateClient();

		var response = await client.GetStringAsync($"{BASE_URL}");
		var data = response.FromJson<ListResponse<RecipeShortViewModel>>();

		data!.Data
			.Should()
			.HaveCount(5);
		data!.Skip
			.Should()
			.Be(0);
		data!.Take
			.Should()
			.Be(10);
		data!.TotalCount
			.Should()
			.Be(5);
	}

	[Test]
	public async Task GetByIdTest()
	{
		var client = WebAppFactory!.CreateClient();
		var ingredients = new List<RecipeIngredientViewModel>()
		{
			new()
			{
				IngredientName = "лук",
				MeasurementUnitName = "грамм",
				AmountPerPerson = 100
			},
			new()
			{
				IngredientName = "томат",
				MeasurementUnitName = "грамм",
				AmountPerPerson = 200
			}
		};

		var response = await client.GetStringAsync($"{BASE_URL}/1");
		var data = response.FromJson<RecipeFullViewModel>();

		// Recipe
		data!.Id
			.Should()
			.Be(1, "Id should be 1 because 1 requested");
		data!.Name
			.Should()
			.Be("Tomato soup", $"It should be {{0}} because its added {nameof(RecipesTestData.TestData)}",
				"Tomato soup");
		data!.CookingGuideText
			.Should()
			.NotBeEmpty();
		data!.TimeToCookInSeconds
			.Should()
			.Be(10 * 60);
		data!.TimeToPrepareInSeconds
			.Should()
			.Be(5 * 60);
		data!.Revision
			.Should()
			.Be(0);

		// Ingredients
		data!.Ingredients
			.Should()
			.HaveCount(2);
		data!.Ingredients
			.Should()
			.BeEquivalentTo(ingredients);
	}
}